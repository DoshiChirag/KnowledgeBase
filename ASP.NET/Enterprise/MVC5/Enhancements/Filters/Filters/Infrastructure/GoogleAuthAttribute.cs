using System;
using System.Security.Principal;
using System.Web.Mvc;
using System.Web.Mvc.Filters;
using System.Web.Routing;
using System.Web.Security;
namespace Filters.Infrastructure
{
    public class GoogleAuthAttribute : FilterAttribute , IAuthenticationFilter
    {
        public void OnAuthentication(AuthenticationContext Context)
        {
            IIdentity ident = Context.Principal.Identity;
            if (!ident.IsAuthenticated || !ident.Name.EndsWith("@gmail.com"))
            {
                Context.Result = new HttpUnauthorizedResult();
            }

        }

        public void OnAuthenticationChallenge(AuthenticationChallengeContext Context)
        {
            if (Context.Result == null || Context.Result is HttpUnauthorizedResult)
            {
                Context.Result = new RedirectToRouteResult(new RouteValueDictionary { 
                    {"Controller", "GoogleAccount"},
                    {"action", "Login"},
                    {"returnUrl", Context.HttpContext.Request.RawUrl}
                });
            }
            else
            {
                //FormsAuthentication.SignOut();
            }
        }
    }
}