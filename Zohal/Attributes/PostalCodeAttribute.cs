using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Zohal.Attributes;

/// <summary>
/// اتربیوت اعتبارسنجی کد پستی ده رقمی ایران
/// </summary>
/// <remarks>
/// قوانین اعتبارسنجی:
/// ۱. دقیقاً ۱۰ رقم عددی باشد
/// ۲. همه ارقام تکراری نباشند (مثلاً 0000000000 یا 1111111111 نامعتبر)
/// ۳. رقم اول نباید 0 باشد (طبق الگوی متداول کدپستی‌های رسمی)
/// </remarks>
[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
public sealed class PostalCodeAttribute : ValidationAttribute
{
    public override bool IsValid(object? value)
    {
        // اگر مقدار خالی است، اعتبارسنجی را عبور می‌دهیم
        // تا در صورت نیاز با [Required] کنترل شود
        if (value is null)
            return true;

        if (value is not string postalCode)
            return false;

        postalCode = postalCode.Trim();

        // باید دقیقاً ۱۰ رقم باشد
        if (!Regex.IsMatch(postalCode, @"^\d{10}$"))
            return false;

        // رقم اول نباید 0 باشد
        if (postalCode[0] == '0')
            return false;

        // جلوگیری از ارقام تکراری (مثل 0000000000 یا 1111111111 و ...)
        if (new string(postalCode[0], 10) == postalCode)
            return false;

        return true;
    }
}
