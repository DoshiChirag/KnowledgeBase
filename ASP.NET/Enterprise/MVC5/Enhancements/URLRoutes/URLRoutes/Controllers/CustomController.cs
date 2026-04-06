using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace URLRoutes.Controllers
{
    [RoutePrefix("Users")]
    public class CustomController : Controller
    {
        //
        // GET: /Custom/

        [Route("~/Test")]
        public ActionResult Index()
        {
            ViewBag.Controller = "Custom";
            ViewBag.Action = "Index";
            return View("ActionName");
            
        }

        //[Route("Users/Add/{user}/{id}")]
        public string Create(string user, int id)
        {
            return string.Format("User : {0}, ID: {1}",user,id);
        }


        [Route("Add/{user}/{id:int}")]
        public string CreateInt(string user, int id)
        {
            return string.Format("User : {0}, Int ID: {1}", user, id);
        }


        [Route("Add/{user}/{password:length(3)}")]
        public string ChangePass(string user, string password)
        {
            return string.Format("ChangePass Method : User {0}, Pass: {1}", user, password);
        }


        [Route("Add/{user}/{password:alpha:length(6)}")]
        public string ChangePassword(string user, string password)
        {
            return string.Format("ChangePassword Method : User {0}, Pass: {1}", user, password);
        }



        public ActionResult List()
        {
            ViewBag.Controller = "Custom";
            ViewBag.Action = "List";
            return View("ActionName");

        }

    }
}
