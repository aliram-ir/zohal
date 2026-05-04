using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Zohal.Attributes;

namespace Zohal.Models
{
    public sealed class CompanyInquiryRequest
    {
        /// <summary>
        /// شناسه ملی شرکت
        /// </summary>
        [JsonPropertyName("national_id")]
        [Required]
        [NationalCompanyId]
        public string NationalId { get; set; } = default!;
    }

    public sealed class CompanyInquiryResponse
    {
        [JsonPropertyName("activity_end_date")]
        public string ActivityEndDate { get; set; } = default!;

        [JsonPropertyName("address")]
        public string Address { get; set; } = default!;

        [JsonPropertyName("company_type")]
        public string CompanyType { get; set; } = default!;

        [JsonPropertyName("created_at")]
        public string CreatedAt { get; set; } = default!;

        [JsonPropertyName("email_address")]
        public string EmailAddress { get; set; } = default!;

        [JsonPropertyName("fax_number")]
        public string FaxNumber { get; set; } = default!;

        [JsonPropertyName("issuance_date")]
        public string IssuanceDate { get; set; } = default!;

        [JsonPropertyName("name")]
        public string Name { get; set; } = default!;

        [JsonPropertyName("national_id")]
        public string NationalId { get; set; } = default!;

        [JsonPropertyName("phone_number")]
        public string PhoneNumber { get; set; } = default!;

        [JsonPropertyName("postal_code")]
        public string PostalCode { get; set; } = default!;

        [JsonPropertyName("register_date")]
        public string RegisterDate { get; set; } = default!;

        [JsonPropertyName("register_number")]
        public string RegisterNumber { get; set; } = default!;
    }
}
