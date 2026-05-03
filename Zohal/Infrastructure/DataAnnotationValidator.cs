using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Zohal.Abstractions;
using Zohal.Core;

namespace Zohal.Infrastructure;

/// <summary>
/// اعتبارسنجی مدل‌ها با استفاده از DataAnnotation
/// (هماهنگ با الگوی Soft-Error و پشتیبانی از Metadata)
/// </summary>
internal sealed class DataAnnotationValidator : IZohalRequestValidator
{
    public ZohalError? Validate<T>(T model)
    {
        // مدل null است → خطای اعتبارسنجی
        if (model is null)
            return ZohalError.Validation(
                message: "The request model cannot be null.",
                metadata: new Dictionary<string, object>
                {
                    ["error"] = "null_model"
                });

        var context = new ValidationContext(model);
        var results = new List<ValidationResult>();

        var isValid = Validator.TryValidateObject(
            model,
            context,
            results,
            validateAllProperties: true);

        // اگر معتبر باشد → بدون خطا
        if (isValid)
            return null;

        // پیام نهایی اعتبارسنجی ترکیبی
        var message = string.Join(" | ", results.Select(r => r.ErrorMessage));

        // ساخت Metadata شامل خطاهای دقیق هر پراپرتی
        var metadata = new Dictionary<string, object>
        {
            ["errors"] = results
                .Select(r => new
                {
                    message = r.ErrorMessage,
                    members = r.MemberNames.ToArray()
                })
                .ToArray()
        };

        return ZohalError.Validation(
            message: message,
            metadata: metadata);
    }
}
