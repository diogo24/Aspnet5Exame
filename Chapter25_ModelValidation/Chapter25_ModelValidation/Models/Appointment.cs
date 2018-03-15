using Chapter25_ModelValidation.Infrastructure;
using System;
using System.ComponentModel.DataAnnotations;

namespace Chapter25_ModelValidation.Models
{
    [NoJoeOnMondays]
    public class Appointment
    {
        [Required]
        public string ClientName { get; set; }

        [DataType(DataType.Date)]
        //[Required(ErrorMessage = "Please enter a date")]
        [FutureDate(ErrorMessage = "Please enter a date")]
        public DateTime Date { get; set; }

        //[Range(typeof(bool), "true", "true", ErrorMessage = "You must accept the terms")]
        [MustBeTrue(ErrorMessage = "You must accept the terms")]
        public bool TermsAccepted { get; set; }
    }
}