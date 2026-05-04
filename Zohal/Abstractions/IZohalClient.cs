using System.Threading;
using System.Threading.Tasks;
using Zohal.Core;
using Zohal.Models;

namespace Zohal.Abstractions;

/// <summary>
/// کلاینت اصلی سرویس‌های زحل
/// (الگوی Soft-Error + Clean Architecture)
/// </summary>
public interface IZohalClient
{
    #region خدمات هویتی

    /// <summary>
    /// استعلام اطلاعات هویتی
    /// </summary>
    Task<ZohalResult<NationalIdentityInquiryResponse>> NationalIdentityInquiryAsync(
        NationalIdentityInquiryRequest request,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// تطابق کد ملی و شماره شبا
    /// </summary>
    Task<ZohalResult<ShahkarInquiryResponse>> ShahkarInquiryAsync(
        ShahkarInquiryRequest request,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// تطابق کد ملی و شبا
    /// </summary>
    Task<ZohalResult<CheckIbanWithNationalCodeResponse>> CheckIbanWithNationalCodeInquiryAsync(
        CheckIbanWithNationalCodeRequest request,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// تطابق کارت و کد ملی
    /// </summary>
    Task<ZohalResult<CheckCardWithNationalCodeResponse>> CheckCardWithNationalCodeInquiryAsync(
        CheckCardWithNationalCodeRequest request,
        CancellationToken cancellationToken = default);

    #endregion

    #region خدمات بانکی

    Task<ZohalResult<CardInquiryResponse>> CardInquiryAsync(
        CardInquiryRequest request,
        CancellationToken cancellationToken = default);

    Task<ZohalResult<CardToIbanResponse>> CardToIbanAsync(
        CardToIbanRequest request,
        CancellationToken cancellationToken = default);

    Task<ZohalResult<AccountToIbanResponse>> AccountToIbanAsync(
        AccountToIbanRequest request,
        CancellationToken cancellationToken = default);

    Task<ZohalResult<CheckCardWithNameResponse>> CheckCardWithNameAsync(
        CheckCardWithNameRequest request,
        CancellationToken cancellationToken = default);

    Task<ZohalResult<CheckIbanWithNameResponse>> CheckIbanWithNameAsync(
        CheckIbanWithNameRequest request,
        CancellationToken cancellationToken = default);

    Task<ZohalResult<CardToAccountResponse>> CardToAccountAsync(
        CardToAccountRequest request,
        CancellationToken cancellationToken = default);

    Task<ZohalResult<IbanResponse>> IbanAsync(
        IbanRequest request,
        CancellationToken cancellationToken = default);

    Task<ZohalResult<CheckSayadInquiryResponse>> CheckSayadInquiryAsync(
        CheckSayadInquiryRequest request,
        CancellationToken cancellationToken = default);

    Task<ZohalResult<BouncedChequeResponse>> BouncedChequeAsync(
        BouncedChequeRequest request,
        CancellationToken cancellationToken = default);

    #endregion

    #region خدماتی

    /// <summary>
    /// استعلام اعضای هیأت مدیره شرکت
    /// </summary>
    Task<ZohalResult<CompanyInquiryBoardMembersData>> CompanyInquiryBoardMembersAsync(
        CompanyInquiryBoardMembersRequest request,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// استعلام اطلاعات شرکت​
    /// </summary>
    Task<ZohalResult<CompanyInquiryResponse>> CompanyInquiryAsync(
        CompanyInquiryRequest request,
        CancellationToken cancellationToken = default);


    /// <summary>
    /// استعلام تاریخچه اعضای هیئت‌مدیره شرکت​
    /// </summary>
    Task<ZohalResult<CompanyInquiryBoardMembersHistoryData>> CompanyInquiryBoardMembersHistoryAsync(
        CompanyInquiryBoardMembersHistoryRequest request,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// استعلام کد پستی​
    /// </summary>
    Task<ZohalResult<PostalCodeInquiryResponse>> PostalCodeInquiryAsync(
        PostalCodeInquiryRequest request,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// استعلام خلافی خودرو​
    /// </summary>
    Task<ZohalResult<VehicleInquiryTotalViolationsResponse>> VehicleInquiryTotalViolationsAsync(
       VehicleInquiryTotalViolationsRequest request,
        CancellationToken cancellationToken = default);


    /// <summary>
    /// استعلام جزئیات خلافی خودرو (برگه‌های جریمه)
    /// </summary>
    Task<ZohalResult<VehicleInquiryTotalViolationsDetailsData>> VehicleInquiryTotalViolationsDetailsAsync(
        VehicleInquiryTotalViolationsDetailsRequest request,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// استعلام Enamad​
    /// </summary>
    Task<ZohalResult<EnamadInquiryResponse>> EnamadInquiryAsync(
        EnamadInquiryRequest request,
        CancellationToken cancellationToken = default);


    #endregion
}
