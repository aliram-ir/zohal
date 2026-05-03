using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Zohal.Attributes;

/// <summary>
/// اعتبارسنجی شماره کارت بانکی ایران
/// </summary>
public sealed class IranianCardNumberAttribute : ValidationAttribute
{
    private static readonly Regex CardRegex =
        new(@"^\d{16}$", RegexOptions.Compiled);

    public IranianCardNumberAttribute()
    {
        ErrorMessage = "شماره کارت معتبر نیست.";
    }

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value is null)
            return ValidationResult.Success;

        var card = value.ToString()!.Replace(" ", "");

        // بررسی فرمت
        if (!CardRegex.IsMatch(card))
            return new ValidationResult(ErrorMessage);

        // بررسی الگوریتم Luhn
        if (!IsValidLuhn(card))
            return new ValidationResult(ErrorMessage);

        return ValidationResult.Success;
    }

    /// <summary>
    /// بررسی الگوریتم Luhn برای کارت بانکی
    /// </summary>
    private static bool IsValidLuhn(string number)
    {
        int sum = 0;
        bool alternate = false;

        for (int i = number.Length - 1; i >= 0; i--)
        {
            int n = number[i] - '0';

            if (alternate)
            {
                n *= 2;
                if (n > 9)
                    n -= 9;
            }

            sum += n;
            alternate = !alternate;
        }

        return sum % 10 == 0;
    }
}
