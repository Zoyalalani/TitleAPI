using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace TitleAPI.Models
{
    [ExcludeFromCodeCoverage]
    public class Genre
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

    }
}
