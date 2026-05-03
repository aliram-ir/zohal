using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Zohal.Attributes;

namespace Zohal.Models;

public sealed class NationalIdentityInquiryRequest
{
    /// <summary>
    /// تاریخ تولد شمسی
    /// </summary>
    [JsonPropertyName("birth_date")]
    [Required]
    [PersianBirthDate]
    public string BirthDate { get; set; } = default!;

    /// <summary>
    /// کد ملی
    /// </summary>
    [JsonPropertyName("national_code")]
    [Required]
    [NationalCode]
    public string NationalCode { get; set; } = default!;
}

/// <summary>
/// DTO خروجی استعلام اطلاعات هویتی
/// </summary>
public sealed class NationalIdentityInquiryResponse
{
    /// <summary>
    /// زنده بودن
    /// </summary>
    [JsonPropertyName("alive")]
    public bool Alive { get; set; }

    /// <summary>
    /// نام پدر
    /// </summary>
    [JsonPropertyName("father_name")]
    public string? FatherName { get; set; }

    /// <summary>
    /// نام
    /// </summary>
    [JsonPropertyName("first_name")]
    public string? FirstName { get; set; }

    /// <summary>
    /// نام خانوادگی
    /// </summary>
    [JsonPropertyName("last_name")]
    public string? LastName { get; set; }

    /// <summary>
    /// فوت شده
    /// </summary>
    [JsonPropertyName("is_dead")]
    public bool IsDead { get; set; }

    /// <summary>
    /// تطابق اطلاعات
    /// </summary>
    [JsonPropertyName("matched")]
    public bool Matched { get; set; }

    /// <summary>
    /// کد ملی
    /// </summary>
    [JsonPropertyName("national_code")]
    public string? NationalCode { get; set; }
}
