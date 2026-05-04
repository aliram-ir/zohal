using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Zohal.Attributes;

namespace Zohal.Models
{
    public sealed class VehicleInquiryTotalViolationsRequest
    {
        /// <summary>
        /// شماره موبایل
        /// </summary>
        [JsonPropertyName("mobile")]
        [Required]
        [IranianMobile]
        public string Mobile { get; set; } = default!;

        /// <summary>
        /// کد ملی
        /// </summary>
        [JsonPropertyName("national_code")]
        [Required]
        [NationalCode]
        public string NationalCode { get; set; } = default!;

        /// <summary>
        /// پلاک ماشین : 11 ب 111
        /// </summary>
        [JsonPropertyName("plate_number")]
        [Required]
        [IranianPlateNumber]
        public string PlateNumber { get; set; } = default!;

        /// <summary>
        /// کد شهر : 11
        /// </summary>
        [JsonPropertyName("region_code")]
        [Required]
        public string RegionCode { get; set; } = default!;
    }

    public sealed class VehicleInquiryTotalViolationsResponse
    {
        [JsonPropertyName("ejr_inquire_no")]
        public string EjrInquireNo { get; set; } = default!;

        [JsonPropertyName("inquire_price")]
        public string InquirePrice { get; set; } = default!;

        [JsonPropertyName("page_count")]
        public string PageCount { get; set; } = default!;

        [JsonPropertyName("paper_id")]
        public string PaperId { get; set; } = default!;

        [JsonPropertyName("payment_id")]
        public string PaymenId { get; set; } = default!;

        [JsonPropertyName("plate")]
        public string Plate { get; set; } = default!;

        [JsonPropertyName("price_status")]
        public string PriceStatus { get; set; } = default!;

        [JsonPropertyName("warning_price")]
        public string WarningPrice { get; set; } = default!;

    }
}
