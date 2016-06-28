using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InfoSecTechTest.Models
{
    public class User
    {
        [Required]
        public int ID { get; set; }
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}