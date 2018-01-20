using ExamplesApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using ExamplesApp.ViewModel;
using System.Runtime.Caching;

namespace ExamplesApp.Controllers
{
    public class CustomerController : Controller
    {
        private ApplicationDbContext _context;

        public CustomerController()
        {
            // we created object from our database 
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Customer
        public ViewResult Index()
        {
            // we got the customer list from the object what we created above

            // var customer = _context.Customers.Include(m => m.MemberShipType).ToList();
            if (MemoryCache.Default["Genres"] == null)
            {
                MemoryCache.Default["Genres"] = _context.Genre.ToList();
            }
            var genres = MemoryCache.Default["Genres"] as IEnumerable<Genre>;

            return View();
        }

        public ActionResult New()
        {
            var membershipType = _context.MemberShipType.ToList();

            var viewModel = new CustomerFormViewModel
            {
                // we added membershipType objects inside of the NewCustomerViewModel class
                MemberShipType = membershipType
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel
                {
                    Customer = customer,
                    MemberShipType = _context.MemberShipType.ToList()
                };

                return View("New", viewModel);
            }

            if (customer.Id == 0)
                _context.Customers.Add(customer);
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);
                customerInDb.Name = customer.Name;
                customerInDb.Birthdate = customer.Birthdate;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Customer");
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MemberShipType = _context.MemberShipType.ToList()

            };

            return View("New",viewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Deneme(int id)
        {
            return View();
        }

        public ActionResult Details(int id)
        {
            var customer = _context.Customers.Include(m=>m.MemberShipType).SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();
            
            return View(customer);
        }
    }
}