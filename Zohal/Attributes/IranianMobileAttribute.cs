using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Zohal.Attributes;

/// <summary>
/// اتربیوت اعتبارسنجی شماره موبایل ایران
/// </summary>
[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
public sealed class IranianMobileAttribute : ValidationAttribute
{
    public override bool IsValid(object? value)
    {
        if (value is not string mobile)
            return false;

        // فرمت: 09xxxxxxxxx
        return Regex.IsMatch(mobile, @"^09\d{9}$");
    }
}
