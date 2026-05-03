using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Zohal.Attributes;

/// <summary>
/// اتربیوت اعتبارسنجی تاریخ تولد شمسی با فرمت yyyy/MM/dd
/// مثال: 1370/01/23
/// </summary>
[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
public sealed class PersianBirthDateAttribute : ValidationAttribute
{
    // الگوی فرمت: چهار رقم / دو رقم / دو رقم (مثلاً 1370/01/23)
    // در اینجا فقط ساختار فرمت بررسی می‌شود و سپس اعتبار خود تاریخ.
    private static readonly Regex DateRegex =
        new(@"^\d{4}/\d{2}/\d{2}$", RegexOptions.Compiled);

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value is null)
            return ValidationResult.Success; // اگر Required است، جداگانه با [Required] کنترل می‌شود

        if (value is not string birthDate)
            return new ValidationResult(GetErrorMessage(validationContext));

        // بررسی فرمت کلی yyyy/MM/dd
        if (!DateRegex.IsMatch(birthDate))
            return new ValidationResult(GetErrorMessage(validationContext));

        var parts = birthDate.Split('/');

        if (!int.TryParse(parts[0], out var year) ||
            !int.TryParse(parts[1], out var month) ||
            !int.TryParse(parts[2], out var day))
        {
            return new ValidationResult(GetErrorMessage(validationContext));
        }

        // بررسی محدوده سال (۱۳۰۰ تا ۱۴۹۹ مثلاً)
        if (year < 1300 || year > 1499)
            return new ValidationResult(GetErrorMessage(validationContext));

        // بررسی محدوده ماه
        if (month < 1 || month > 12)
            return new ValidationResult(GetErrorMessage(validationContext));

        // بررسی روز بر اساس تقویم شمسی ساده‌شده
        // ماه‌های ۱ تا ۶: ۳۱ روز
        // ماه‌های ۷ تا ۱۱: ۳۰ روز
        // ماه ۱۲: ۲۹ یا ۳۰ (اینجا ۲۹ می‌گیریم و ساده‌سازی می‌کنیم)
        int maxDay;
        if (month <= 6)
            maxDay = 31;
        else if (month <= 11)
            maxDay = 30;
        else
            maxDay = 29;

        if (day < 1 || day > maxDay)
            return new ValidationResult(GetErrorMessage(validationContext));

        return ValidationResult.Success;
    }

    private string GetErrorMessage(ValidationContext context)
    {
        // پیام خطا به فارسی
        return ErrorMessage ??
               $"مقدار فیلد '{context.MemberName}' یک تاریخ شمسی معتبر با فرمت yyyy/MM/dd (مثال: 1370/01/23) نیست.";
    }
}
