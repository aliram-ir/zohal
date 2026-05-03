using System.Collections.Generic;
using System.Linq;

namespace Zohal.Core
{
    /// <summary>
    /// نمایش استاندارد خطا در SDK با پشتیبانی از InternalMessage و Metadata
    /// </summary>
    public sealed class ZohalError
    {
        /// <summary>
        /// کد خطا (شناسه قابل پردازش توسط سیستم)
        /// </summary>
        public string Code { get; }

        /// <summary>
        /// پیام خطای قابل نمایش به کاربر یا لاگ عمومی
        /// </summary>
        public string Message { get; }

        /// <summary>
        /// پیام داخلی (اختیاری) مخصوص لاگ و Exception
        /// </summary>
        public string? InternalMessage { get; }

        /// <summary>
        /// داده‌های اضافی خطا جهت Debug یا لاگ‌نویسی
        /// </summary>
        public Dictionary<string, object>? Metadata { get; }

        private ZohalError(
            string code,
            string message,
            string? internalMessage = null,
            Dictionary<string, object>? metadata = null)
        {
            Code = code;
            Message = message;
            InternalMessage = internalMessage;
            Metadata = metadata;
        }

        //===========================================================
        //  Validation Errors
        //===========================================================

        /// <summary>
        /// خطای اعتبارسنجی (بدون Metadata)
        /// </summary>
        public static ZohalError Validation(string message, string? internalMessage = null)
            => new("validation_error", message, internalMessage);

        /// <summary>
        /// خطای اعتبارسنجی همراه Metadata
        /// </summary>
        public static ZohalError Validation(
            string message,
            string? internalMessage,
            Dictionary<string, object>? metadata)
            => new("validation_error", message, internalMessage, metadata);

        /// <summary>
        /// خطای اعتبارسنجی همراه Metadata (نسخه ساده‌تر)
        /// </summary>
        public static ZohalError Validation(
            string message,
            Dictionary<string, object> metadata)
            => new("validation_error", message, null, metadata);

        //===========================================================
        //  HTTP Errors
        //===========================================================

        public static ZohalError Http(string message, string? internalMessage = null)
            => new("http_error", message, internalMessage);

        //===========================================================
        //  API Errors
        //===========================================================

        public static ZohalError Api(string message, string? internalMessage = null)
            => new("api_error", message, internalMessage);

        //===========================================================
        //  Unexpected Errors (Exception)
        //===========================================================

        public static ZohalError Unexpected(string message, string? internalMessage = null)
            => new("unexpected_error", message, internalMessage);

        //===========================================================
        //  Custom Errors
        //===========================================================

        public static ZohalError Custom(
            string code,
            string message,
            string? internalMessage = null,
            Dictionary<string, object>? metadata = null)
            => new(code, message, internalMessage, metadata);

        //===========================================================
        //  ToString برای لاگ‌نویسی
        //===========================================================

        public override string ToString()
        {
            var meta = (Metadata != null && Metadata.Count > 0)
                ? $" | Metadata={string.Join(", ", Metadata.Select(kv => $"{kv.Key}:{kv.Value}"))}"
                : "";

            return $"Code={Code} | Message={Message} | Internal={InternalMessage ?? "null"}{meta}";
        }
    }
}
