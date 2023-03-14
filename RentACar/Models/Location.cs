using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RentACar.Models
{
    public class Location
    {
        public int Id { get; set; }
        [Required]
        [StringLength(40)]
        public string City { get; set; }
        [Required]
        [StringLength(40)]
        public string Place { get; set; }
        [Required]
        [StringLength(40)]
        public string Address { get; set; }
    }
}