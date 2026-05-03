using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Zohal.Attributes;

/// <summary>
/// اعتبارسنجی شناسه صیاد چک صیادی
/// </summary>
public sealed class SayadIdAttribute : ValidationAttribute
{
    private static readonly Regex Regex =
        new(@"^12\d{8}000000$", RegexOptions.Compiled);

    public SayadIdAttribute()
    {
        ErrorMessage = "شناسه صیاد نامعتبر است.";
    }

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value is null)
            return ValidationResult.Success;

        var sayadId = value.ToString()!.Trim();

        if (!Regex.IsMatch(sayadId))
            return new ValidationResult(ErrorMessage);

        return ValidationResult.Success;
    }
}
