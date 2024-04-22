using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MOTC.Models
{
    public class Movies
    {
        [Key]
        public int MovieID { get; set; }
        [Required]
        public string MovieName { get; set; }
        public string Language { get; set; }
        [Required]
        public string  RealeaseDate { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Image { get; set; }
        //Producers
        [Display(Name = "Producer")]
        public int ProducerID { get; set; }
        [ForeignKey("ProducerID")]
        public Producers Producer { get; set; }
        //Director
        [Display(Name = "Director")]
        public int DirectorID { get; set; }
        [ForeignKey("DirectorID")]
        public Directors Director { get; set; }
        //genreList
        public ICollection<Category> GenreList { get; set; }
        //ActorsList
        public ICollection<MovieCast> Actor { get; set; }

    }
}
