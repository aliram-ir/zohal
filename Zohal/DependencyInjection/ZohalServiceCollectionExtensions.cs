using Microsoft.Extensions.DependencyInjection;
using System;
using Zohal.Abstractions;
using Zohal.Core;
using Zohal.Infrastructure;

namespace Zohal.DependencyInjection
{
    /// <summary>
    /// ثبت سرویس‌های SDK زحل در DI
    /// </summary>
    public static class ZohalServiceCollectionExtensions
    {
        public static IServiceCollection AddZohal(
            this IServiceCollection services,
            Action<ZohalOptions> configure)
        {
            // تنظیمات ZohalOptions
            var options = new ZohalOptions();
            configure(options);
            services.AddSingleton(options);

            // HttpClient اختصاصی زحل (Scoped بهترین انتخاب است)
            services.AddHttpClient<ZohalHttpExecutor>();

            // اعتبارسنجی ورودی‌ها
            services.AddSingleton<IZohalRequestValidator, DataAnnotationValidator>();

            // پارس JSON با Soft‑Error
            services.AddSingleton<ZohalResponseParser>();

            // Http Executor که HttpClient از DI دریافت می‌کند
            services.AddTransient<ZohalHttpExecutor>();

            // کلاینت اصلی زحل
            services.AddTransient<IZohalClient, ZohalClient>();

            return services;
        }
    }
}
