using MOTC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MOTC.ViewModels
{
    public class MovieDetails
    {
        public int id { get; set; }
        public int movieID { get; set; }
        public string MovieName { get; set; }
        public string Language { get; set; }
        public string RealeaseDate { get; set; }
        public string Description { get; set; }
        public List<string> MovieCasts { get; set; }
        public List<string> MovieGenre { get; set; }
        public string Image { get; set; }
        public string DirectorName { get; set; }
        public string ProducersName { get; set; }
       
    }
}
