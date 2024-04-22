using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MOTC.Models
{
    public class Category
    {
        public int GenreID { get; set; }
        public Genre Genre { get; set; }
        public int MovieID { get; set; }
        public Movies Movie { get; set; }
    }
}
