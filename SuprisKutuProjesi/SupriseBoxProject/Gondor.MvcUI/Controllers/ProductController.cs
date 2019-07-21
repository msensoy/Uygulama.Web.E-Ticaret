using BLL.Absract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SupriseBox.MvcUI.Controllers
{
    public class ProductController : Controller
    {
        IProductService _pc;
        public ProductController(IProductService pc)
        {
            _pc = pc;
        }
        // GET: Product

        [Route("Product/ToList")]
        public ActionResult ToList()
        {
           var model= _pc.GetProducts().Result;
            return View(model);
        }
    }
}