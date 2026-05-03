using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Zohal.Core;

namespace Zohal.Infrastructure
{
    public sealed class ZohalApiEnvelope<T>
        where T : class
    {
        [JsonPropertyName("result")]
        public int Result { get; set; }

        [JsonPropertyName("response_body")]
        public ZohalApiResponseBody<T>? ResponseBody { get; set; }
    }

    public sealed class ZohalApiResponseBody<T>
        where T : class
    {
        [JsonPropertyName("data")]
        public T? Data { get; set; }

        [JsonPropertyName("message")]
        public string? Message { get; set; }

        [JsonPropertyName("error_code")]
        public string? ErrorCode { get; set; }
    }

    /// <summary>
    /// تبدیل JSON به مدل خروجی با پشتیبانی از Soft Error و TraceId
    /// </summary>
    public sealed class ZohalResponseParser
    {
        private static readonly JsonSerializerOptions _options = new()
        {
            PropertyNameCaseInsensitive = true
        };

        public ZohalResult<T> Parse<T>(string json, string traceId)
            where T : class
        {
            try
            {
                var envelope = JsonSerializer.Deserialize<ZohalApiEnvelope<T>>(json, _options);

                if (envelope is null)
                {
                    var err = ZohalError.Api(
                        "API envelope is null",
                        $"RawJson={json}");

                    return ZohalResult<T>.Failure(err, traceId);
                }

                if (envelope.Result != 1)
                {
                    var err = ZohalError.Api(
                        envelope.ResponseBody?.Message ?? "API returned failure",
                        $"ErrorCode={envelope.ResponseBody?.ErrorCode}");

                    return ZohalResult<T>.Failure(err, traceId);
                }

                var data = envelope.ResponseBody?.Data;

                if (data is null)
                {
                    var err = ZohalError.Api(
                        "API response contains no data",
                        json);

                    return ZohalResult<T>.Failure(err, traceId);
                }

                return ZohalResult<T>.Success(data, traceId);
            }
            catch (Exception ex)
            {
                var err = ZohalError.Api(
                    "JSON parsing failed",
                    ex.Message);

                return ZohalResult<T>.Failure(err, traceId);
            }
        }
    }
}
