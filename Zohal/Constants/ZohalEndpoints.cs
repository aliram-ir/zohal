namespace Zohal.Constants;

/// <summary>
/// مسیر سرویس‌های زحل
/// </summary>
public static class ZohalEndpoints
{
    /// <summary>
    /// شاهکار (تطابق کد ملی و موبایل)​
    /// </summary>
    public const string NationalIdentityInquiry = "services/inquiry/national_identity_inquiry";

    /// <summary>
    /// تطابق کد ملی و شماره شبا​
    /// </summary>
    public const string ShahkarInquiry = "services/inquiry/shahkar";

    /// <summary>
    /// تطابق کد ملی و شماره شبا​
    /// </summary>
    public const string CheckIbanWithNationalCodeInquiry = "services/inquiry/check_iban_with_national_code";

    /// <summary>
    /// تطابق شماره کارت و کد ملی​
    /// </summary>
    public const string CheckCardWithNationalCodeInquiry = "services/inquiry/check_card_with_national_code";

    /// <summary>
    /// استعلام نام صاحب کارت​
    /// </summary>
    public const string CardInquiry = "services/inquiry/card_inquiry";

    /// <summary>
    /// تبدیل کارت به شبا​
    /// </summary>
    public const string CardToIban = "services/inquiry/card_to_iban";

    /// <summary>
    /// تبدیل حساب به شبا​
    /// </summary>
    public const string AccountToIban = "services/inquiry/account_to_iban";

    /// <summary>
    /// تطابق کارت و نام صاحب کارت​
    /// </summary>
    public const string CheckCardWithName = "services/inquiry/check_card_with_name";

    /// <summary>
    /// تطابق شبا و نام صاحب شبا​
    /// </summary>
    public const string CheckIbanWithName = "services/inquiry/check_iban_with_name";

    /// <summary>
    /// تبدیل کارت به حساب​
    /// </summary>
    public const string CardToAccount = "services/inquiry/card_to_account";

    /// <summary>
    /// استعلام شبا​
    /// </summary>
    public const string Iban = "services/inquiry/iban";

    /// <summary>
    /// استعلام چک صیادی​
    /// </summary>
    public const string CheckSayadInquiry = "services/inquiry/check_sayad_inquiry";

    /// <summary>
    /// استعلام چک برگشتی​
    /// </summary>
    public const string BouncedCheque = "services/inquiry/bounced_cheque";
}
