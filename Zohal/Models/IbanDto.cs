using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Zohal.Attributes;

namespace Zohal.Models
{
    public sealed class IbanRequest
    {
        [JsonPropertyName("IBAN")]
        [Required]
        [IranianIban]
        public string Iban { get; set; } = default!;
    }
    public sealed class IbanResponse
    {
        [JsonPropertyName("bank_name")]
        public string BankName { get; set; } = default!;

        [JsonPropertyName("is_transferable")]
        public bool IsTransferable { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; } = default!;
    }
}
