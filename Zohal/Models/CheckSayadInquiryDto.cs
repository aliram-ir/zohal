using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Zohal.Attributes;

namespace Zohal.Models
{
    public sealed class CheckSayadInquiryRequest
    {
        [JsonPropertyName("sayad_id")]
        [Required]
        [SayadId]
        public string SayadId { get; set; } = default!;
    }

    public sealed class CheckSayadInquiryResponse
    {
        [JsonPropertyName("branch_code")]
        public string BranchCode { get; set; } = default!;

        [JsonPropertyName("check_type")]
        public string CheckType { get; set; } = default!;

        [JsonPropertyName("expiration_date")]
        public string ExpirationDate { get; set; } = default!;

        [JsonPropertyName("iban")]
        public string Iban { get; set; } = default!;

        [JsonPropertyName("issue_date")]
        public string IssueDate { get; set; } = default!;

        [JsonPropertyName("name")]
        public string Name { get; set; } = default!;

        [JsonPropertyName("returned_cheques")]
        public string ReturnedCheques { get; set; } = default!;

        [JsonPropertyName("sayad_id")]
        public string SayadId { get; set; } = default!;

        [JsonPropertyName("serial_no")]
        public string SerialNo { get; set; } = default!;

        [JsonPropertyName("series_no")]
        public string SeriesNo { get; set; } = default!;
    }
}
