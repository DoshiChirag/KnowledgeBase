using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Razor.Models;
namespace Razor.Controllers
{
    public class HomeController : Controller
    {

        Product myProduct = new Product
        {
            ProductID = 1,
            Name = "Kayak",
            Description = "A boat for one  person",
            Category = "WaterSports",
            Price = 275M
            
        };

        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View(myProduct);
        }

        public ActionResult NameAndPrice()
        {
            return View(myProduct);
        }


        public ActionResult DemoExpression()
        {
            ViewBag.ProductCount = 1;
            ViewBag.ExpressShip = true;
            ViewBag.ApplyDiscount = false;
            return View(myProduct);
        }


        public ActionResult DemoArray()
        {
            Product[] array = {
                     new Product{Name = "Kayak", Category = "WaterSports", Price = 275M},
                     new Product{Name = "Lifejacket", Category = "WaterSports", Price = 48.95M},
                      new Product{Name = "Soccer ball", Category= "Soccer",Price = 19.50M},
                      new Product{Name = "Corner flag", Category = "Soccer", Price = 34.95M}
             };

            return View(array);
        }


    }
}
