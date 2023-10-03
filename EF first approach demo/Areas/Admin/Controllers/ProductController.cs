using EF_first_approach_demo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EF_first_approach_demo.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        codeFirstDbContext db = new codeFirstDbContext();
        public ActionResult Index(string search = "", string sortColumn = "ProductID", string iconClass = "fa-sort-asc", int PageNo = 1)
        {

            ViewBag.searchItem = search;
            List<Product> products = db.Products.Where(temp => temp.ProductName.Contains(search)).ToList();

            //sorting function 

            ViewBag.sortColumn = sortColumn;
            ViewBag.iconClass = iconClass;

            if (ViewBag.sortColumn == "ProductID")
            {
                if (ViewBag.iconClass == "fa-sort-asc")
                {
                    products = products.OrderBy(temp => temp.ProductID).ToList();
                }
                else
                {
                    products = products.OrderByDescending(temp => temp.ProductID).ToList();
                }
            }
            else if (ViewBag.sortColumn == "ProductName")
            {
                if (ViewBag.iconClass == "fa-sort-asc")
                {
                    products = products.OrderBy(temp => temp.ProductName).ToList();
                }
                else
                {
                    products = products.OrderByDescending(temp => temp.ProductName).ToList();
                }
            }
            else if (ViewBag.sortColumn == "Price")
            {
                if (ViewBag.iconClass == "fa-sort-asc")
                {
                    products = products.OrderBy(temp => temp.Price).ToList();
                }
                else
                {
                    products = products.OrderByDescending(temp => temp.Price).ToList();
                }
            }
            else if (ViewBag.sortColumn == "DateOfPurchase")
            {
                if (ViewBag.iconClass == "fa-sort-asc")
                {
                    products = products.OrderBy(temp => temp.DateOfPurchase).ToList();
                }
                else
                {
                    products = products.OrderByDescending(temp => temp.DateOfPurchase).ToList();
                }
            }
            else if (ViewBag.sortColumn == "Quantity")
            {
                if (ViewBag.iconClass == "fa-sort-asc")
                {
                    products = products.OrderBy(temp => temp.Quantity).ToList();
                }
                else
                {
                    products = products.OrderByDescending(temp => temp.Quantity).ToList();
                }
            }

            //paging
            int NoOfItemsPerPage = 10;
            int NoOfPages = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(products.Count) / Convert.ToDouble(NoOfItemsPerPage)));
            int NoOfItemToSkip = ((PageNo - 1) * NoOfItemsPerPage);
            ViewBag.PageNo = PageNo;
            ViewBag.NoOfPages = NoOfPages;
            products = products.Skip(NoOfItemToSkip).Take(NoOfItemsPerPage).ToList();
            return View(products);
        }

        //Product details action             
        public ActionResult Details(long id)
        {

            Product product = db.Products.Where(temp => temp.ProductID == id).FirstOrDefault();
            return View(product);
        }

        //Product create action
        public ActionResult Create()
        {

            ViewBag.Brand = db.Brands.ToList();
            ViewBag.Category = db.Categories.ToList();
            return View();
        }

        [HttpPost]
        public ActionResult Create([Bind(Include = "ProductID,ProductName,Price,DateOfPurchase,AvailabilityStatus,BrandID,CategoryID,Active,Photo,Quantity")] Product p)
        {
            ViewBag.Brand = db.Brands.ToList();
            ViewBag.Category = db.Categories.ToList();
            if (ModelState.IsValid)
            {
                if (Request.Files.Count >= 1)
                {
                    var file = Request.Files[0];
                    var imageBytes = new Byte[file.ContentLength];
                    file.InputStream.Read(imageBytes, 0, file.ContentLength);
                    var base64String = Convert.ToBase64String(imageBytes, 0, imageBytes.Length);
                    p.Photo = base64String;
                }
                db.Products.Add(p);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        public ActionResult Update(long id)
        {

            Product product = db.Products.Where(temp => temp.ProductID == id).FirstOrDefault();
            ViewBag.Brand = db.Brands.ToList();
            ViewBag.Category = db.Categories.ToList();
            return View(product);
        }

        [HttpPost]
        public ActionResult Update(Product p)
        {
            ViewBag.Brand = db.Brands.ToList();
            ViewBag.Category = db.Categories.ToList();
            Product existingProduct = db.Products.Where(temp => temp.ProductID == p.ProductID).FirstOrDefault();
            existingProduct.ProductName = p.ProductName;
            existingProduct.Price = p.Price;
            existingProduct.DateOfPurchase = p.DateOfPurchase;
            existingProduct.BrandID = p.BrandID;
            existingProduct.CategoryID = p.CategoryID;
            existingProduct.AvailabilityStatus = p.AvailabilityStatus;
            existingProduct.Active = p.Active;
            existingProduct.Quantity = p.Quantity;
            if (Request.Files.Count >= 1)
            {
                var file = Request.Files[0];
                var imageBytes = new Byte[file.ContentLength];
                file.InputStream.Read(imageBytes, 0, file.ContentLength);
                var base64String = Convert.ToBase64String(imageBytes, 0, imageBytes.Length);
                existingProduct.Photo = base64String;
            }
            if (ModelState.IsValid)
            {
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        public ActionResult Remove(long id)
        {

            Product product = db.Products.Where(temp => temp.ProductID == id).FirstOrDefault();
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}