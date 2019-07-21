using Bll.Abstract.ComplexType;
using Bll.Abstract.EntityType;
using Common;
using DTOs.DTOModels;
using DTOs.DTOModels.ComplexDTOs;
using DTOs.DTOModels.EntityDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SupriseBox.MvcUI.Controllers
{
    public class BoxController : Controller
    {
        IBoxService _bs;
        IBoxBoxTypeService _bbts;
        IBoxTypeService _bts;

        public BoxController(IBoxService bs,IBoxBoxTypeService bbts,IBoxTypeService bts)
        {
            _bs = bs;
            _bbts = bbts;
            _bts = bts;
        }


        //Tekli kutularla alakalı bilgileri gösterir.
        public ActionResult SingleBox(int id)
        {

            var model = _bbts.GetBoxBoxType(id);
            if (model.Result!=null)
            {
                return View(model.Result);
            }

            return HttpNotFound();
        }


        //Kutuların bulunduğu ana sayfayı açar.
        public ActionResult BoxesMainPage()
        {
            var model = _bs.GetBoxes().Result;
            if (model != null)
            {
                return View(model);
            }
            return HttpNotFound();

        }


    }
}