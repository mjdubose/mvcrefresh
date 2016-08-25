using System.Linq;
using System.Web.Mvc;
using Videly.Models;
using System.Data.Entity;

namespace Videly.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;
        public MoviesController()
        {
            _context= new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        //GET: Movies/Random
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
    }
}