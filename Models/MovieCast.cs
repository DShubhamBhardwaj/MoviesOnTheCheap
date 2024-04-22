using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MOTC.Models
{
    public class MovieCast
    {
        //ActorID
        public int ActorID { get; set; }
        public Actors Actor { get; set; }
        //MovieName
        public int MoviesID { get; set; }
        public Movies Movie { get; set; }
        public string role { get; set; }

    }
}
