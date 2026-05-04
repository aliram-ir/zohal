using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Zohal.Attributes;

/// <summary>
/// اتربیوت اعتبارسنجی شناسه ملی اشخاص حقوقی ایران
/// </summary>
[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
public sealed class NationalCompanyIdAttribute : ValidationAttribute
{
    public override bool IsValid(object? value)
    {
        if (value is not string companyId)
            return false;

        // بررسی 11 رقمی بودن
        if (!Regex.IsMatch(companyId, @"^\d{11}$"))
            return false;

        // جلوگیری از ارقام تکراری
        if (new string(companyId[0], 11) == companyId)
            return false;

        int checkDigit = companyId[10] - '0';
        int sum = 0;

        int[] weights = { 29, 27, 23, 19, 17 };

        for (int i = 0; i < 10; i++)
        {
            int digit = companyId[i] - '0';
            int weight = weights[i % 5];
            sum += digit * weight;
        }

        int remainder = sum % 11;

        if (remainder == 10)
            remainder = 0;

        return checkDigit == remainder;
    }
}
