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
        /*
        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.Include(c => c.MembershipType).FirstOrDefault(x => x.Id == Id);

            if (customer == null)
            {
                return HttpNotFound();
            }
        }
        
    */
    }
}