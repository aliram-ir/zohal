using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Zohal.Attributes;

namespace Zohal.Models
{
    public sealed class CardToAccountRequest
    {
        [JsonPropertyName("card_number")]
        [Required]
        [IranianCardNumber]
        public string CardNumber { get; set; } = default!;
    }

    public sealed class CardToAccountResponse
    {
        [JsonPropertyName("bank_account")]
        public string BankAccount { get; set; } = default!;

        [JsonPropertyName("bank_name")]
        public string BankName { get; set; } = default!;

        [JsonPropertyName("name")]
        public string Name { get; set; } = default!;
    }
}
