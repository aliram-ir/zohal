using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;
using Zohal.Abstractions;
using Zohal.Constants;
using Zohal.Core;
using Zohal.Enums;
using Zohal.Models;

namespace Zohal.Infrastructure
{
    /// <summary>
    /// کلاینت اصلی زحل با الگوی Soft-Error + لاگ استاندارد + TraceId
    /// </summary>
    public sealed class ZohalClient : IZohalClient
    {
        private readonly IZohalRequestValidator _validator;
        private readonly ZohalHttpExecutor _executor;
        private readonly ZohalResponseParser _parser;
        private readonly ILogger<ZohalClient> _logger;

        public ZohalClient(
            IZohalRequestValidator validator,
            ZohalHttpExecutor executor,
            ZohalResponseParser parser,
            ILogger<ZohalClient> logger)
        {
            _validator = validator;
            _executor = executor;
            _parser = parser;
            _logger = logger;
        }

        /// <summary>
        /// مرکز عملیات: اعتبارسنجی + ارسال HTTP + پارس + مدیریت خطا + لاگ استاندارد
        /// </summary>
        private async Task<ZohalResult<TResponse>> SendAsync<TRequest, TResponse>(
            string endpoint,
            TRequest request,
            CancellationToken cancellationToken = default)
            where TResponse : class
        {
            var traceId = Guid.NewGuid().ToString("N");

            _logger.LogInformation(
                "➡️ شروع درخواست | Endpoint={Endpoint} | TraceId={TraceId} | RequestType={Type}",
                endpoint, traceId, typeof(TRequest).Name);

            try
            {
                //===========================================================
                //  مرحله ۱: اعتبارسنجی ورودی
                //===========================================================
                var validationError = _validator.Validate(request);
                if (validationError is not null)
                {
                    _logger.LogWarning(
                        "⚠️ مشکل اعتبارسنجی | Endpoint={Endpoint} | TraceId={TraceId} | Error={Error}",
                        endpoint, traceId, validationError);

                    return ZohalResult<TResponse>.Failure(validationError, traceId);
                }

                //===========================================================
                //  مرحله ۲: ارسال HTTP Request
                //===========================================================
                _logger.LogInformation(
                    "📤 ارسال HTTP POST | Endpoint={Endpoint} | TraceId={TraceId}",
                    endpoint, traceId);

                var httpResult = await _executor.PostAsync(
                    endpoint,
                    request!,
                    traceId,
                    cancellationToken);

                if (!httpResult.IsSuccess)
                {
                    _logger.LogError(
                        "❌ خطا در HTTP | Endpoint={Endpoint} | TraceId={TraceId} | Error={Error}",
                        endpoint, traceId, httpResult.Error);

                    return ZohalResult<TResponse>.Failure(httpResult.Error!, traceId);
                }

                //===========================================================
                //  مرحله ۳: پارس JSON
                //===========================================================
                _logger.LogInformation(
                    "📥 دریافت پاسخ JSON، شروع پردازش | Endpoint={Endpoint} | TraceId={TraceId}",
                    endpoint, traceId);

                var parsed = _parser.Parse<TResponse>(httpResult.Data!, traceId);

                if (!parsed.IsSuccess)
                {
                    _logger.LogError(
                        "❌ خطا در پارس JSON | Endpoint={Endpoint} | TraceId={TraceId} | Error={Error}",
                        endpoint, traceId, parsed.Error);

                    return parsed;
                }

                _logger.LogInformation(
                    "✅ موفقیت کامل | Endpoint={Endpoint} | TraceId={TraceId}",
                    endpoint, traceId);

                return parsed;
            }
            catch (Exception ex)
            {
                //===========================================================
                //  خطای غیرمنتظره (Soft Error)
                //===========================================================
                var error = ZohalError.Unexpected(
                    "Unhandled exception during request execution.",
                    ex.Message);

                _logger.LogCritical(ex,
                    "💥 خطای غیرمنتظره | Endpoint={Endpoint} | TraceId={TraceId}",
                    endpoint, traceId);

                return ZohalResult<TResponse>.Failure(error, traceId);
            }
        }

        private async Task<ZohalResult<TResponse>> SendByMultipartAsync<TRequest, TResponse>(
    string endpoint,
    TRequest request,
    CancellationToken cancellationToken = default)
    where TResponse : class
        {
            var traceId = Guid.NewGuid().ToString("N");

            _logger.LogInformation(
                "➡️ شروع درخواست Multipart | Endpoint={Endpoint} | TraceId={TraceId} | RequestType={Type}",
                endpoint, traceId, typeof(TRequest).Name);

            try
            {
                //===========================================================
                //  مرحله ۱: اعتبارسنجی ورودی
                //===========================================================
                var validationError = _validator.Validate(request);
                if (validationError is not null)
                {
                    _logger.LogWarning(
                        "⚠️ مشکل اعتبارسنجی | Endpoint={Endpoint} | TraceId={TraceId} | Error={Error}",
                        endpoint, traceId, validationError);

                    return ZohalResult<TResponse>.Failure(validationError, traceId);
                }

                //===========================================================
                //  مرحله ۲: ارسال Multipart HTTP Request
                //===========================================================
                _logger.LogInformation(
                    "📤 ارسال Multipart HTTP POST | Endpoint={Endpoint} | TraceId={TraceId}",
                    endpoint, traceId);

                var httpResult = await _executor.PostMultipartAsync(
                    endpoint,
                    request!,
                    traceId,
                    cancellationToken);

                if (!httpResult.IsSuccess)
                {
                    _logger.LogError(
                        "❌ خطا در HTTP Multipart | Endpoint={Endpoint} | TraceId={TraceId} | Error={Error}",
                        endpoint, traceId, httpResult.Error);

                    return ZohalResult<TResponse>.Failure(httpResult.Error!, traceId);
                }

                //===========================================================
                //  مرحله ۳: پارس JSON
                //===========================================================
                _logger.LogInformation(
                    "📥 دریافت پاسخ JSON، شروع پردازش | Endpoint={Endpoint} | TraceId={TraceId}",
                    endpoint, traceId);

                var parsed = _parser.Parse<TResponse>(httpResult.Data!, traceId);

                if (!parsed.IsSuccess)
                {
                    _logger.LogError(
                        "❌ خطا در پارس JSON | Endpoint={Endpoint} | TraceId={TraceId} | Error={Error}",
                        endpoint, traceId, parsed.Error);

                    return parsed;
                }

                _logger.LogInformation(
                    "✅ موفقیت کامل | Endpoint={Endpoint} | TraceId={TraceId}",
                    endpoint, traceId);

                return parsed;
            }
            catch (Exception ex)
            {
                //===========================================================
                //  خطای غیرمنتظره
                //===========================================================
                var error = ZohalError.Unexpected(
                    "Unhandled exception during multipart request execution.",
                    ex.Message);

                _logger.LogCritical(ex,
                    "💥 خطای غیرمنتظره | Endpoint={Endpoint} | TraceId={TraceId}",
                    endpoint, traceId);

                return ZohalResult<TResponse>.Failure(error, traceId);
            }
        }


        //===========================================================
        //                     سرویس‌های هویتی
        //===========================================================

        public Task<ZohalResult<NationalIdentityInquiryResponse>> NationalIdentityInquiryAsync(
            NationalIdentityInquiryRequest request,
            CancellationToken cancellationToken = default)
            => SendAsync<NationalIdentityInquiryRequest, NationalIdentityInquiryResponse>(
                ZohalEndpoints.NationalIdentityInquiry,
                request,
                cancellationToken);

        public Task<ZohalResult<ShahkarInquiryResponse>> ShahkarInquiryAsync(
            ShahkarInquiryRequest request,
            CancellationToken cancellationToken = default)
            => SendAsync<ShahkarInquiryRequest, ShahkarInquiryResponse>(
                ZohalEndpoints.ShahkarInquiry,
                request,
                cancellationToken);

        public Task<ZohalResult<CheckIbanWithNationalCodeResponse>> CheckIbanWithNationalCodeInquiryAsync(
            CheckIbanWithNationalCodeRequest request,
            CancellationToken cancellationToken = default)
            => SendAsync<CheckIbanWithNationalCodeRequest, CheckIbanWithNationalCodeResponse>(
                ZohalEndpoints.CheckIbanWithNationalCodeInquiry,
                request,
                cancellationToken);

        public Task<ZohalResult<CheckCardWithNationalCodeResponse>> CheckCardWithNationalCodeInquiryAsync(
            CheckCardWithNationalCodeRequest request,
            CancellationToken cancellationToken = default)
            => SendAsync<CheckCardWithNationalCodeRequest, CheckCardWithNationalCodeResponse>(
                ZohalEndpoints.CheckCardWithNationalCodeInquiry,
                request,
                cancellationToken);

        //===========================================================
        //                     خدمات بانکی
        //===========================================================

        public Task<ZohalResult<CardInquiryResponse>> CardInquiryAsync(
            CardInquiryRequest request,
            CancellationToken cancellationToken = default)
            => SendAsync<CardInquiryRequest, CardInquiryResponse>(
                ZohalEndpoints.CardInquiry,
                request,
                cancellationToken);

        public Task<ZohalResult<CardToIbanResponse>> CardToIbanAsync(
            CardToIbanRequest request,
            CancellationToken cancellationToken = default)
            => SendAsync<CardToIbanRequest, CardToIbanResponse>(
                ZohalEndpoints.CardToIban,
                request,
                cancellationToken);

        public Task<ZohalResult<AccountToIbanResponse>> AccountToIbanAsync(
            AccountToIbanRequest request,
            CancellationToken cancellationToken = default)
            => SendAsync<AccountToIbanRequest, AccountToIbanResponse>(
                ZohalEndpoints.AccountToIban,
                request,
                cancellationToken);

        public Task<ZohalResult<CheckCardWithNameResponse>> CheckCardWithNameAsync(
            CheckCardWithNameRequest request,
            CancellationToken cancellationToken = default)
            => SendAsync<CheckCardWithNameRequest, CheckCardWithNameResponse>(
                ZohalEndpoints.CheckCardWithName,
                request,
                cancellationToken);

        public Task<ZohalResult<CheckIbanWithNameResponse>> CheckIbanWithNameAsync(
            CheckIbanWithNameRequest request,
            CancellationToken cancellationToken = default)
            => SendAsync<CheckIbanWithNameRequest, CheckIbanWithNameResponse>(
                ZohalEndpoints.CheckIbanWithName,
                request,
                cancellationToken);

        public Task<ZohalResult<CardToAccountResponse>> CardToAccountAsync(
            CardToAccountRequest request,
            CancellationToken cancellationToken = default)
            => SendAsync<CardToAccountRequest, CardToAccountResponse>(
                ZohalEndpoints.CardToAccount,
                request,
                cancellationToken);

        public Task<ZohalResult<IbanResponse>> IbanAsync(
            IbanRequest request,
            CancellationToken cancellationToken = default)
            => SendAsync<IbanRequest, IbanResponse>(
                ZohalEndpoints.Iban,
                request,
                cancellationToken);

        public Task<ZohalResult<CheckSayadInquiryResponse>> CheckSayadInquiryAsync(
            CheckSayadInquiryRequest request,
            CancellationToken cancellationToken = default)
            => SendAsync<CheckSayadInquiryRequest, CheckSayadInquiryResponse>(
                ZohalEndpoints.CheckSayadInquiry,
                request,
                cancellationToken);

        public Task<ZohalResult<BouncedChequeResponse>> BouncedChequeAsync(
            BouncedChequeRequest request,
            CancellationToken cancellationToken = default)
            => SendAsync<BouncedChequeRequest, BouncedChequeResponse>(
                ZohalEndpoints.BouncedCheque,
                request,
                cancellationToken);


        //===========================================================
        //                     خدماتی
        //===========================================================


        public Task<ZohalResult<CompanyInquiryBoardMembersData>> CompanyInquiryBoardMembersAsync(CompanyInquiryBoardMembersRequest request,
            CancellationToken cancellationToken = default)
        => SendAsync<CompanyInquiryBoardMembersRequest, CompanyInquiryBoardMembersData>(
                ZohalEndpoints.CompanyInquiryBoardMembers,
                request,
                cancellationToken);

        public Task<ZohalResult<CompanyInquiryResponse>> CompanyInquiryAsync(CompanyInquiryRequest request, CancellationToken cancellationToken = default)
         => SendAsync<CompanyInquiryRequest, CompanyInquiryResponse>(
                ZohalEndpoints.CompanyInquiry,
                request,
                cancellationToken);

        public Task<ZohalResult<CompanyInquiryBoardMembersHistoryData>> CompanyInquiryBoardMembersHistoryAsync(CompanyInquiryBoardMembersHistoryRequest request, CancellationToken cancellationToken = default)
         => SendAsync<CompanyInquiryBoardMembersHistoryRequest, CompanyInquiryBoardMembersHistoryData>(
                ZohalEndpoints.CompanyInquiryBoardMembersHistory,
                request,
                cancellationToken);

        public Task<ZohalResult<PostalCodeInquiryResponse>> PostalCodeInquiryAsync(PostalCodeInquiryRequest request, CancellationToken cancellationToken = default)
         => SendAsync<PostalCodeInquiryRequest, PostalCodeInquiryResponse>(
                ZohalEndpoints.PostalCodeInquiry,
                request,
                cancellationToken);

        public Task<ZohalResult<VehicleInquiryTotalViolationsResponse>> VehicleInquiryTotalViolationsAsync(VehicleInquiryTotalViolationsRequest request, CancellationToken cancellationToken = default)
         => SendAsync<VehicleInquiryTotalViolationsRequest, VehicleInquiryTotalViolationsResponse>(
                ZohalEndpoints.VehicleInquiryTotalViolations,
                request,
                cancellationToken);

        public Task<ZohalResult<VehicleInquiryTotalViolationsDetailsData>> VehicleInquiryTotalViolationsDetailsAsync(VehicleInquiryTotalViolationsDetailsRequest request, CancellationToken cancellationToken = default)
         => SendAsync<VehicleInquiryTotalViolationsDetailsRequest, VehicleInquiryTotalViolationsDetailsData>(
                ZohalEndpoints.VehicleInquiryTotalViolationsDetails,
                request,
                cancellationToken);

        public Task<ZohalResult<EnamadInquiryResponse>> EnamadInquiryAsync(EnamadInquiryRequest request, CancellationToken cancellationToken = default)
        => SendAsync<EnamadInquiryRequest, EnamadInquiryResponse>(
                ZohalEndpoints.EnamadInquiry,
                request,
                cancellationToken);

        public Task<ZohalResult<NationalCardOcrResponse>> NationalCardOcrAsync(
    NationalCardOcrRequest request,
    CancellationToken cancellationToken = default)
    => SendByMultipartAsync<NationalCardOcrRequest, NationalCardOcrResponse>(
        ZohalEndpoints.NationalCardOcr,
        request,
        cancellationToken);

        public Task<ZohalResult<VoiceOtpResponse>> VoiceOtp(VoiceOtpRequest request, CancellationToken cancellationToken = default)
        => SendAsync<VoiceOtpRequest, VoiceOtpResponse>(
                ZohalEndpoints.VoiceOtp,
                request,
                cancellationToken);

        public Task<ZohalResult<SimCardBillResponse>> SimCardBillInquiry(
     SimCardBillRequest request,
     CancellationToken cancellationToken = default)
        {
            var operatorInfo = SimCardOperatorHelper.DetectOperator(request.Mobile);

            var endpoint = SimCardBillEndpointResolver.Resolve(operatorInfo.Type);

            return SendAsync<SimCardBillRequest, SimCardBillResponse>(
                endpoint,
                request,
                cancellationToken);
        }


    }
}
