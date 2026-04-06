using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace URLRoutes.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult About()
        {
            ViewBag.Controller = "Home";
            ViewBag.Action = "About";
            return View("ActionName");
        }

        public ActionResult Index()
        {
            ViewBag.Controller = "Home";
            ViewBag.Action = "Index";
            return View("ActionName");
        }


        public ActionResult CustomVariable()
        {
            ViewBag.Controller = "Home";
            ViewBag.Action = "CustomVariable";
            ViewBag.CustomVariable = RouteData.Values["id"];
            return View();
        }

        public ActionResult CustomVariableActionParams(string id = "DefaultId")
        {
            ViewBag.Controller = "Home";
            ViewBag.Action = "CustomVariableActionParams";
            ViewBag.CustomVariable = id ;
            return View("CustomVariable");
        }



    }
}
