using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Zohal.Attributes;

/// <summary>
/// اتربیوت اعتبارسنجی کد ملی ایرانی
/// </summary>
[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
public sealed class NationalCodeAttribute : ValidationAttribute
{
    public override bool IsValid(object? value)
    {
        if (value is not string nationalCode)
            return false;

        if (!Regex.IsMatch(nationalCode, @"^\d{10}$"))
            return false;

        // جلوگیری از ارقام تکراری
        if (new string(nationalCode[0], 10) == nationalCode)
            return false;

        int sum = 0;
        for (int i = 0; i < 9; i++)
            sum += (int)char.GetNumericValue(nationalCode[i]) * (10 - i);

        int remainder = sum % 11;
        int checkDigit = (int)char.GetNumericValue(nationalCode[9]);

        return remainder < 2
            ? checkDigit == remainder
            : checkDigit == 11 - remainder;
    }
}
