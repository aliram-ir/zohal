using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Reflection;
using Zohal.Core;

namespace Zohal.Infrastructure
{
    /// <summary>
    /// مسئول ارسال درخواست HTTP با پشتیبانی از TraceId و Soft Error
    /// </summary>
    public sealed class ZohalHttpExecutor
    {
        private readonly HttpClient _httpClient;
        private readonly ZohalOptions _options;

        private static readonly JsonSerializerOptions _jsonOptions = new()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            PropertyNameCaseInsensitive = true,
            WriteIndented = false
        };

        public ZohalHttpExecutor(HttpClient httpClient, ZohalOptions options)
        {
            _httpClient = httpClient;
            _options = options;

            _httpClient.BaseAddress = new Uri(_options.BaseUrl);
            _httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", _options.Token);
        }

        /// <summary>
        /// ارسال POST استاندارد JSON
        /// </summary>
        public async Task<ZohalResult<string>> PostAsync(
            string endpoint,
            object request,
            string traceId,
            CancellationToken cancellationToken)
        {
            try
            {
                // افزودن TraceId
                _httpClient.DefaultRequestHeaders.Remove("X-Trace-Id");
                _httpClient.DefaultRequestHeaders.Add("X-Trace-Id", traceId);

                var json = JsonSerializer.Serialize(request, _jsonOptions);

                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync(
                    endpoint,
                    content,
                    cancellationToken);

                var body = await response.Content.ReadAsStringAsync(cancellationToken);

                if (!response.IsSuccessStatusCode)
                {
                    var err = ZohalError.Http(
                        "HTTP error status returned from server",
                        $"StatusCode={response.StatusCode}, Body={body}");

                    return ZohalResult<string>.Failure(err, traceId);
                }

                return ZohalResult<string>.Success(body, traceId);
            }
            catch (Exception ex)
            {
                var err = ZohalError.Unexpected(
                    "Unexpected exception during HTTP request",
                    ex.Message);

                return ZohalResult<string>.Failure(err, traceId);
            }
        }

        /// <summary>
        /// ارسال POST به صورت Multipart/Form-Data (برای OCR)
        /// </summary>
        public async Task<ZohalResult<string>> PostMultipartAsync(
            string endpoint,
            object request,
            string traceId,
            CancellationToken cancellationToken)
        {
            try
            {
                _httpClient.DefaultRequestHeaders.Remove("X-Trace-Id");
                _httpClient.DefaultRequestHeaders.Add("X-Trace-Id", traceId);

                using var content = new MultipartFormDataContent();

                // تبدیل DTO به form-data
                var props = request.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);

                foreach (var prop in props)
                {
                    var value = prop.GetValue(request);
                    if (value == null)
                        continue;

                    var str = value.ToString()!;
                    content.Add(new StringContent(str), prop.Name);
                }

                var response = await _httpClient.PostAsync(
                    endpoint,
                    content,
                    cancellationToken);

                var body = await response.Content.ReadAsStringAsync(cancellationToken);

                if (!response.IsSuccessStatusCode)
                {
                    var err = ZohalError.Http(
                        "HTTP error status returned from server",
                        $"StatusCode={response.StatusCode}, Body={body}");

                    return ZohalResult<string>.Failure(err, traceId);
                }

                return ZohalResult<string>.Success(body, traceId);
            }
            catch (Exception ex)
            {
                var err = ZohalError.Unexpected(
                    "Unexpected exception during multipart HTTP request",
                    ex.Message);

                return ZohalResult<string>.Failure(err, traceId);
            }
        }
    }
}
