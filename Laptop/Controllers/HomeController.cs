using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Laptop.Models;

namespace Laptop.Controllers
{
    public class HomeController : Controller
    {
        private LaptopEntities db = new LaptopEntities();
        [ChildActionOnly]
        public ActionResult RenderMenu()
        {
            return PartialView("_NavMenu", db.Catagories.ToList());
        }
        public ActionResult Index()
        {
            var products = db.Products.Include(p => p.Catagory);
            return View(products.ToList());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}