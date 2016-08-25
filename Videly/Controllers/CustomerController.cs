using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Videly.Models;
using System.Data.Entity;
using Videly.ViewModels;


namespace Videly.Controllers
{
    public class CustomerController : Controller
    {
        private ApplicationDbContext _context;

        public CustomerController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new ConstomerViewModel
            {
                MembershipTypes = membershipTypes
            };
            
            return View(viewModel);
        }
        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
            return RedirectToAction("Index","Customer");
        }

        // GET: Customer
        public ActionResult Index()
        {
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();
            return View(customers);
        }
        [Route("customer/details/{Id}")]
        public ActionResult Details(int Id)
        {
            var customer = _context.Customers.Include(c=>c.MembershipType).FirstOrDefault(x => x.Id == Id);

            if (customer == null)
            {
                return HttpNotFound();
            }

            return View(customer);
        }
    }
}