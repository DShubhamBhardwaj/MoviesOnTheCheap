using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MOTC.Data;
using MOTC.Models;
using MOTC.Repository.Interface;
using MOTC.ViewModels;

namespace MOTC.Controllers
{
    public class MoviesController : Controller
    {
        private readonly MovieContext _context;
        private readonly IMovieDetailsRepository<MovieDetails> _movieDetails;
        private readonly IWebHostEnvironment _webHostEnvironment;


        public MoviesController(MovieContext context, IWebHostEnvironment webHostEnvironment, IMovieDetailsRepository<MovieDetails> movieDetails)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
            _movieDetails = movieDetails;
        }

        // GET: Movies
        public async Task<IActionResult> Index()
        {
            var movieContext = _context.Movies.Include(m => m.Director).Include(m => m.Producer);
            return View(await movieContext.ToListAsync());
        }

        // GET: Movies/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{

        //    var movie = await _context.Movies.Include(m => m.Director).Include(m => m.Producer)
        //        .FirstOrDefaultAsync(m => m.MovieID == id);
        //    List<MovieCast> cast =  _context.MovieCast.Where(c => c.MoviesID == id).ToList();
        //    MovieDetails result = new MovieDetails()
        //    {
        //        MovieName = movie.MovieName,
        //        movieID = movie.MovieID,
        //        RealeaseDate = movie.RealeaseDate,
        //        Description = movie.Description,
        //        Image = movie.Image,
        //        MovieCast = cast,
        //        ProducersName = movie.Producer.ProducersName,
        //        DirectorName = movie.Director.DirectorName,
        //    };
        //    return View(result);
        //}

        public IActionResult Details(int id)
        {
            try
            {
                var response = _movieDetails.GetDetailsById(id);
                return View(response);
            }
            catch(Exception ex)
            {
                return null;
            }
            
            
            
        }

        // GET: Movies/Create
        public IActionResult Create()
        {
            IEnumerable<SelectListItem> ProducersDropdown = _context.Producers.Select(i => new SelectListItem
            {
                Text = i.ProducersName,
                Value= i.ProducerID.ToString()
                
            });

            ViewBag.ProducersDropdown = ProducersDropdown;

            IEnumerable<SelectListItem> DirectorsDropdown = _context.Directors.Select(i => new SelectListItem
            {
                Text = i.DirectorName,
                Value = i.DirectorId.ToString()

            });

            ViewBag.DirectorsDropdown = DirectorsDropdown;

            IEnumerable<SelectListItem> ActorsDropdown = _context.Actors.Select(i => new SelectListItem
            {
                Text = i.ActorName,
                Value = i.ActorId.ToString()
            });
            ViewBag.ActorsDropdown = ActorsDropdown;

            IEnumerable<SelectListItem> GenreDropdown = _context.Genre.Select(i => new SelectListItem
            {
                Text = i.MovieGenre,
                Value=i.GenreID.ToString()
            });
            ViewBag.GenreDropdown = GenreDropdown;
            return View();
        }

      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IFormCollection formCollection)
        {
            List<string> Data = new List<string>();

            var files = HttpContext.Request.Form.Files;
            string webRootPath = _webHostEnvironment.WebRootPath;
            string upload = webRootPath + WebContants.ImagePath;
            string fileName = Guid.NewGuid().ToString();
            string extension = Path.GetExtension(files[0].FileName);

            using (var fileStream = new FileStream(Path.Combine(upload, fileName + extension), FileMode.Create))
            {
                files[0].CopyTo(fileStream);
            }

            Movies m = new Movies() ;
            
            Directors d = new Directors();
            Producers p = new Producers();
            string[] str= { },genre = { }, role = { }, actors = { }, gen = { }; 
            foreach (var item in formCollection)
            {
                switch (item.Key)
                {
                    case "MovieName":
                        m.MovieName = item.Value;
                        break;
                    case "Language":
                        m.Language = item.Value;
                        break;
                    case "RealeaseDate":
                        m.RealeaseDate = item.Value;
                        break;
                    case "Description":
                        m.Description = item.Value;
                        break;
                    case "ProducerID":
                        if (item.Value != "others")
                        {
                            m.ProducerID = Int16.Parse(item.Value);
                        }
                        break;
                    case "DirectorID":
                        if (item.Value != "others")
                        {
                            m.DirectorID = Int16.Parse(item.Value);
                        }
                        break;
                    case "Producer": 
                        if(item.Value != "")
                        {
                            p.ProducersName = item.Value;
                            _context.Producers.Add(p);
                            await _context.SaveChangesAsync();

                        }
                        break;
                    case "director":
                        if (item.Value != "")
                        {
                            d.DirectorName = item.Value;
                            _context.Directors.Add(d);
                            await _context.SaveChangesAsync();

                        }
                        break;
                    case "Actors":
                            string actorID = item.Value;
                            str = actorID.Split(",");
                            break;
                    case "role":
                        string roles = item.Value;
                        role = roles.Split(",");
                        break;
                    case "Actor":
                        string Actor = item.Value;
                        actors = Actor.Split(",");
                        break;
                    case "Gender":
                        string genders = item.Value;
                        gen = genders.Split(",");
                        break;
                    case "GenreList":
                        string genres = item.Value;
                        genre = genres.Split(",");
                        break;
                    default: break;
                }
            }
            if(m.ProducerID == 0)
            {
                var prodID = _context.Producers.FirstOrDefault(x => x.ProducersName == p.ProducersName);
                m.ProducerID = prodID.ProducerID;
            }
            if(m.DirectorID == 0)
            {
                var DirecID = _context.Directors.FirstOrDefault(x => x.DirectorName == d.DirectorName);
                m.DirectorID = DirecID.DirectorId;
            }
            
            m.Image = fileName + extension;
            _context.Movies.Add(m);
            await _context.SaveChangesAsync();

            var movieID = _context.Movies.FirstOrDefault(x => x.MovieName == m.MovieName);
            int MovieID = movieID.MovieID;

            for(int i=0; i< genre.Length;i++)
            {
                Category cat = new Category();
                cat.MovieID = MovieID;
                cat.GenreID = Int16.Parse(genre[i]);
                _context.Categories.Add(cat);
                await _context.SaveChangesAsync();
            }

            int countA = 0, countG = 0,count=0;
            foreach(var id in str)
            {
                MovieCast cast = new MovieCast();
                if (id != "others")
                {
                    cast.ActorID = Int16.Parse(id);
                    cast.MoviesID = MovieID;
                    cast.role = role[count];
                    _context.MovieCast.Add(cast);
                    await _context.SaveChangesAsync();
                    count++;
                }
                else
                {
                    Actors a = new Actors();
                    a.ActorName = actors[countA];
                    cast.role = role[count];
                    if (gen[countG] == "female")
                    {
                        a.Gender = Gender.Female;
                    }
                    else if(gen[countG] == "male")
                    {
                        a.Gender = Gender.Male;
                    }
                    else
                    {
                        a.Gender = Gender.Other;
                    }
                    _context.Actors.Add(a);
                    await _context.SaveChangesAsync();

                    var ActorID = _context.Actors.FirstOrDefault(x => x.ActorName == actors[countA]);
                    cast.ActorID= ActorID.ActorId;
                    cast.MoviesID = MovieID;
                    _context.MovieCast.Add(cast);
                    await _context.SaveChangesAsync();
                    countG++;
                    countA++;
                    count++;

                }

            }
            return RedirectToAction("Index");
        }

        // GET: Movies/Edit/5
        public async Task<IActionResult> Edit(int? id){ 
        
            if (id == null)
            {
                return NotFound();
            }

            var movies = await _context.Movies.FindAsync(id);
            if (movies == null)
            {
                return NotFound();
            }
            ViewData["DirectorID"] = new SelectList(_context.Directors, "DirectorId", "DirectorName", movies.DirectorID);
            ViewData["ProducerID"] = new SelectList(_context.Producers, "ProducerID", "ProducersName", movies.ProducerID);
            return View(movies);
        }

      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MovieID,MovieName,Language,RealeaseDate,Description,Image,ProducerID,DirectorID")] Movies movies)
        {
            if (id != movies.MovieID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(movies);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MoviesExists(movies.MovieID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["DirectorID"] = new SelectList(_context.Directors, "DirectorId", "DirectorName", movies.DirectorID);
            ViewData["ProducerID"] = new SelectList(_context.Producers, "ProducerID", "ProducersName", movies.ProducerID);
            return View(movies);
        }

        // GET: Movies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movies = await _context.Movies
                .Include(m => m.Director)
                .Include(m => m.Producer)
                .FirstOrDefaultAsync(m => m.MovieID == id);

            if (movies == null)
            {
                return NotFound();
            }

            return View(movies);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movies = await _context.Movies.FindAsync(id);

            string upload = _webHostEnvironment.WebRootPath + WebContants.ImagePath;
            var oldFile = Path.Combine(upload, movies.Image);
            if (System.IO.File.Exists(oldFile))
            {
                System.IO.File.Delete(oldFile);
            }
            _context.Movies.Remove(movies);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MoviesExists(int id)
        {
            return _context.Movies.Any(e => e.MovieID == id);
        }
    }
}
