using RentACar.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RentACar.Dtos
{
    public class CustomerDto
    {
        [Required]
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        //[CustomerAlreadyExists]
        public string Email { get; set; }
        [Required]
        [MaxLength(40)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(40)]
        public string LastName { get; set; }

        [Required]
        //[DataType(DataType.Date)]
        //[Min18YearsForCustomers]
        public DateTime BirthDate { get; set; }

        [Required]
        //[Phone]
        [MaxLength(15)]
        public string PhoneNumber { get; set; }

        [Required]
        [MaxLength(50)]
        public string Country { get; set; }
    }
}