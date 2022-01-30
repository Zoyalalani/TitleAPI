using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace TitleAPI.Models
{
    [ExcludeFromCodeCoverage]
    public class Participant
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string ParticipantType { get; set; }
    }
}
