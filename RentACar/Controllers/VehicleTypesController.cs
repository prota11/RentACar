using RentACar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RentACar.Controllers
{
    public class VehicleTypesController : Controller
    {
        private ApplicationDbContext _context;

        public VehicleTypesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: VehicleTypes
        [Authorize(Roles = RoleName.Administrator)]
        public ActionResult Index()
        {
            var vehicleTypes = _context.VehicleTypes.ToList();
            return View(vehicleTypes);
        }

        [Authorize(Roles = RoleName.Administrator)]
        public ActionResult New()
        {
            var viewModel = new VehicleType();

            return View("VehicleTypeForm", viewModel);
        }

        [Authorize(Roles = RoleName.Administrator)]
        public ActionResult Edit(int id)
        {
            var vehicleType = _context.VehicleTypes.SingleOrDefault(v => v.Id == id);

            if (vehicleType == null)
            {
                return HttpNotFound();
            }

            return View("VehicleTypeForm", vehicleType);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.Administrator)]
        public ActionResult Save(VehicleType vehicleType)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new VehicleType();
                return View("VehicleTypeForm", viewModel);
            }

            if (vehicleType.Id == 0)
            {
                _context.VehicleTypes.Add(vehicleType);
            }
            else
            {
                var vehicleTypeInDb = _context.VehicleTypes.Single(v => v.Id == vehicleType.Id);
                vehicleTypeInDb.Name = vehicleType.Name;
                vehicleTypeInDb.Description = vehicleType.Description;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "VehicleTypes");
        }

        [Authorize(Roles = RoleName.Administrator)]
        public ActionResult Delete(int id)
        {
            var vehicleType = _context.VehicleTypes.FirstOrDefault(b => b.Id == id);
            _context.VehicleTypes.Remove(vehicleType);
            _context.SaveChanges();
            return RedirectToAction("Index", "VehicleTypes");
        }
    }
}