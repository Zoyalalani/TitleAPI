using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace TitleAPI.Models
{

    [ExcludeFromCodeCoverage]
    public class TitleGenre
    {
        [Key]
        public int Id { get; set; }
        public int TitleId { get; set; }
        public int GenreId { get; set; }
        public virtual Title Title { get; set; }

    }
}
