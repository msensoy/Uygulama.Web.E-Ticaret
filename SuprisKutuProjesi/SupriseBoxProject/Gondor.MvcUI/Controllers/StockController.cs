using Bll.Abstract.ComplexType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SupriseBox.MvcUI.Controllers
{
    public class StockController : Controller
    {
        IProductCategoryService _pcs;
        public StockController(IProductCategoryService pcs)
        {
            _pcs = pcs;
        }
        // GET: Stock
        public ActionResult MevcutUrunVeFiyatlari()
        {
          var model=  _pcs.GetProductCategoryList().Result;
            return View(model);
        }
    }
}