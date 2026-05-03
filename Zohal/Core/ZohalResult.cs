namespace Zohal.Core
{
    /// <summary>
    /// الگوی Soft Error با پشتیبانی از TraceId و متادیتای خطا
    /// </summary>
    public sealed class ZohalResult<T>
    {
        /// <summary>
        /// آیا درخواست موفق بوده یا خیر
        /// </summary>
        public bool IsSuccess { get; }

        /// <summary>
        /// دادهٔ خروجی (در صورت موفقیت)
        /// </summary>
        public T? Data { get; }

        /// <summary>
        /// اطلاعات خطا (در صورت شکست)
        /// </summary>
        public ZohalError? Error { get; }

        /// <summary>
        /// شناسهٔ ردیابی درخواست (Trace ID)
        /// </summary>
        public string TraceId { get; }

        private ZohalResult(bool success, T? data, ZohalError? error, string traceId)
        {
            IsSuccess = success;
            Data = data;
            Error = error;
            TraceId = traceId;
        }

        //===========================================================
        //                     سازندگان استاندارد
        //===========================================================

        /// <summary>
        /// موفقیت با داده
        /// </summary>
        public static ZohalResult<T> Success(T data, string traceId)
            => new(true, data, null, traceId);

        /// <summary>
        /// موفقیت بدون داده (برای عملیات‌هایی که فقط OK هستند)
        /// </summary>
        public static ZohalResult<T> Success(string traceId)
            => new(true, default, null, traceId);

        /// <summary>
        /// شکست همراه با خطا
        /// </summary>
        public static ZohalResult<T> Failure(ZohalError error, string traceId)
            => new(false, default, error, traceId);

        //===========================================================
        //        نمایش مناسب برای لاگ کردن نتایج (Log Friendly)
        //===========================================================

        public override string ToString()
        {
            if (IsSuccess)
                return $"Success | TraceId={TraceId} | DataType={typeof(T).Name}";

            return $"Failure | TraceId={TraceId} | Error={Error}";
        }
    }
}
