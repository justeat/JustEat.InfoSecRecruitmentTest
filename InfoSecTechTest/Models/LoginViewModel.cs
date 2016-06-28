using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using InfoSecTechTest.Models;
using System.ComponentModel.DataAnnotations;

namespace InfoSecTechTest.Models
{
    public class LoginViewModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
