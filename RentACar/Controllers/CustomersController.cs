using RentACar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RentACar.ViewModels;

namespace RentACar.Controllers
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

        // GET: Customers
        [Authorize(Roles = RoleName.Administrator + "," + RoleName.User)]
        public ActionResult Index()
        {
            var customers = _context.Customers.ToList();
            return View(customers);
        }

        [Authorize(Roles = RoleName.Administrator + "," + RoleName.User)]
        public ActionResult New()
        {
            var viewModel = new Customer();
            viewModel.BirthDate = DateTime.Now.Date;
            return View("CustomerForm", viewModel);
        }

        [Authorize(Roles = RoleName.Administrator + "," + RoleName.User)]
        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
            {
                return HttpNotFound();
            }

            return View("CustomerForm", customer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.Administrator + "," + RoleName.User)]
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new Customer();
                return View("CustomerForm", viewModel);
            }

            if (customer.Id == 0)
            {
                _context.Customers.Add(customer);
            }
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);
                customerInDb.Email = customer.Email;
                customerInDb.FirstName = customer.FirstName;
                customerInDb.LastName = customer.LastName;
                customerInDb.BirthDate = customer.BirthDate;
                customerInDb.PhoneNumber = customer.PhoneNumber;
                customerInDb.Country = customer.Country;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Customers");
        }

        [Authorize(Roles = RoleName.Administrator + "," + RoleName.User)]
        public ActionResult Delete(int id)
        {
            var customer = _context.Customers.FirstOrDefault(b => b.Id == id);
            _context.Customers.Remove(customer);
            _context.SaveChanges();
            return RedirectToAction("Index", "Customers");
        }
    }
}