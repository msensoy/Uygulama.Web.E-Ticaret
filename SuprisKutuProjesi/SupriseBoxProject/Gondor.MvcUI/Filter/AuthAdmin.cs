using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SupriseBox.MvcUI.Filter
{
    public class AuthAdmin : FilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {

            //if (HttpContext.Current.Session["UserName"] != null && CurrentSession.User.IsAdmin == false)
            //{
            //    filterContext.Result = new RedirectResult("/Home/AccessDenied");
            //}
        }
    }
}