using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Zohal.Attributes;

namespace Zohal.Models
{
    //تطابق کد ملی و شماره شبا​
    public sealed class CheckIbanWithNationalCodeRequest
    {
        /// <summary>
        /// تاریخ تولد شمسی
        /// </summary>
        [JsonPropertyName("birth_date")]
        [Required]
        [PersianBirthDate]
        public string BirthDate { get; set; } = default!;


        [JsonPropertyName("IBAN")]
        [Required]
        [IranianIban]
        public string Iban { get; set; } = default!;

        /// <summary>
        /// کد ملی
        /// </summary>
        [JsonPropertyName("national_code")]
        [Required]
        [NationalCode]
        public string NationalCode { get; set; } = default!;
    }

    public sealed class CheckIbanWithNationalCodeResponse
    {
        /// <summary>
        /// تطابق اطلاعات
        /// </summary>
        [JsonPropertyName("matched")]
        public bool Matched { get; set; }
    }
}
