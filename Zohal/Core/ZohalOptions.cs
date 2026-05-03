namespace Zohal.Core;

/// <summary>
/// تنظیمات کلاینت زحل
/// </summary>
public sealed class ZohalOptions
{
    /// <summary>
    /// توکن دسترسی برای احراز هویت درخواست‌ها
    /// </summary>
    public string Token { get; set; } = default!;

    /// <summary>
    /// آدرس پایه API زحل
    /// </summary>
    public string BaseUrl { get; set; } =
        "https://service.zohal.io/api/v0/";
}
