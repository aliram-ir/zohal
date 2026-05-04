using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Zohal.Attributes;

namespace Zohal.Models
{
    public class EnamadInquiryRequest
    {
        [JsonPropertyName("website")]
        [Required]
        [WebsiteUrl]
        public string Website { get; set; } = default!;
    }

    public class EnamadInquiryResponse
    {
        [JsonPropertyName("approve_date")]
        public string ApproveDate { get; set; } = default!;

        [JsonPropertyName("city_name")]
        public string CityName { get; set; } = default!;

        [JsonPropertyName("domain")]
        public string Domain { get; set; } = default!;

        [JsonPropertyName("expired")]
        public string Expired { get; set; } = default!;

        [JsonPropertyName("expiry_date")]
        public string ExpiryDate { get; set; } = default!;

        [JsonPropertyName("id")]
        public string Id { get; set; } = default!;

        [JsonPropertyName("logolevel")]
        public string LogoLevel { get; set; } = default!;

        [JsonPropertyName("message")]
        public string Message { get; set; } = default!;

        [JsonPropertyName("name")]
        public string Name { get; set; } = default!;

        [JsonPropertyName("nameper")]
        public string NamePer { get; set; } = default!;

        [JsonPropertyName("srv_text")]
        public string SrvText { get; set; } = default!;

        [JsonPropertyName("state_name")]
        public string StateName { get; set; } = default!;
    }
}
