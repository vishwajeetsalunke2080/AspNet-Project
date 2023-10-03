using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using EF_first_approach_demo.Identity;
using EF_first_approach_demo.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;

namespace EF_first_approach_demo.Controllers
{
    public class AccountController : Controller
    {

        public ActionResult Register()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Register(RegisterViewModel rvm)
        {
            if (ModelState.IsValid)
            {
                var userDBContext = new ApplicationDbContext();
                var userStore = new ApplicationUserStore(userDBContext);
                var usermanager = new ApplicationUserManager(userStore);
                var password = Crypto.HashPassword(rvm.Password);

                var user = new ApplicationUser()
                {
                    UserName = rvm.Username,
                    Email = rvm.Email,
                    PasswordHash = password,
                    City = rvm.City,
                    BirthDay = rvm.DateOfBirth,
                    Address = rvm.Address,
                    PhoneNumber = rvm.Mobile
                };

                IdentityResult result = usermanager.Create(user);
                if (result.Succeeded)
                {
                    usermanager.AddToRole(user.Id, "Customer");

                    var authManager = HttpContext.GetOwinContext().Authentication;
                    var userIdentity = usermanager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                    authManager.SignIn(new AuthenticationProperties(), userIdentity);
                }
                return RedirectToAction("Index", "Home");
            }
            
            else
            {
                ModelState.AddModelError("login error", "Invalid Data Passed");
                return View();
            }
        }
    }
}