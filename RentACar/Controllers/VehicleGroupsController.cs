using RentACar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RentACar.Controllers
{
    public class VehicleGroupsController : Controller
    {
        private ApplicationDbContext _context;

        public VehicleGroupsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: VehicleGroups
        [Authorize(Roles = RoleName.Administrator)]
        public ActionResult Index()
        {
            var vehicleGroups = _context.VehicleGroups.ToList();
            return View(vehicleGroups);
        }

        [Authorize(Roles = RoleName.Administrator)]
        public ActionResult New()
        {
            var viewModel = new VehicleGroup();

            return View("VehicleGroupForm", viewModel);
        }

        [Authorize(Roles = RoleName.Administrator)]
        public ActionResult Edit(int id)
        {
            var vehicleGroup = _context.VehicleGroups.SingleOrDefault(v => v.Id == id);

            if (vehicleGroup == null)
            {
                return HttpNotFound();
            }

            return View("VehicleGroupForm", vehicleGroup);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.Administrator)]
        public ActionResult Save(VehicleGroup vehicleGroup)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new VehicleGroup();
                return View("VehicleGroupForm", viewModel);
            }

            if (vehicleGroup.Id == 0)
            {
                _context.VehicleGroups.Add(vehicleGroup);
            }
            else
            {
                var vehicleGroupInDb = _context.VehicleGroups.Single(v => v.Id == vehicleGroup.Id);
                vehicleGroupInDb.Name = vehicleGroup.Name;
                vehicleGroupInDb.Description = vehicleGroup.Description;
                vehicleGroupInDb.PricePerDay = vehicleGroup.PricePerDay;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "VehicleGroups");
        }

        [Authorize(Roles = RoleName.Administrator)]
        public ActionResult Delete(int id)
        {
            var vehicleGroup = _context.VehicleGroups.FirstOrDefault(b => b.Id == id);
            _context.VehicleGroups.Remove(vehicleGroup);
            _context.SaveChanges();
            return RedirectToAction("Index", "VehicleGroups");
        }
    }
}