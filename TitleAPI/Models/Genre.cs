using System.Collections.Generic;
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
        public virtual ICollection<TitleGenre> TitleGenres { get; set; }

    }
}
