using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MOTC.Data;
using MOTC.Models;
using MOTC.Repository.Interface;
using MOTC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MOTC.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class APIController : ControllerBase
    {
        private readonly MovieContext _Moviecontext;
        private readonly IMovieDetailsRepository<MovieDetails> _movieDetails;
        public APIController(MovieContext movieContext, IMovieDetailsRepository<MovieDetails> movieDetails)
        {
            _Moviecontext = movieContext;
            _movieDetails = movieDetails;
        }
        // GET: api/<APIController>
        [HttpGet]
        public IEnumerable<Movies> Get()
        {
            IEnumerable<Movies> movies = _Moviecontext.Movies.Include(m => m.Director).Include(m => m.Producer);
            return movies;
        }

        // GET api/<APIController>/5
        [HttpGet("{id}")]
        public MovieDetails Get(int id)
        {
            try
            {
                var response = _movieDetails.GetDetailsById(id);
                return response;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }
}
