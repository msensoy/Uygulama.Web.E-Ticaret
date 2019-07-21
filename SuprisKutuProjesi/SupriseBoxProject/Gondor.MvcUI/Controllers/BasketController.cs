using Bll.Abstract.EntityType;
using DTOs.DTOModels.EntityDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SupriseBox.MvcUI.Controllers
{
    public class BasketController : Controller
    {
        IBoxService _bs;

        public BasketController(IBoxService bs)
        {
            _bs = bs;
        }
        // GET: Basket
        public ActionResult BoxesInBasket()
        {
            var selectedBoxes = (List<OrderDetailDTO>)Session["cartDetails"];
           
            return View(selectedBoxes);
        }


        //Kutu bilgileri ve miktarları List<OrderDetails> olarak static sınıf icerisindeki item propertisine yazıldı.
        //Daha sonra ödeme işleminin son adımı olan CheckOut sayfasına Yönlendirildi.
        [HttpPost]
        public ActionResult BoxesInBasket(FormCollection formColl)
        {

            for (int i = 0; i < formColl.Count/2; i++)
            {
                int BoxID = Convert.ToInt32(formColl["shcartID-" + i + ""]);
                var box=_bs.GetBoxById(BoxID);

                foreach (var item in (List<OrderDetailDTO>)Session["cartDetails"])
                {
                    if (item.BoxID==BoxID)
                    {
                    item.BoxAmount = Convert.ToInt32(formColl["qty-" + i + ""]);
                    item.TotalAmount = box.Result.Price * Convert.ToInt32(formColl["qty-" + i + ""]);
                    var currentBox = ((List<OrderDetailDTO>)Session["cartDetails"]).Where(x => x.BoxID == BoxID).FirstOrDefault();
                    ((List<OrderDetailDTO>)Session["cartDetails"]).Where(x => x.BoxID == BoxID).FirstOrDefault().BoxAmount= Convert.ToInt32(formColl["qty-" + i + ""]);
                    ((List<OrderDetailDTO>)Session["cartDetails"]).Where(x => x.BoxID == BoxID).FirstOrDefault().TotalAmount = currentBox.UnitPrice * Convert.ToInt32(formColl["qty-" + i + ""]);
                    }
                }             
            }
            return RedirectToAction("Index","CheckOut");
        }

    }
}