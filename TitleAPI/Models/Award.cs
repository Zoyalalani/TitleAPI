using System.Diagnostics.CodeAnalysis;

namespace TitleAPI.Models
{
    [ExcludeFromCodeCoverage]
    public class Award
    {
        public int TitleId { get; set; }
        public string AwardWon { get; set; }
        public string AwardYear { get; set; }
        public string AwardCompany { get; set; }
        public int? Id { get; set; }
        public virtual Title Title { get; set; }

    }
}
