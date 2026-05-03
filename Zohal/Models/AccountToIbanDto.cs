using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Zohal.Models
{
    public sealed class AccountToIbanRequest
    {
        [JsonPropertyName("bank_account")]
        [Required]
        public string BankAccount { get; set; } = default!;

        [JsonPropertyName("bank_code")]
        [Required]
        public string BankCode { get; set; } = default!;
    }

    public sealed class AccountToIbanResponse
    {
        [JsonPropertyName("IBAN")]
        [Required]
        public string Iban { get; set; } = default!;
    }
}
