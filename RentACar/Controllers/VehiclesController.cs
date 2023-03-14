using RentACar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using RentACar.ViewModels;
using PagedList;
using PagedList.Mvc;

namespace RentACar.Controllers
{
    public class VehiclesController : Controller
    {
        private ApplicationDbContext _context;

        public VehiclesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Vehicles
        public ActionResult Index(string searchBy, string search, string orderBy, int? page)
        {
            var vehicles = _context.Vehicles.Include(v => v.VehicleType).Include(v => v.VehicleGroup);
            if(User.IsInRole(RoleName.Administrator))
            {
                if (!String.IsNullOrEmpty(search))
                {
                    if(searchBy == "All")
                    {
                        vehicles = _context.Vehicles.Include(v => v.VehicleType).Include(v => v.VehicleGroup).Where(v => v.Make.Contains(search) || v.Model.Contains(search) || v.Seats.ToString().Contains(search) || v.Quantity.ToString().Contains(search) || v.Fuel.Contains(search) || v.VehicleGroup.Name.Contains(search) || v.VehicleType.Name.Contains(search));
                    }
                    if(searchBy == "Make")
                    {
                        vehicles = _context.Vehicles.Include(v => v.VehicleType).Include(v => v.VehicleGroup).Where(v => v.Make.Contains(search) || search == null);
                    }
                    if (searchBy == "Model")
                    {
                        vehicles = _context.Vehicles.Include(v => v.VehicleType).Include(v => v.VehicleGroup).Where(v => v.Model.Contains(search) || search == null);
                    }
                    if (searchBy == "Fuel")
                    {
                        vehicles = _context.Vehicles.Include(v => v.VehicleType).Include(v => v.VehicleGroup).Where(v => v.Fuel.Contains(search) || search == null);
                    }
                    if (searchBy == "Seats")
                    {
                        vehicles = _context.Vehicles.Include(v => v.VehicleType).Include(v => v.VehicleGroup).Where(v => v.Seats.ToString().Contains(search) || search == null);
                    }
                    if (searchBy == "Quantity")
                    {
                        vehicles = _context.Vehicles.Include(v => v.VehicleType).Include(v => v.VehicleGroup).Where(v => v.Quantity.ToString().Contains(search) || search == null);
                    }
                    if (searchBy == "Vehicle Group")
                    {
                        vehicles = _context.Vehicles.Include(v => v.VehicleType).Include(v => v.VehicleGroup).Where(v => v.VehicleGroup.Name.Contains(search) || search == null);
                    }
                    if (searchBy == "Vehicle Type")
                    {
                        vehicles = _context.Vehicles.Include(v => v.VehicleType).Include(v => v.VehicleGroup).Where(v => v.VehicleType.Name.Contains(search) || search == null);
                    }
                }

                switch (orderBy)
                {
                    case "Model":
                        vehicles = vehicles.OrderBy(v => v.Model);
                        break;
                    case "Fuel":
                        vehicles = vehicles.OrderBy(v => v.Fuel);
                        break;
                    case "Seats":
                        vehicles = vehicles.OrderBy(v => v.Seats);
                        break;
                    case "Quantity":
                        vehicles = vehicles.OrderBy(v => v.Quantity);
                        break;
                    case "Vehicle Group":
                        vehicles = vehicles.OrderBy(v => v.VehicleGroup.Name);
                        break;
                    case "Vehicle Type":
                        vehicles = vehicles.OrderBy(v => v.VehicleType.Name);
                        break;
                    default:
                        vehicles = vehicles.OrderBy(v => v.Make);
                        break;
                }
                return View("List", vehicles.ToPagedList(page ?? 1, 5));
            }
            else
            {
                if (!String.IsNullOrEmpty(search))
                {
                    if (searchBy == "All")
                    {
                        vehicles = _context.Vehicles.Include(v => v.VehicleType).Include(v => v.VehicleGroup).Where(v => v.Make.Contains(search) || v.Model.Contains(search) || v.Seats.ToString().Contains(search) || v.Quantity.ToString().Contains(search) || v.Fuel.Contains(search) || v.VehicleGroup.Name.Contains(search) || v.VehicleType.Name.Contains(search));
                    }
                    if (searchBy == "Make")
                    {
                        vehicles = _context.Vehicles.Include(v => v.VehicleType).Include(v => v.VehicleGroup).Where(v => v.Make.Contains(search) || search == null);
                    }
                    if (searchBy == "Model")
                    {
                        vehicles = _context.Vehicles.Include(v => v.VehicleType).Include(v => v.VehicleGroup).Where(v => v.Model.Contains(search) || search == null);
                    }
                    if (searchBy == "Fuel")
                    {
                        vehicles = _context.Vehicles.Include(v => v.VehicleType).Include(v => v.VehicleGroup).Where(v => v.Fuel.Contains(search) || search == null);
                    }
                    if (searchBy == "Seats")
                    {
                        vehicles = _context.Vehicles.Include(v => v.VehicleType).Include(v => v.VehicleGroup).Where(v => v.Seats.ToString().Contains(search) || search == null);
                    }
                    if (searchBy == "Quantity")
                    {
                        vehicles = _context.Vehicles.Include(v => v.VehicleType).Include(v => v.VehicleGroup).Where(v => v.Quantity.ToString().Contains(search) || search == null);
                    }
                    if (searchBy == "Vehicle Group")
                    {
                        vehicles = _context.Vehicles.Include(v => v.VehicleType).Include(v => v.VehicleGroup).Where(v => v.VehicleGroup.Name.Contains(search) || search == null);
                    }
                    if (searchBy == "Vehicle Type")
                    {
                        vehicles = _context.Vehicles.Include(v => v.VehicleType).Include(v => v.VehicleGroup).Where(v => v.VehicleType.Name.Contains(search) || search == null);
                    }
                }

                switch (orderBy)
                {
                    case "Make":
                        vehicles = vehicles.OrderBy(v => v.Make);
                        break;
                    case "Model":
                        vehicles = vehicles.OrderBy(v => v.Model);
                        break;
                    case "Fuel":
                        vehicles = vehicles.OrderBy(v => v.Fuel);
                        break;
                    case "Seats":
                        vehicles = vehicles.OrderBy(v => v.Seats);
                        break;
                    case "Quantity":
                        vehicles = vehicles.OrderBy(v => v.Quantity);
                        break;
                    case "Vehicle Group":
                        vehicles = vehicles.OrderBy(v => v.VehicleGroup.Name);
                        break;
                    case "Vehicle Type":
                        vehicles = vehicles.OrderBy(v => v.VehicleType.Name);
                        break;
                    default:
                        vehicles = vehicles.OrderBy(v => v.Make);
                        break;
                }
                return View("ReadOnlyVehicles", vehicles.ToPagedList(page ?? 1, 10));
            }
        }

        [Authorize(Roles = RoleName.Administrator)]
        public ActionResult New()
        {
            var vehicleGroups = _context.VehicleGroups.ToList();
            var vehicleTypes = _context.VehicleTypes.ToList();
            var viewModel = new VehicleFormViewModel
            {
                Vehicle = new Vehicle(),
                VehicleTypes = vehicleTypes,
                VehicleGroups = vehicleGroups
            };

            return View("VehicleForm", viewModel);
        }

        [Authorize(Roles = RoleName.Administrator)]
        public ActionResult Edit(int id)
        {
            var vehicle = _context.Vehicles.SingleOrDefault(v => v.Id == id);

            if (vehicle == null)
            {
                return HttpNotFound();
            }

            var viewModel = new VehicleFormViewModel
            {
                Vehicle = vehicle,
                VehicleTypes = _context.VehicleTypes.ToList(),
                VehicleGroups = _context.VehicleGroups.ToList()
            };

            return View("VehicleForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.Administrator)]
        public ActionResult Save(Vehicle vehicle)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new VehicleFormViewModel
                {
                    Vehicle = vehicle,
                    VehicleTypes = _context.VehicleTypes.ToList(),
                    VehicleGroups = _context.VehicleGroups.ToList()
                };

                return View("VehicleForm", viewModel);
            }

            if (vehicle.Id == 0)
            {
                _context.Vehicles.Add(vehicle);
            }
            else
            {
                var vehicleInDb = _context.Vehicles.Single(v => v.Id == vehicle.Id);
                vehicleInDb.Make = vehicle.Make;
                vehicleInDb.Model = vehicle.Model;
                vehicleInDb.Fuel = vehicle.Fuel;
                vehicleInDb.Seats = vehicle.Seats;
                vehicleInDb.Gearbox = vehicle.Gearbox;
                vehicleInDb.Quantity = vehicle.Quantity;
                vehicleInDb.VehicleGroupId = vehicle.VehicleGroupId;
                vehicleInDb.VehicleTypeId = vehicle.VehicleTypeId;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Vehicles");
        }

        [Authorize(Roles = RoleName.Administrator)]
        public ActionResult Delete(int id)
        {
            var vehicle = _context.Vehicles.FirstOrDefault(b => b.Id == id);
            _context.Vehicles.Remove(vehicle);
            _context.SaveChanges();
            return RedirectToAction("Index", "Vehicles");
        }
    }
}