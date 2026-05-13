using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Zohal.Attributes;

namespace Zohal.Models
{
    public sealed class SimCardBillRequest
    {
        /// <summary>
        /// شماره موبایل
        /// </summary>
        [JsonPropertyName("mobile")]
        [Required]
        [IranianMobile]
        public string Mobile { get; set; } = default!;
    }

    public sealed class BillInquiryItem
    {
        /// <summary>
        /// مبلغ قبض
        /// </summary>

        [JsonPropertyName("amount")]
        public long Amount { get; set; }

        /// <summary>
        /// شناسه قبض
        /// </summary>
        [JsonPropertyName("bill_id")]
        public string BillId { get; set; } = null!;

        /// <summary>
        /// شناسه پرداخت
        /// </summary>
        [JsonPropertyName("payment_id")]
        public string PaymentId { get; set; } = null!;
    }

    public sealed class SimCardBillResponse
    {
        /// <summary>
        /// اطلاعات قبض میان‌مدت
        /// </summary>
        [JsonPropertyName("mid_term")]
        public BillInquiryItem? MidTerm { get; set; }

        /// <summary>
        /// اطلاعات قبض نهایی
        /// </summary>
        [JsonPropertyName("final_term")]
        public BillInquiryItem? FinalTerm { get; set; }
    }
}
