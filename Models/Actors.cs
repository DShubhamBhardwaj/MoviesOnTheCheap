using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MOTC.Models
{
    public enum Gender
    {
        Male,
        Female,
        Other,
    }
    public class Actors
    {
        [Key]
        public int ActorId { get; set; }
        [Required]
        public string ActorName { get; set; }
        public Gender Gender { get; set; }
        public IList<MovieCast> Movie { get; set; }
    }
}
