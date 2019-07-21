using Bll.Abstract.ComplexType;
using DTOs.DTOModels.ComplexDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SupriseBox.MvcUI.Controllers
{
    public class CustomerUserController:Controller
    {
        ICustomerUserService _cus;
        public CustomerUserController(ICustomerUserService cus)
        {
            _cus = cus;
        }

        [Route("CustomerUser/Register")]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [Route("CustomerUser/Register")]
        public ActionResult Register(CustomerUserDTO customerUserDto)
        {
            var model =_cus.AddCustomerUser(customerUserDto);
            if (model.State==Common.ProcessStateEnum.Success)
            {
                ViewBag.Uyari = "Kayıt başarıyla gerçekleştirilmiştir.";
            }
            return RedirectToAction("SignIn","User");
        }
    }
    
}