using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Zohal.Attributes;

namespace Zohal.Models
{
    //تطابق شماره کارت و کد ملی​
    public sealed class CheckCardWithNationalCodeRequest
    {
        /// <summary>
        /// تاریخ تولد شمسی
        /// </summary>
        [JsonPropertyName("birth_date")]
        [Required]
        [PersianBirthDate]
        public string BirthDate { get; set; } = default!;


        [JsonPropertyName("card_number")]
        [Required]
        [IranianCardNumber]
        public string CardNumber { get; set; } = default!;

        /// <summary>
        /// کد ملی
        /// </summary>
        [JsonPropertyName("national_code")]
        [Required]
        [NationalCode]
        public string NationalCode { get; set; } = default!;
    }
    public sealed class CheckCardWithNationalCodeResponse
    {
        /// <summary>
        /// تطابق اطلاعات
        /// </summary>
        [JsonPropertyName("matched")]
        public bool Matched { get; set; }
    }
}
