using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Zohal.Attributes;

namespace Zohal.Models
{
    public sealed class VoiceOtpRequest
    {
        /// <summary>
        /// شماره موبایل
        /// </summary>
        [JsonPropertyName("mobile")]
        [Required]
        [IranianMobile]
        public string Mobile { get; set; } = default!;

        /// <summary>
        /// Code
        /// </summary>
        [JsonPropertyName("code")]
        [Required]
        public string Code { get; set; } = default!;
    }
    public sealed class VoiceOtpResponse
    {
    }
}
