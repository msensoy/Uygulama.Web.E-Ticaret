using BLL.Absract;
using Dtos.DTOModels.EntityDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SupriseBox.MvcUI.Areas.Admin.Controllers
{


    public class AdminProductController : Controller
    {

        IProductService _pc;
        public AdminProductController(IProductService pc)
        {
            _pc = pc;
        }
        // GET: Admin/AdminProduct
        public ActionResult Index()
        {
            var model = _pc.GetProducts().Result;
            return View(model);
        }

        [HttpPost]
        public ActionResult AddProduct(ProductDTO product)
        {
            // submit butonu ile model bilgileri model gelecek 

            if (!ModelState.IsValid)
            {
                return View("AddProduct", product);
            }
            var model = _pc.AddProduct(product);

            return Content(model.State.ToString());
            //_pc.AddProduct
           
        }

    }
    
}