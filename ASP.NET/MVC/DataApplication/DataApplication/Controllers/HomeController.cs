using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Razor.Models;
using DataApplication.Models;

namespace DataApplication.Controllers
{
    public class HomeController : Controller
    {
        private NorthwindEntities db = new NorthwindEntities();

        public CustomerModel demoCustomer = new CustomerModel()
        {
            CustomerID = 1,
            CompanyName = "Gregory Marley",
            ContactName = "Brothers And Sisters",            
            Address = new Address()
            {
                AddressID = 1,
                Street = "25 South Street",
                City = "Jacksonville",
                State = "Florida",
                PostalCode = "32256"
            }
        };

        public ActionResult CustomerDetails()
        {        
            return View(demoCustomer);
        }

        public ActionResult Address()
        {
            return View(demoCustomer.Address);
        }

        // GET: Home
        public ActionResult Index()
        {
            //var products = db.Products.Where(p => p.UnitPrice > 50M).Select(p => p);

            //order by
            //var products = db.Products.OrderByDescending(p=> p.UnitPrice);

            //take
            var products = db.Products.OrderByDescending(p => p.UnitPrice).Take(5);

            return View(products.ToList());
        }

        public ActionResult Categories()
        {
            var categories = db.Products.Select(p => p.CategoryID).Distinct();

            ViewBag.CategoryCount = db.Products.Select(p => p.CategoryID).Distinct().Count();

            return View(categories.ToList());
        }


        public ActionResult Orders()
        {
            var orders = from c in db.Customers
                         join o in db.Orders
                         on c.CustomerID equals o.CustomerID
                         where o.Freight > 25M
                         orderby o.Freight descending
                         select new JoinedOrder()
                         {
                             OrderID = o.OrderID,
                             CustomerID = c.CustomerID,
                             CompanyName = c.CompanyName,
                             ContactName = c.ContactName,
                             Freight = o.Freight,
                             ShipVia = o.ShipVia

                         };

            return View(orders.ToList());
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
