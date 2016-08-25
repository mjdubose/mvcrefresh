using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Videly.Models;


namespace Videly.Controllers
{
    public class CustomerController : Controller
    {
        private List<TempCustomer> Customers = new List<TempCustomer> { new TempCustomer {Id =1, Name = "Fred Rogers"}, new TempCustomer {Id = 2, Name = "Wilma Rodgers"} };
        // GET: Customer
        public ActionResult Index()
        { 
            return View(Customers);
        }
        [Route("customer/details/{Id}")]
        public ActionResult Details(int Id)
        {
            var customer = Customers.FirstOrDefault(x => x.Id == Id);

            if (customer == null)
            {
                return HttpNotFound();
            }

            return View(customer);
        }
    }
}