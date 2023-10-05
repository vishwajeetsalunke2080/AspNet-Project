using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.BuilderProperties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EF_first_approach_demo.Identity
{
    public class ApplicationUser :IdentityUser
    {
        public DateTime? BirthDay { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public bool IsAllowedLogin { get; set; }
    }
}