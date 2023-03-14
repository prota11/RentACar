using RentACar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RentACar.Controllers
{
    public class LocationsController : Controller
    {
        private ApplicationDbContext _context;

        public LocationsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Locations

        public ActionResult Index()
        {
            var locations = _context.Locations.ToList();
            if (User.IsInRole(RoleName.Administrator))
            {
                return View("List", locations);
            }
            return View("ReadOnlyLocations", locations);
        }

        [Authorize(Roles = RoleName.Administrator)]
        public ActionResult New()
        {
            var viewModel = new Location();

            return View("LocationForm", viewModel);
        }

        [Authorize(Roles = RoleName.Administrator)]
        public ActionResult Edit(int id)
        {
            var location = _context.Locations.SingleOrDefault(v => v.Id == id);

            if (location == null)
            {
                return HttpNotFound();
            }

            return View("LocationForm", location);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.Administrator)]
        public ActionResult Save(Location location)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new Location();
                return View("LocationForm", viewModel);
            }

            if (location.Id == 0)
            {
                _context.Locations.Add(location);
            }
            else
            {
                var locationInDb = _context.Locations.Single(v => v.Id == location.Id);
                locationInDb.City = location.City;
                locationInDb.Place = location.Place;
                locationInDb.Address = location.Address;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Locations");
        }
    }
}