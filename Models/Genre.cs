using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MOTC.Models
{
    public class Genre
    {
        [Key]
        public int GenreID { get; set; }
        public string MovieGenre { get; set; }
        [Required]
        public IList<Category> MovieList { get; set; }
    }
}
