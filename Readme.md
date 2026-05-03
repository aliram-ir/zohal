# Zohal SDK

یک کتابخانه‌ی جامع و سازمان‌یافته برای ارتباط با API خدمات زحل با معماری Clean و رعایت اصول نصویر (SRP).

---

## ویژگی‌ها

- معماری پاک (Clean Architecture) برای جداسازی مسئولیت‌ها  
- مدیریت هزینه سرویس‌ها  
- پشتیبانی از خواندن تنظیمات ایمن (appsettings.json و Environment Variables)  
- قابلیت استفاده ساده و امن از تمام سرویس‌های زحل  
- الگوی Soft-Error برای مدیریت خطاها بدون پرتاب Exception ناخواسته  

---

## نصب

1. از طریق NuGet (در آینده)  
2. افزودن مستقیم پروژه به راهکار  

---

## راه‌اندازی

### 1) افزودن فایل `appsettings.json`

فایل `appsettings.json` را با تنظیمات زیر اضافه کنید:
```json
{
  "Zohal": {
"BaseUrl": "https://service.zohal.io/api/v0/",
"Token": "YOUR_API_TOKEN_HERE",
"ServiceCosts": {
"CheckSayadInquiry": 1300,
"CardToIban": 600
// سایر هزینه‌ها
}
  }
}


نکته: مقدار Token را با توکن واقعی خود جایگزین کنید.

2) پیکربندی پروژه و تزریق وابستگی‌ها
پروژه را به گونه‌ای پیکربندی کنید که تنظیمات مربوط به بخش Zohal خوانده شود و متدهای تزریق وابستگی (Dependency Injection) برای استفاده از کلاینت/سرویس‌ها فعال شوند.

خروجی نهایی باید طوری باشد که بتوانید از طریق serviceProvider به سرویس‌هایی مانند IZohalClient دسترسی داشته باشید.

نحوه استفاده
نمونه استفاده از کلاینت و ارسال درخواست:

csharp
var client = serviceProvider.GetRequiredService<IZohalClient>();
var result = await client.SendAsync<CheckSayadInquiryRequest, CheckSayadInquiryResponse>(request);

if(result.IsSuccess)
{
var data = result.Data;
// استفاده از داده‌ها
}
else
{
var error = result.Error;
// مدیریت خطا
}
توضیحات
متد SendAsync<TRequest, TResponse> برای ارسال درخواست از نوع مشخص و دریافت پاسخ با نوع مشخص استفاده می‌شود.

در رویکرد Soft-Error، به جای پرتاب Exception ناخواسته:

نتیجه معمولاً از طریق result.IsSuccess بررسی می‌شود.
در حالت موفق، داده‌ی پاسخ در result.Data قرار می‌گیرد.
در حالت ناموفق، اطلاعات خطا در result.Error قرار می‌گیرد.
Contribution
پیشنهادات خود را در قالب issue ارسال کنید یا از طریق pull request به پروژه کمک کنید.