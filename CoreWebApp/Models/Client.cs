using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CoreWebApp.Models
{
    public class Client
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "First Name is required.")]
        [StringLength(5)]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last Name is required.")]
        [StringLength(5)]
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string NickName { get; set; }
        public string PhoneNumber1 { get; set; }
        public string PhoneNumber2 { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string InitialContactDate { get; set; }
        public string InitialContactNotes { get; set; }
        public string SpouseName { get; set; }
        public string BirthDate { get; set; }
        public string AdditionalNotes { get; set; }
    }
}
