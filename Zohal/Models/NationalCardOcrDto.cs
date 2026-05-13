using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Zohal.Models
{
    public sealed class NationalCardOcrRequest
    {
        [JsonPropertyName("national_card_back")]
        [Required]
        public string NationalCardBack { get; set; } = default!;

        [JsonPropertyName("national_card_front")]
        [Required]
        public string NationalCardFront { get; set; } = default!;
    }

    public sealed class NationalCardOcrResponse
    {
        [JsonPropertyName("national_code")]
        public string NationalCode { get; set; } = default!;

        [JsonPropertyName("serial_card")]
        public string SerialCard { get; set; } = default!;
    }
}
