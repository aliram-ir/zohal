using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Zohal.Attributes;

namespace Zohal.Models
{
    public sealed class BouncedChequeRequest
    {
        /// <summary>
        /// کد ملی
        /// </summary>
        [JsonPropertyName("national_code")]
        [Required]
        [NationalCode]
        public string NationalCode { get; set; } = default!;

        [JsonPropertyName("nationality_type")]
        [Required]
        public int NationalityType { get; set; } = default!;
    }

    public sealed class BouncedChequeResponse
    {
        [JsonPropertyName("count")]
        public int Count { get; set; } = default!;
    }
}
