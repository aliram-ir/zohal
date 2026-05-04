using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Zohal.Attributes;

namespace Zohal.Models
{
    public sealed class PostalCodeInquiryRequest
    {
        [JsonPropertyName("postal_code")]
        [Required]
        [PostalCode]
        public string PostalCode { get; set; } = default!;
    }

    public sealed class PostalCodeInquiryResponse
    {
        [JsonPropertyName("building_name")]
        public string BuildingName { get; set; } = default!;

        [JsonPropertyName("description")]
        public string Description { get; set; } = default!;

        [JsonPropertyName("district")]
        public string District { get; set; } = default!;

        [JsonPropertyName("floor")]
        public string Floor { get; set; } = default!;

        [JsonPropertyName("number")]
        public string Number { get; set; } = default!;

        [JsonPropertyName("province")]
        public string Province { get; set; } = default!;

        [JsonPropertyName("side_floor")]
        public string SideFloor { get; set; } = default!;

        [JsonPropertyName("street")]
        public string Street { get; set; } = default!;

        [JsonPropertyName("street2")]
        public string Street2 { get; set; } = default!;

        [JsonPropertyName("town")]
        public string Town { get; set; } = default!;
    }
}
