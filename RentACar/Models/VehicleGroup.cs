using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RentACar.Models
{
    public class VehicleGroup
    {
        public byte Id { get; set; }
        [Required]
        [StringLength(30)]
        public string Name { get; set; }
        [Required]
        [StringLength(200)]
        public string Description { get; set; }
        [Required]
        //[RegularExpression(@"^[0-9]+(\,[0-9]{1,2})$", ErrorMessage = "Valid Decimal number with maximum 2 decimal places.")]
        public int PricePerDay { get; set; }

        public virtual ICollection<Vehicle> Vehicles { get; set; }
    }
}