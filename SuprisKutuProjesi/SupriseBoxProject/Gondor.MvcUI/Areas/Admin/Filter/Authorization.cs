using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SupriseBox.MvcUI.Areas.Admin.Filter
{
    public class Authorization : FilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            if (HttpContext.Current.Session["AdminUserName"] == null)
            {
                filterContext.Result = new RedirectResult("~/Admin/AdminLogin/Login");
            }
        }
    }
}