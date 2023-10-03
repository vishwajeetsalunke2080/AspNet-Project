﻿using EF_first_approach_demo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EF_first_approach_demo.Areas.Admin.Controllers
{
    public class BrandController : Controller
    {
        [Route("admin/brands/index")]
        public ActionResult Index()
        {
            codeFirstDbContext db = new codeFirstDbContext();
            List<Brand> brands = db.Brands.ToList();
            return View(brands);
        }
    }
}