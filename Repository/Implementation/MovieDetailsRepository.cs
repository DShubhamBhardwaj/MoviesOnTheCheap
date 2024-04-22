using Microsoft.EntityFrameworkCore;
using MOTC.Data;
using MOTC.Models;
using MOTC.Repository.Interface;
using MOTC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MOTC.Repository.Implementation
{
    public class MovieDetailsRepository : IMovieDetailsRepository<MovieDetails>
    {
        readonly MovieContext _movieContext;
        public MovieDetailsRepository(MovieContext movieContext)
        {
            _movieContext = movieContext;
        }
        public MovieDetails GetDetailsById(int id)
        {
            Movies movie = _movieContext.Movies.Include(m => m.Director).Include(m => m.Producer)
                .FirstOrDefault(m => m.MovieID == id);
            MovieDetails result = new MovieDetails()
            {
                MovieName = movie.MovieName,
                movieID = movie.MovieID,
                RealeaseDate = movie.RealeaseDate,
                Description = movie.Description,
                Image = movie.Image,
                ProducersName = movie.Producer.ProducersName,
                DirectorName = movie.Director.DirectorName,
                Language = movie.Language,
            };

            List <MovieCast> cast = _movieContext.MovieCast.Where(c => c.MoviesID == id).ToList();
            List<string> res = new List<string>();
            foreach (var i in cast)
            {
                Actors actors = _movieContext.Actors.FirstOrDefault(a => a.ActorId == i.ActorID);
                res.Add(actors.ActorName + " : " + i.role +", ");
            }

            result.MovieCasts = res;
            List<Category> movieGenre = _movieContext.Categories.Where(g => g.MovieID == id).ToList();
            List<string> cat = new List<string>();
            foreach(var i in movieGenre)
            {
                Genre genre = _movieContext.Genre.FirstOrDefault(g => g.GenreID == i.GenreID);
                cat.Add(genre.MovieGenre + ",");
            }
            result.MovieGenre = cat;
            
            return result;
        }
    }


}
