using EF_first_approach_demo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EF_first_approach_demo.Areas.Admin.Controllers
{
    public class CategoriesController : Controller
    {
        [Route("admin/categories/index")]
        public ActionResult Index()
        {
            codeFirstDbContext db = new codeFirstDbContext();
            List<Category> categories = db.Categories.ToList();
            return View(categories);
        }
    }
}