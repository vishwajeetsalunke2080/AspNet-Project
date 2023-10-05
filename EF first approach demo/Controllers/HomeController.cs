using EF_first_approach_demo.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EF_first_approach_demo.Controllers
{
    
    
    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {
            return View();
        }
    }
}