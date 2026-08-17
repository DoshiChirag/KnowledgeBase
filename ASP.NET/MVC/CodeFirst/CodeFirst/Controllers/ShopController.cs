using CodeFirst.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CodeFirst.Controllers
{
    public class ShopController : Controller
    {
        private ISkillsContext db = new ISkillsContext();
        // GET: Shop
        public ActionResult Index()
        {   
            var data = db.Products.Select(p => p).OrderBy(p => p.ProductName);
            return View(data);
        }
    }
}