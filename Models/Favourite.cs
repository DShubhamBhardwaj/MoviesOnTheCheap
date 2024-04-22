using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MOTC.Models
{
    public class Favourite
    {
        //UserName
        [Display(Name ="User ID")]
        public int UserID { get; set; }
        [ForeignKey("UserID")]
        public Users user { get; set; }
        //MovieName
        [Display(Name = "MovieID")]
        public int MovieID { get; set; }
        [ForeignKey("MovieID")]
        public Movies Movie { get; set; }


    }
}
