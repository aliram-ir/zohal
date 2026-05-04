using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Zohal.Attributes
{
    /// <summary>
    /// اعتبارسنجی آدرس سایت (دامنه معتبر با یا بدون http/https)
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    public sealed class WebsiteUrlAttribute : ValidationAttribute
    {
        // الگوی دامنه با پشتیبانی از schema اختیاری (http / https) و www
        private static readonly Regex _regex = new(
            @"^(https?:\/\/)?(www\.)?([a-zA-Z0-9-]+\.)+[a-zA-Z]{2,}$",
            RegexOptions.Compiled | RegexOptions.IgnoreCase);

        public WebsiteUrlAttribute()
            : base("آدرس وب‌سایت وارد شده معتبر نیست.")
        {
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null)
                return ValidationResult.Success;

            var url = value.ToString()?.Trim();
            if (string.IsNullOrEmpty(url))
                return ValidationResult.Success;

            // بررسی با Regex
            if (_regex.IsMatch(url))
                return ValidationResult.Success;

            return new ValidationResult(ErrorMessage);
        }
    }
}
