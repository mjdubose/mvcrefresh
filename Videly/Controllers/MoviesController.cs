using System;
using System.Linq;
using System.Web.Mvc;
using Videly.Models;
using System.Data.Entity;
using Videly.ViewModels;

namespace Videly.Controllers
{
    public class MoviesController : Controller
    {
        private readonly ApplicationDbContext _context;
        public MoviesController()
        {
            _context= new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
       
        public ActionResult Index()
        {
           
            var movies = _context.Movies.Include(c => c.Genre).ToList();
           
            return View(movies);

        }
        [Route("movies/details/{Id}")]
        public ActionResult Details(int Id)
        {
            var movie = _context.Movies.Include(c=>c.Genre).FirstOrDefault(x => x.Id == Id);

            if (movie == null)
            {
                return HttpNotFound();
            }

            return View(movie);
        }

        [Route("movies/edit/{id}")]
        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(c => c.Id == id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            var viewModel = new MovieGenreViewModel
            { Movie = movie,
            Genre = _context.Genres.ToList()
              
            };
            return View("MovieForm", viewModel);
        }
    

        [Route("movies/new/")]
        public ActionResult New()
        {
            var moviegenre = new MovieGenreViewModel
            {
                Genre = _context.Genres.ToList(),
                Movie = new Movie()
                
            };
            moviegenre.Movie.Name = "";




            return View("MovieForm", moviegenre);
        }
        [HttpPost]
        public ActionResult Save(Movie movie)
        {
          
            if (movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now;
                _context.Movies.Add(movie);
            }
            else
            {
                var movieToBeUpdated = _context.Movies.Single(m => m.Id == movie.Id);
                movieToBeUpdated.Name = movie.Name;
                movieToBeUpdated.GenreId = movie.GenreId;
                movieToBeUpdated.NumberInStock = movie.NumberInStock;
                movieToBeUpdated.ReleaseDate = movie.ReleaseDate;
                movieToBeUpdated.DateAdded = movie.DateAdded;
               
            }
            _context.SaveChanges();

            return RedirectToAction("Index", "Movies");
        }

       

    }
}