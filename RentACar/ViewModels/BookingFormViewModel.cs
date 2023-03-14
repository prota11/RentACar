using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RentACar.Models;

namespace RentACar.ViewModels
{
    public class BookingFormViewModel
    {
        public List<Customer> Customers { get; set; }
        public List<Vehicle> Vehicles { get; set; }
        public Booking Booking { get; set; }
    }
}