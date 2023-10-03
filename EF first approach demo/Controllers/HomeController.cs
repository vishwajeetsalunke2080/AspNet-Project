using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EF_first_approach_demo.Controllers
{
    public class HomeController : Controller
    {
        [Route("home/index")]
        public ActionResult Index()
        {
            return View();
        }
    }
}