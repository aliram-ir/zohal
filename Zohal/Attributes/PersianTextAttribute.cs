using System;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.RegularExpressions;

namespace Zohal.Attributes;

/// <summary>
/// اعتبارسنجی متن فارسی
/// </summary>
public sealed class PersianTextAttribute : ValidationAttribute
{
    /// <summary>
    /// اجازه استفاده از فاصله
    /// </summary>
    public bool AllowSpace { get; set; } = true;

    /// <summary>
    /// اجازه استفاده از نیم فاصله
    /// </summary>
    public bool AllowHalfSpace { get; set; } = true;

    /// <summary>
    /// اجازه استفاده از عدد فارسی
    /// </summary>
    public bool AllowDigits { get; set; } = false;

    public PersianTextAttribute()
    {
        ErrorMessage = "متن باید فقط شامل حروف فارسی باشد.";
    }

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value is null)
            return ValidationResult.Success;

        var text = value.ToString()!.Trim();

        var pattern = BuildPattern();

        if (!Regex.IsMatch(text, pattern))
            return new ValidationResult(ErrorMessage);

        return ValidationResult.Success;
    }

    /// <summary>
    /// ساخت Regex بر اساس تنظیمات
    /// </summary>
    private string BuildPattern()
    {
        var builder = new StringBuilder();

        builder.Append("^[");
        builder.Append(@"\u0600-\u06FF");

        if (AllowDigits)
            builder.Append(@"\u06F0-\u06F9");

        if (AllowSpace)
            builder.Append(" ");

        if (AllowHalfSpace)
            builder.Append(@"\u200C");

        builder.Append("]+$");

        return builder.ToString();
    }
}
