using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EF_first_approach_demo.Filters;
using EF_first_approach_demo.Identity;
using Microsoft.AspNet.Identity;

namespace EF_first_approach_demo.Areas.Admin.Controllers
{
    [AdminAuthorization]
    public class UserManagementController : Controller
    {
        // GET: Admin/UserManagement
        public ActionResult Index()
        {
            var appDbContext = new ApplicationDbContext();
            var appUserStore = new ApplicationUserStore(appDbContext);
            var appManager = new ApplicationUserManager(appUserStore);

            List<ApplicationUser> userList = appManager.Users.ToList();
            return View(userList);
        }

        public ActionResult updateUser(string Id)
        {
            var appDbContext = new ApplicationDbContext();
            var appUserStore = new ApplicationUserStore(appDbContext);
            var appManager = new ApplicationUserManager(appUserStore);
            var existingUser = appManager.FindById(Id);
            return View(existingUser);
        }

        [HttpPost]
        public ActionResult updateUser(ApplicationUser usr)
        {            
            if (ModelState.IsValid)
            {
                var appDbContext = new ApplicationDbContext();
                var appUserStore = new ApplicationUserStore(appDbContext);
                var appManager = new ApplicationUserManager(appUserStore);
                var existingUser = appManager.FindById(usr.Id);
                if (existingUser != null)
                {
                    existingUser.IsAllowedLogin = usr.IsAllowedLogin;
                }
                appDbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }            
        }
    }
}