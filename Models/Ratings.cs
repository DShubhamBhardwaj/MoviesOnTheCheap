using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MOTC.Models
{
    public class Ratings
    {
        public int id { get; set; }
        //User Name
        [Display(Name ="User Name")]
        public int UserID { get; set; }
        [ForeignKey("UserID")]
        public Users User { get; set; }

        //Movie Name
        [Display(Name ="Movie Name")]
        public int MovieID { get; set; }
        [ForeignKey("Movie Name")]
        public Movies Movie { get; set; }
        // Rating
        [Range(1,10)]
        public int Rating { get; set; }
        //Review
        public String Review { get; set; }
    }
}
