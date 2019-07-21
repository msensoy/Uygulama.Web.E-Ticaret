using Bll.Abstract.EntityType;
using DTOs.DTOModels.EntityDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SupriseBox.MvcUI.Controllers
{
    public class UserController : Controller
    {
        IUserService _us;
        public UserController(IUserService us)
        {
            _us = us;
        }

        [Route("User/SignIn")]
        public ActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        [Route("User/SignIn")]
        public ActionResult SignIn(UserDTO userDTO)
        {

                var model = _us.GetUserByUserName(userDTO.UserName);
                if (model.State == Common.ProcessStateEnum.Success)
                {
                    if (model.Result.Password == userDTO.Password && model.Result.IsDelete == false)
                    {

                        Session["UserId"] = model.Result.ID;
                        Session["UserName"] = model.Result.UserName;

                        //to do: Yönlendirme sayfası düzenlenecek.
                        return RedirectToAction("AnaSayfa", "Home");
                    }
                    else
                    {
                    ViewBag.Uyari = "Hatalı şifre girişi. Lütfen şifrenizi kontrol ediniz.";
                    }

                }
                else
                {
                    ViewBag.Uyari = "Bu kullanıcı adına ait bir üyelik bulunmamaktadır. Lütfen kullanıcı adınızı kontrol ediniz!";
                }
            return View();
        }


        public ActionResult SignOut()
        {
            Session["UserId"] = null;
            Session["UserName"] = null;
            Session["cartDetails"] = null;
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }
    }
}