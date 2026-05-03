using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Zohal.Attributes;

///استعلام نام صاحب کارت​
namespace Zohal.Models
{
    public sealed class CardInquiryRequest
    {
        [JsonPropertyName("card_number")]
        [Required]
        [IranianCardNumber]
        public string CardNumber { get; set; } = default!;
    }

    public sealed class CardInquiryResponse
    {
        /// <summary>
        /// نام
        /// </summary>
        [JsonPropertyName("name")]
        public string? Name { get; set; }
    }
}
