using RentACar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RentACar.ViewModels
{
    public class VehicleFormViewModel
    {
        public IEnumerable<VehicleGroup> VehicleGroups { get; set; }
        public IEnumerable<VehicleType> VehicleTypes { get; set; }
        public Vehicle Vehicle { get; set; }
    }
}