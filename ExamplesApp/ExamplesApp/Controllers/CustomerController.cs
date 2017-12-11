using ExamplesApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExamplesApp.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            var customer = GetCustomer();
            return View(customer.ToList());
        }

        public ActionResult Details(int id)
        {
            var detail = GetCustomer().SingleOrDefault(c => c.Id == id);
            return View(detail);
        }

        public IEnumerable<Customer> GetCustomer()
        {
            return  new List<Customer>()
            {
                new Customer {Id=1, Name ="John Smith"},
                new Customer {Id=2, Name ="Marry Williams"}
            };
        }
    }
}