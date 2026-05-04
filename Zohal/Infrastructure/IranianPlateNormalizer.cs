using System.Text.RegularExpressions;

namespace Zohal.Infrastructure
{
    /// <summary>
    /// ابزار کمکی برای اعتبارسنجی و نرمال‌سازی پلاک خودروهای ایرانی
    /// </summary>
    public static class IranianPlateNormalizer
    {
        // الگوی پلاک: دو رقم + حرف فارسی + سه رقم (با فاصله یا بدون فاصله)
        private static readonly Regex PlateRegex = new(
            @"^(\d{2})\s*([ابپتثجچحخدذرزژسشصضطظعغفقکگلمنوهی])\s*(\d{3})$",
            RegexOptions.Compiled);

        /// <summary>
        /// بررسی معتبر بودن پلاک
        /// </summary>
        public static bool IsValid(string? plate)
        {
            if (string.IsNullOrWhiteSpace(plate))
                return false;

            plate = plate.Trim();

            return PlateRegex.IsMatch(plate);
        }

        /// <summary>
        /// تبدیل پلاک به فرمت استاندارد: 11 ب 111
        /// </summary>
        public static string? Normalize(string? plate)
        {
            if (string.IsNullOrWhiteSpace(plate))
                return null;

            plate = plate.Trim();

            var match = PlateRegex.Match(plate);

            if (!match.Success)
                return null;

            var part1 = match.Groups[1].Value;
            var letter = match.Groups[2].Value;
            var part2 = match.Groups[3].Value;

            return $"{part1} {letter} {part2}";
        }
    }
}
