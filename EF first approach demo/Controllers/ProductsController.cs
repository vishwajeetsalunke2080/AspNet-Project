using EF_first_approach_demo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EF_first_approach_demo.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        public ActionResult Index()
        {
            codeFirstDbContext db  = new codeFirstDbContext();
            List<Product> products = db.Products.ToList();
            return View(products);
        }
    }
}