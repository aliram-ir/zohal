using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Zohal.Attributes;

namespace Zohal.Models
{
    public sealed class CheckCardWithNameRequest
    {
        [JsonPropertyName("card_number")]
        [Required]
        [IranianCardNumber]
        public string CardNumber { get; set; } = default!;

        [JsonPropertyName("name")]
        [Required]
        [PersianText]
        public string Name { get; set; } = default!;
    }

    public sealed class CheckCardWithNameResponse
    {
        [JsonPropertyName("name")]
        public string Name { get; set; } = default!;
    }
}
