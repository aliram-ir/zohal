using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Zohal.Attributes;

namespace Zohal.Models
{
    public sealed class VehicleInquiryTotalViolationsDetailsRequest
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

    public sealed class VehicleInquiryTotalViolationsDetailsResponse
    {
        [JsonPropertyName("final_price")]
        public string FinalPrice { get; set; } = default!;

        [JsonPropertyName("has_image")]
        public bool HasImage { get; set; }

        [JsonPropertyName("investigation_ability")]
        public bool InvestigationAbility { get; set; }

        [JsonPropertyName("paper_id")]
        public string PaperId { get; set; } = default!;

        [JsonPropertyName("payment_id")]
        public string PaymentId { get; set; } = default!;

        [JsonPropertyName("serial_no")]
        public string SerialNo { get; set; } = default!;

        [JsonPropertyName("violation_delivery_type")]
        public ViolationDeliveryTypeDto ViolationDeliveryType { get; set; } = default!;

        [JsonPropertyName("violation_occure_date")]
        public string ViolationOccureDate { get; set; } = default!;

        [JsonPropertyName("violation_occure_time")]
        public string ViolationOccureTime { get; set; } = default!;

        [JsonPropertyName("violation_type")]
        public ViolationTypeDto ViolationType { get; set; } = default!;

        [JsonPropertyName("violatoin_address")]
        public string ViolatoinAddress { get; set; } = default!;

        [JsonPropertyName("warning_id")]
        public string WarningId { get; set; } = default!;
    }

    public sealed class ViolationDeliveryTypeDto
    {
        [JsonPropertyName("violation_delivery_type")]
        public string ViolationDeliveryType { get; set; } = default!;
    }

    public sealed class ViolationTypeDto
    {
        [JsonPropertyName("violation_type")]
        public string ViolationType { get; set; } = default!;

        [JsonPropertyName("violation_type_id")]
        public string ViolationTypeId { get; set; } = default!;
    }

    public sealed class VehicleInquiryTotalViolationsDetailsData
    {
        [JsonPropertyName("warnings")]
        public List<VehicleInquiryTotalViolationsDetailsResponse> Warnings { get; set; } = new();
    }

}
