using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Zohal.Attributes;

/// <summary>
/// اعتبارسنجی شماره شبا ایران
/// </summary>
public sealed class IranianIbanAttribute : ValidationAttribute
{
    private static readonly Regex IbanRegex =
        new(@"^IR\d{24}$", RegexOptions.Compiled);

    public IranianIbanAttribute()
    {
        ErrorMessage = "شماره شبا معتبر نیست.";
    }

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value is null)
            return ValidationResult.Success;

        var iban = value.ToString()!.Replace(" ", "").ToUpperInvariant();

        // بررسی فرمت اولیه
        if (!IbanRegex.IsMatch(iban))
            return new ValidationResult(ErrorMessage);

        // بررسی Checksum
        if (!IsValidIbanChecksum(iban))
            return new ValidationResult(ErrorMessage);

        return ValidationResult.Success;
    }

    /// <summary>
    /// بررسی الگوریتم IBAN mod-97
    /// </summary>
    private static bool IsValidIbanChecksum(string iban)
    {
        var rearranged = iban[4..] + iban[..4];

        var numeric = "";

        foreach (var ch in rearranged)
        {
            if (char.IsLetter(ch))
                numeric += (ch - 'A' + 10).ToString();
            else
                numeric += ch;
        }

        int remainder = 0;

        foreach (var c in numeric)
        {
            remainder = (remainder * 10 + (c - '0')) % 97;
        }

        return remainder == 1;
    }
}
