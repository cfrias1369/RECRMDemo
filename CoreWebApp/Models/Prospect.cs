using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CoreWebApp.Models
{
    public class Prospect
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string InitialContactDate { get; set; }
        public string InitialContactNotes { get; set; }
    }
}
