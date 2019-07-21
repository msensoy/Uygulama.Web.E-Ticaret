using Bll.Abstract.EntityType;
using Common;
using DTOs.DTOModels;
using DTOs.DTOModels.ComplexDTOs;
using DTOs.DTOModels.EntityDTOs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SupriseBox.MvcUI.Controllers
{
    public class ShoppingController : Controller
    {
        IBoxService _bs;
        // GET: Shopping
        public ShoppingController(IBoxService bs)
        {
            _bs = bs;
        }


        //sepete kutu ekler
        public ActionResult ShoppingCard(int BoxID)
        {
            ManageBasket mb = new ManageBasket(_bs);
            var JsonData = mb.AddBoxToBasket(BoxID);

            return Json(JsonData, JsonRequestBehavior.AllowGet);
        }



        //Sepetteki kutuların bilgilerini gösterir 
        public ActionResult ShoppingCardDetail()
        {
            List<BoxDTO> boxes = new List<BoxDTO>();
            var boxIDs = ((List<OrderDetailDTO>)Session["cartDetails"]).Select(x=>x.BoxID).ToList();

            foreach (var boxID in boxIDs)
            {
                try
                {
                    var serviceResult = _bs.GetBoxById(boxID);
                    if (serviceResult.State == ProcessStateEnum.Success)
                    {
                        boxes.Add(serviceResult.Result);
                    }
                    else
                    {
                        return Content("Bir Hata Oluştu!");
                    }
                }
                catch (Exception ex)
                {
                    return Content(ex.Message);
                }
            }

            return View(boxes);
        }
    }
}