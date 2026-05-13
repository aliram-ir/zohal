using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Zohal.Enums;

namespace Zohal.Models
{
    public sealed class BillsRequest
    {
        /// <summary>
        /// شناسه قبض
        /// </summary>
        [JsonPropertyName("bill_id")]
        [Required]
        public string BillId { get; set; } = null!;

        /// <summary>
        /// در صورت نیاز انتخاب دستی نوع قبض
        /// </summary>
        [JsonIgnore]
        public UtilityBillType? BillType { get; set; }
    }
    public sealed class BillsResponse
    {
        /// <summary>
        /// شناسه قبض
        /// </summary>
        [JsonPropertyName("bill_id")]
        public string BillId { get; set; } = null!;

        /// <summary>
        /// مبلغ قبض
        /// </summary>
        [JsonPropertyName("amount")]
        public long Amount { get; set; }

        /// <summary>
        /// شناسه پرداخت
        /// </summary>
        [JsonPropertyName("payment_id")]
        public string PaymentId { get; set; } = null!;

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("address")]
        public string Address { get; set; } = null!;

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("consumption_type")]
        public string ConsumptionType { get; set; } = null!;

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("current_reading_date")]
        public string CurrentReadingDate { get; set; } = null!;

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("full_name")]
        public string FullName { get; set; } = null!;

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("payment_date")]
        public string paymentDate { get; set; } = null!;

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("previous_reading_date")]
        public string PreviousReadingDate { get; set; } = null!;
    }
}
