using Filters.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.UI;

namespace Filters.Controllers
{
    public class AccountController : Controller
    {
        //
        // GET: /Account/

      
        public ActionResult LoginOld(string username, string password, string returnUrl)
        {
            bool result = FormsAuthentication.Authenticate(username, password);
            if (result)
            {
                FormsAuthentication.SetAuthCookie(username,false);
                return Redirect(returnUrl ?? Url.Action("Index", "Admin"));
            }
            else
            {
                ModelState.AddModelError("", "Incorrect username or password");
                return View();
            }
        }

        [HttpPost]
        public ActionResult Login(UserAccount user)
        {
            AppDbContext db = new AppDbContext();
            var usr = db.UserAccounts.Single(u => u.UserName == user.UserName && u.Password == user.Password);
            if (usr != null)
            {
                Session["UserID"] = user.UserID.ToString();
                Session["UserName"] = usr.UserName.ToString();
                FormsAuthentication.RedirectFromLoginPage(Session["UserName"].ToString(), false);

            }
            else
            {
                ModelState.AddModelError("", "Incorrect username or password");                
            }

            return View();

        }

    }
}
