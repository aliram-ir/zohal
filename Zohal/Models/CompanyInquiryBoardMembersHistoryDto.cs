using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Zohal.Attributes;

namespace Zohal.Models
{
    public sealed class CompanyInquiryBoardMembersHistoryRequest
    {
        /// <summary>
        /// شناسه ملی شرکت
        /// </summary>
        [JsonPropertyName("national_id")]
        [Required]
        [NationalCompanyId]
        public string NationalId { get; set; } = default!;
    }

    public sealed class CompanyInquiryBoardMembersHistoryResponse
    {
        [JsonPropertyName("duration")]
        public string Duration { get; set; } = default!;

        [JsonPropertyName("end_date")]
        public string Enddate { get; set; } = default!;

        [JsonPropertyName("name")]
        public string Name { get; set; } = default!;

        [JsonPropertyName("position")]
        public string Position { get; set; } = default!;

        [JsonPropertyName("start_date")]
        public string StartDate { get; set; } = default!;
    }

    public sealed class CompanyInquiryBoardMembersHistoryData
    {
        [JsonPropertyName("company_title")]
        public string CompanyTitle { get; set; } = default!;

        [JsonPropertyName("board_members")]
        public List<CompanyInquiryBoardMembersHistoryResponse> BoardMembers { get; set; } = new();
    }
}
