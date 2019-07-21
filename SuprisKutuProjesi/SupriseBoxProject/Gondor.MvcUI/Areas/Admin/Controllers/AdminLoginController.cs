using Bll.Abstract.EntityType;
using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SupriseBox.MvcUI.Areas.Admin.Controllers
{
    public class AdminLoginController : Controller
    {
        IUserService _us;
        public AdminLoginController(IUserService us)
        {
            _us = us;
        }
        // GET: Admin/AdminLogin
        public ActionResult Login()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            var model = _us.GetUserByUserName(username);
            
            if (model.State == ProcessStateEnum.Success)
            {
                if (model.Result.Password == password && model.Result.IsDelete==false)
                {

                    Session["AdminUserId"] = model.Result.ID;
                    Session["AdminUserName"] = model.Result.UserName;
                    return RedirectToAction("Index", "AdminBox");
                }
                else
                {
                    ViewBag.Uyari = "Hatalı şifre girişi.";
                }

            }
            else
            {
                ViewBag.Uyari = " Lütfen kullanıcı adınızı kontrol ediniz!";
            }
            return View();
            
        }
        public ActionResult Logout()
        {
            Session["AdminUserId"] = null;
            Session["AdminUserName"] = null;
        
            Session.Abandon();
            return RedirectToAction("Index", "AdminBox");
        }
    }
}