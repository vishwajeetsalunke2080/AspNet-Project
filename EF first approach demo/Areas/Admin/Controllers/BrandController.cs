using EF_first_approach_demo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EF_first_approach_demo.Filters;

namespace EF_first_approach_demo.Areas.Admin.Controllers
{
    
    
    public class BrandController : Controller
    {
        [AdminAuthorization]
        public ActionResult Index()
        {
            codeFirstDbContext db = new codeFirstDbContext();
            List<Brand> brands = db.Brands.ToList();
            return View(brands);
        }
    }
}