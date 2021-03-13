using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Wep.App.Models;
using Vidly.Wep.App.ViewModels;


namespace Vidly.Wep.App.Controllers
{
    public class CustomersController : Controller
    {
         
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult NewCustomer()
        {
            var membershiptypes = _context.MembershipTypes.ToList();
            var viewModel = new NewCustomerViewModel
            {
                Customer = new Customer(),
                MembershipTypes = membershiptypes
            };


            return View("NewCustomer",viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var membershiptypes = _context.MembershipTypes.ToList();
                var viewModel = new NewCustomerViewModel
                {
                    Customer = customer,
                    MembershipTypes = membershiptypes

                };
                return View("NewCustomer", viewModel);
            }
            else
            {
                if (customer.Id == 0)
                { _context.Customers.Add(customer); }
                else
                {
                    var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);
                    {
                        customerInDb.Name = customer.Name;
                        customerInDb.BirthDate = customer.BirthDate;
                        customerInDb.MembershipTypeId = customer.MembershipTypeId;
                        customerInDb.IsSubscribedToCustomer = customer.IsSubscribedToCustomer;
                    }
                }

                _context.SaveChanges();

                return RedirectToAction("Index", "Customers");
            }
           
        }
          
        // GET: Customers
        public ViewResult Index()
        {
            //var customers = _context.Customers.Include(c => c.MembershipType).ToList();
          
            return View();
        }

        public ActionResult Details(int id)
        {
            var customer = _context.Customers.Include(c=>c.MembershipType).SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }


        public ActionResult Edit(int id)
        {
            var editcustomer = _context.Customers.FirstOrDefault(c => c.Id == id);
            if (editcustomer == null)
            {
                return HttpNotFound();
            }

            var viewModel = new NewCustomerViewModel
            {
                Customer = editcustomer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };

            return View("NewCustomer",viewModel);
        }
    }

}
