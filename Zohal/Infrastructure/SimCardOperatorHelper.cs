using System.Collections.Generic;
using Zohal.Enums;

namespace Zohal.Infrastructure
{
    /// <summary>
    /// اطلاعات اپراتور سیم‌کارت / تلفن
    /// </summary>
    public sealed class SimCardOperatorInfo
    {
        /// <summary>
        /// نوع اپراتور
        /// </summary>
        public SimCardOperatorType Type { get; init; }

        /// <summary>
        /// نام فارسی اپراتور
        /// </summary>
        public string PersianName { get; init; } = string.Empty;

        /// <summary>
        /// نام انگلیسی اپراتور
        /// </summary>
        public string EnglishName { get; init; } = string.Empty;

        /// <summary>
        /// کلید آیکن اپراتور برای استفاده در UI
        /// </summary>
        public string IconKey { get; init; } = string.Empty;
    }

    /// <summary>
    /// هلپر تشخیص اپراتور سیم‌کارت و تلفن ثابت
    /// </summary>
    public static class SimCardOperatorHelper
    {
        /// <summary>
        /// لیست پیش‌شماره‌ها و اپراتورها
        /// </summary>
        private static readonly Dictionary<string, SimCardOperatorType> Prefixes = new()
        {
            // همراه اول
            ["0910"] = SimCardOperatorType.HamrahAval,
            ["0911"] = SimCardOperatorType.HamrahAval,
            ["0912"] = SimCardOperatorType.HamrahAval,
            ["0913"] = SimCardOperatorType.HamrahAval,
            ["0914"] = SimCardOperatorType.HamrahAval,
            ["0915"] = SimCardOperatorType.HamrahAval,
            ["0916"] = SimCardOperatorType.HamrahAval,
            ["0917"] = SimCardOperatorType.HamrahAval,
            ["0918"] = SimCardOperatorType.HamrahAval,
            ["0919"] = SimCardOperatorType.HamrahAval,
            ["0990"] = SimCardOperatorType.HamrahAval,
            ["0991"] = SimCardOperatorType.HamrahAval,

            // ایرانسل
            ["0901"] = SimCardOperatorType.Irancell,
            ["0902"] = SimCardOperatorType.Irancell,
            ["0903"] = SimCardOperatorType.Irancell,
            ["0904"] = SimCardOperatorType.Irancell,
            ["0905"] = SimCardOperatorType.Irancell,
            ["0930"] = SimCardOperatorType.Irancell,
            ["0933"] = SimCardOperatorType.Irancell,
            ["0935"] = SimCardOperatorType.Irancell,
            ["0936"] = SimCardOperatorType.Irancell,
            ["0937"] = SimCardOperatorType.Irancell,
            ["0938"] = SimCardOperatorType.Irancell,
            ["0939"] = SimCardOperatorType.Irancell,
            ["0941"] = SimCardOperatorType.Irancell,

            // رایتل
            ["0920"] = SimCardOperatorType.Rightel,
            ["0921"] = SimCardOperatorType.Rightel,
            ["0922"] = SimCardOperatorType.Rightel,

            // شاتل موبایل
            ["0998"] = SimCardOperatorType.ShatelMobile,

            // تالیا
            ["0932"] = SimCardOperatorType.Taliya,

            // سامانتل
            ["0999"] = SimCardOperatorType.Samantel,

            // آذرتل
            ["0997"] = SimCardOperatorType.Azartel,

            // انارستان
            ["0994"] = SimCardOperatorType.Anarestan
        };

        /// <summary>
        /// اطلاعات اپراتورها
        /// </summary>
        private static readonly Dictionary<SimCardOperatorType, SimCardOperatorInfo> Operators = new()
        {
            [SimCardOperatorType.HamrahAval] = new()
            {
                Type = SimCardOperatorType.HamrahAval,
                PersianName = "همراه اول",
                EnglishName = "Hamrah Aval",
                IconKey = "hamrahaval"
            },

            [SimCardOperatorType.Irancell] = new()
            {
                Type = SimCardOperatorType.Irancell,
                PersianName = "ایرانسل",
                EnglishName = "Irancell",
                IconKey = "irancell"
            },

            [SimCardOperatorType.Rightel] = new()
            {
                Type = SimCardOperatorType.Rightel,
                PersianName = "رایتل",
                EnglishName = "Rightel",
                IconKey = "rightel"
            },

            [SimCardOperatorType.ShatelMobile] = new()
            {
                Type = SimCardOperatorType.ShatelMobile,
                PersianName = "شاتل موبایل",
                EnglishName = "Shatel Mobile",
                IconKey = "shatel"
            },

            [SimCardOperatorType.Taliya] = new()
            {
                Type = SimCardOperatorType.Taliya,
                PersianName = "تالیا",
                EnglishName = "Taliya",
                IconKey = "taliya"
            },

            [SimCardOperatorType.Samantel] = new()
            {
                Type = SimCardOperatorType.Samantel,
                PersianName = "سامانتل",
                EnglishName = "Samantel",
                IconKey = "samantel"
            },

            [SimCardOperatorType.Azartel] = new()
            {
                Type = SimCardOperatorType.Azartel,
                PersianName = "آذرتل",
                EnglishName = "Azartel",
                IconKey = "azartel"
            },

            [SimCardOperatorType.Anarestan] = new()
            {
                Type = SimCardOperatorType.Anarestan,
                PersianName = "انارستان",
                EnglishName = "Anarestan",
                IconKey = "anarestan"
            },

            [SimCardOperatorType.FixedLine] = new()
            {
                Type = SimCardOperatorType.FixedLine,
                PersianName = "تلفن ثابت",
                EnglishName = "Fixed Line",
                IconKey = "fixedline"
            },

            [SimCardOperatorType.Unknown] = new()
            {
                Type = SimCardOperatorType.Unknown,
                PersianName = "نامشخص",
                EnglishName = "Unknown",
                IconKey = "unknown"
            }
        };

        /// <summary>
        /// تشخیص اپراتور شماره
        /// </summary>
        /// <param name="phoneNumber">شماره موبایل یا تلفن ثابت</param>
        /// <returns>اطلاعات اپراتور</returns>
        public static SimCardOperatorInfo DetectOperator(string phoneNumber)
        {
            if (string.IsNullOrWhiteSpace(phoneNumber))
                return Operators[SimCardOperatorType.Unknown];

            phoneNumber = NormalizePhoneNumber(phoneNumber);

            // تشخیص موبایل
            if (phoneNumber.Length == 11 && phoneNumber.StartsWith("09"))
            {
                var prefix = phoneNumber[..4];

                if (!Prefixes.TryGetValue(prefix, out var type))
                    type = SimCardOperatorType.Unknown;

                return Operators[type];
            }

            // تشخیص تلفن ثابت
            if (phoneNumber.Length >= 10 &&
                phoneNumber.StartsWith("0") &&
                !phoneNumber.StartsWith("09"))
            {
                return Operators[SimCardOperatorType.FixedLine];
            }

            return Operators[SimCardOperatorType.Unknown];
        }

        /// <summary>
        /// نرمال‌سازی شماره تلفن
        /// </summary>
        private static string NormalizePhoneNumber(string phoneNumber)
        {
            phoneNumber = phoneNumber
                .Trim()
                .Replace(" ", string.Empty)
                .Replace("-", string.Empty);

            if (phoneNumber.StartsWith("+98"))
            {
                phoneNumber = "0" + phoneNumber[3..];
            }
            else if (phoneNumber.StartsWith("98"))
            {
                phoneNumber = "0" + phoneNumber[2..];
            }

            return phoneNumber;
        }
    }
}
