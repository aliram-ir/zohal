using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Zohal.Attributes;

namespace Zohal.Models;

public sealed class ShahkarInquiryRequest
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
}

public sealed class ShahkarInquiryResponse
{
    /// <summary>
    /// تطابق اطلاعات
    /// </summary>
    [JsonPropertyName("matched")]
    public bool Matched { get; set; }
}
