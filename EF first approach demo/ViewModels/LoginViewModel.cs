using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EF_first_approach_demo.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Username can't be blank")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password can't be blank")]
        public string Password { get; set; }

    }
}