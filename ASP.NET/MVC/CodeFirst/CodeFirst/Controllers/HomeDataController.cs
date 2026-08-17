using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CodeFirst.Controllers
{
    public class HomeDataController : Controller
    {
        // GET: HomeData
        public ActionResult Index()
        {
            return View();
        }
    }
}