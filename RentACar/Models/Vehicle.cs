using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RentACar.Models
{
    public class Vehicle
    {
        public int Id { get; set; }
        [Required]
        [StringLength(40)]
        public string Make { get; set; }
        [Required]
        [StringLength(40)]
        public string Model { get; set; }
        [Required]
        [StringLength(15)]
        public string Fuel { get; set; }
        [Required]
        public int Seats { get; set; }
        [Required]
        [StringLength(10)]
        public string Gearbox { get; set; }
        [Required]
        public int Quantity { get; set; }
        public VehicleType VehicleType { get; set; }
        [Required]
        [Display(Name = "Vehicle Type")]
        public byte VehicleTypeId { get; set; }
        public VehicleGroup VehicleGroup { get; set; }
        [Required]
        [Display(Name = "Vehicle Group")]
        public byte VehicleGroupId { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }
    }
}