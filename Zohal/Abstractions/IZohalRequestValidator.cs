using Zohal.Core;

namespace Zohal.Abstractions;

/// <summary>
/// قرارداد اعتبارسنجی درخواست‌های ورودی (Soft-Error)
/// </summary>
public interface IZohalRequestValidator
{
    /// <summary>
    /// اعتبارسنجی مدل ورودی. در صورت وجود خطا، ZohalError بازگردانده می‌شود.
    /// در غیر این صورت خروجی null یعنی موفقیت.
    /// </summary>
    ZohalError? Validate<T>(T model);
}
