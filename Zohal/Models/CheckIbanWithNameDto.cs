using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Zohal.Attributes;

namespace Zohal.Models
{
    public sealed class CheckIbanWithNameRequest
    {
        [JsonPropertyName("IBAN")]
        [Required]
        [IranianIban]
        public string Iban { get; set; } = default!;

        [JsonPropertyName("name")]
        [Required]
        [PersianText]
        public string Name { get; set; } = default!;
    }

    public sealed class CheckIbanWithNameResponse
    {
        /// <summary>
        /// تطابق اطلاعات
        /// </summary>
        [JsonPropertyName("matched")]
        public bool Matched { get; set; }
    }
}
