using System;
using System.ComponentModel.DataAnnotations;
using Zohal.Infrastructure;

namespace Zohal.Attributes
{
    /// <summary>
    /// اتربیوت اعتبارسنجی شماره پلاک خودرو ایران
    /// فرمت‌های ورودی مجاز:
    /// 11ب111
    /// 11 ب 111
    /// خروجی استاندارد در صورت نیاز: 11 ب 111
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public sealed class IranianPlateNumberAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            // اگر مقدار خالی باشد این اتربیوت خطا نمی‌دهد
            if (value is null)
                return ValidationResult.Success;

            if (value is not string plate)
                return new ValidationResult("فرمت شماره پلاک معتبر نیست.");

            if (!IranianPlateNormalizer.IsValid(plate))
                return new ValidationResult("فرمت شماره پلاک معتبر نیست.");

            return ValidationResult.Success;
        }
    }
}
