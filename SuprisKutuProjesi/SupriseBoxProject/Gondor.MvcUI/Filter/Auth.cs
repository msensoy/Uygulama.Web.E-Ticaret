using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SupriseBox.MvcUI.Filter
{
    public class Auth : FilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            if (HttpContext.Current.Session["UserName"] == null)
            {
                filterContext.Result = new RedirectResult("/User/SignIn");
            }

            //if (Helper.ShoppingDetails.UserID == null)
            //{
            //    Helper.ShoppingDetails.UserID = (int)HttpContext.Current.Session["UserID"];
            //}

        }
    }
}