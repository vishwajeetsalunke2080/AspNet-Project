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
                return RedirectToAction("Login", "Account");
            }
            
            else
            {
                ModelState.AddModelError("login error", "Invalid Data Passed");
                return View();
            }
        }


        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Login(LoginViewModel loginViewModel)
        {
            
                var appDbContext = new ApplicationDbContext();
                var userStore = new ApplicationUserStore(appDbContext);
                var userManager = new ApplicationUserManager(userStore);

                var user = userManager.Find(loginViewModel.Username,loginViewModel.Password);

                if(user != null)
                {
                    //login

                    var appAuthManager = HttpContext.GetOwinContext().Authentication;
                    var userIdentity = userManager.CreateIdentity(user,DefaultAuthenticationTypes.ApplicationCookie);
                    appAuthManager.SignIn(new AuthenticationProperties(),userIdentity);
                    
                    if(userManager.IsInRole(user.Id,"Admin"))
                    {
                        return RedirectToAction("Index", "Home", new {area="Admin"});
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    
                }              
                return View();
        }


        public ActionResult Logout()
        {
           if(User.Identity.IsAuthenticated)
            {
                var appAuthManager = HttpContext.GetOwinContext().Authentication;
                appAuthManager.SignOut();
                return RedirectToAction("Login");
            }
            else
            {
                return Content("Already Logged Out", "text/html");
            }
           
        }


        public ActionResult userProfile()
        {
            var userDbContext = new ApplicationDbContext();
            var userStore = new ApplicationUserStore(userDbContext);
            var userManager = new ApplicationUserManager(userStore);
            ApplicationUser profile = userManager.FindById(User.Identity.GetUserId());
            return View(profile);
        }
    }
}