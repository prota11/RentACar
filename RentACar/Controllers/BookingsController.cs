using RentACar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using RentACar.ViewModels;

namespace RentACar.Controllers
{
    public class BookingsController : Controller
    {
        private ApplicationDbContext _context;

        public BookingsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Bookings
        [Authorize(Roles = RoleName.Administrator + "," + RoleName.User)]
        public ActionResult Index()
        {
            var bookings = _context.Bookings.Include(b => b.Customer).Include(b => b.Vehicle).ToList();
            return View(bookings);
        }

        [Authorize(Roles = RoleName.Administrator + "," + RoleName.User)]
        public ActionResult New()
        {
            var customers = _context.Customers.ToList();
            var vehicles = _context.Vehicles.ToList();
            var viewModel = new BookingFormViewModel
            {
                Booking = new Booking(),
                Vehicles = vehicles,
                Customers = customers
            };
            viewModel.Booking.PickupDate = DateTime.Now.Date;
            viewModel.Booking.ReturnDate = DateTime.Now.Date;

            return View("BookingForm", viewModel);
        }

        [Authorize(Roles = RoleName.Administrator + "," + RoleName.User)]
        public ActionResult Edit(int id)
        {
            var booking = _context.Bookings.SingleOrDefault(b => b.Id == id);

            if (booking == null)
            {
                return HttpNotFound();
            }

            var viewModel = new BookingFormViewModel
            {
                Booking = booking,
                Vehicles = _context.Vehicles.ToList(),
                Customers = _context.Customers.ToList()
            };

            return View("BookingForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.Administrator + "," + RoleName.User)]
        public ActionResult Save(Booking booking)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new BookingFormViewModel
                {
                    Booking = booking,
                    Vehicles = _context.Vehicles.ToList(),
                    Customers = _context.Customers.ToList()
                };

                return View("BookingForm", viewModel);
            }

            if (booking.Id == 0)
            {
                _context.Bookings.Add(booking);
                var chosenVehicle = _context.Vehicles.SingleOrDefault(v => v.Id == booking.VehicleId);
                var chosenVehicleGroup = _context.VehicleGroups.SingleOrDefault(v => v.Id == chosenVehicle.VehicleGroupId);
                if (booking.PickupDate.Month > 5 && booking.PickupDate.Month < 9)
                {
                    booking.Price = chosenVehicleGroup.PricePerDay * (booking.ReturnDate - booking.PickupDate).Days * 2;
                }
                else
                {
                    booking.Price = chosenVehicleGroup.PricePerDay * (booking.ReturnDate - booking.PickupDate).Days;
                }
                chosenVehicle.Quantity -= 1;
            }
            else
            {
                var bookingInDb = _context.Bookings.Single(b => b.Id == booking.Id);
                var chosenVehicle = _context.Vehicles.SingleOrDefault(v => v.Id == bookingInDb.VehicleId);
                var chosenVehicleGroup = _context.VehicleGroups.SingleOrDefault(v => v.Id == chosenVehicle.VehicleGroupId);
                var newChosenVehicle = _context.Vehicles.SingleOrDefault(v => v.Id == booking.VehicleId);
                var newChosenVehicleGroup = _context.VehicleGroups.SingleOrDefault(v => v.Id == newChosenVehicle.VehicleGroupId);

                bookingInDb.CustomerId = booking.CustomerId;
                if(bookingInDb.VehicleId != booking.VehicleId)
                {
                    if (bookingInDb.PickupDate.Month > 5 && bookingInDb.PickupDate.Month < 9)
                    {
                        bookingInDb.Price = newChosenVehicleGroup.PricePerDay * (booking.ReturnDate - booking.PickupDate).Days * 2;
                    }
                    else
                    {
                        bookingInDb.Price = newChosenVehicleGroup.PricePerDay * (booking.ReturnDate - booking.PickupDate).Days;
                    }
                    chosenVehicle.Quantity += 1;
                    newChosenVehicle.Quantity -= 1;
                }
                bookingInDb.VehicleId = booking.VehicleId;
                bookingInDb.PickupLocation = booking.PickupLocation;
                bookingInDb.ReturnLocation = booking.ReturnLocation;
                bookingInDb.PickupDate = booking.PickupDate;
                bookingInDb.ReturnDate = booking.ReturnDate;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Bookings");
        }

        [Authorize(Roles = RoleName.Administrator + "," + RoleName.User)]
        public ActionResult Delete(int id)
        {
            var booking = _context.Bookings.FirstOrDefault(b => b.Id == id);
            var chosenVehicle = _context.Vehicles.SingleOrDefault(v => v.Id == booking.VehicleId);
            _context.Bookings.Remove(booking);
            chosenVehicle.Quantity += 1;
            _context.SaveChanges();
            return RedirectToAction("Index", "Bookings");
        }
    }
}