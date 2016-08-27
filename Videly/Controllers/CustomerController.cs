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
            var viewModel = new CustomerFormViewModel
            {
                MembershipTypes = membershipTypes
            };
            
            return View("CustomerForm",viewModel);
        }
        [HttpPost]
        public ActionResult Save(Customer customer)
        {
            if (customer.Id == 0)
            {
                _context.Customers.Add(customer);
            }
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);
                customerInDb.Name = customer.Name;
                customerInDb.Birthdate = customer.Birthdate;
                customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
                customerInDb.MembershipTypeId = customerInDb.MembershipTypeId;
            }
            _context.SaveChanges();
            return RedirectToAction("Index","Customer");
        }
        [Route("customer/edit/{id}")]
        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,MembershipTypes = _context.MembershipTypes.ToList()
            };
            return View("CustomerForm",viewModel);
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