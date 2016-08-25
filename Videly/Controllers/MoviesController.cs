using System.Collections.Generic;
using System.Web.Mvc;
using Videly.Models;
using Videly.ViewModels;

namespace Videly.Controllers
{
    public class MoviesController : Controller
    {
        //GET: Movies/Random
        public ActionResult Index()
        {
            List<Movie> movie = new List<Movie>
            {
                new Movie() {Id = 1, Name = "Shrek"},
                new Movie {Id = 2, Name = "Wall-e"}
            };
           
            return View(movie);

        }

        public ActionResult Edit(int id)
        {
            return Content("id=" + id);
        }
        [Route("movies/released/{year}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }

    }
}