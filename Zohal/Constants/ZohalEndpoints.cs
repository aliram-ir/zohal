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

    /// <summary>
    /// استعلام اعضای هیئت‌مدیره شرکت​
    /// </summary>
    public const string CompanyInquiryBoardMembers = "services/inquiry/company_inquiry/board_members";

    /// <summary>
    /// استعلام اطلاعات شرکت​
    /// </summary>
    public const string CompanyInquiry = "services/inquiry/company_inquiry";

    /// <summary>
    /// استعلام تاریخچه اعضای هیئت‌مدیره شرکت​
    /// </summary>
    public const string CompanyInquiryBoardMembersHistory = "services/inquiry/company_inquiry/board_members/history";

    /// <summary>
    /// استعلام کد پستی​
    /// </summary>
    public const string PostalCodeInquiry = "services/inquiry/postal_code_inquiry";

    /// <summary>
    /// استعلام خلافی خودرو​
    /// </summary>
    public const string VehicleInquiryTotalViolations = "services/inquiry/vehicle_inquiry/total_violations";

    /// <summary>
    /// استعلام خلافی خودرو با جزئیات​
    /// </summary>
    public const string VehicleInquiryTotalViolationsDetails = "services/inquiry/vehicle_inquiry/violations_details";

    /// <summary>
    /// استعلام Enamad​
    /// </summary>
    public const string EnamadInquiry = "services/inquiry/enamad_inquiry";

    /// <summary>
    /// OCR کارت ملی​
    /// </summary>
    public const string NationalCardOcr = "services/inquiry/national_card_ocr";

    /// <summary>
    /// OTP صوتی​
    /// </summary>
    public const string VoiceOtp = "services/inquiry/voice_otp";

    /// <summary>
    /// استعلام قبض رایتل​
    /// </summary>
    public const string RightelBill = "services/inquiry/bill/rightel";

    /// <summary>
    /// استعلام قبض همراه اول​
    /// </summary>
    public const string MciBill = "services/inquiry/bill/mci";

    /// <summary>
    /// استعلام قبض ایرانسل​
    /// </summary>
    public const string IrancellBill = "services/inquiry/bill/irancell";

    /// <summary>
    /// استعلام قبض تلفن ثابت​
    /// </summary>
    public const string FixedLineBill = "services/inquiry/bill/fixed_line";

    /// <summary>
    /// استعلام قبض گاز​
    /// </summary>
    public const string GasBill = "services/inquiry/bill/gas";

    /// <summary>
    /// استعلام قبض آب​
    /// </summary>
    public const string WaterBill = "services/inquiry/bill/water";

    /// <summary>
    /// استعلام قبض برق​
    /// </summary>
    public const string ElectricityBill = "services/inquiry/bill/electricity";

    ///// <summary>
    ///// 
    ///// </summary>
    //public const string ElectricityBill = "services/inquiry/bill/electricity";

    ///// <summary>
    ///// 
    ///// </summary>
    //public const string ElectricityBill = "services/inquiry/bill/electricity";

    ///// <summary>
    ///// 
    ///// </summary>
    //public const string ElectricityBill = "services/inquiry/bill/electricity";
}
