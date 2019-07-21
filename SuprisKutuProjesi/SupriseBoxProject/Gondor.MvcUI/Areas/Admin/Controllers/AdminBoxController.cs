using Bll.Abstract.ComplexType;
using Bll.Abstract.EntityType;
using DTOs.DTOModels.ComplexDTOs;
using DTOs.DTOModels.EntityDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SupriseBox.MvcUI.Areas.Admin.Controllers
{
    public class AdminBoxController : Controller
    {
        IBoxService _bs;
        IBoxBoxTypeService _bbts;
        IBoxTypeService _bts;

        public AdminBoxController(IBoxService bs, IBoxBoxTypeService bbts, IBoxTypeService bts)
        {
            _bs = bs;
            _bbts = bbts;
            _bts = bts;
        }
        // GET: Admin/AdminBox
        public ActionResult Index()
        {
            var model = _bbts.GetAllBoxBoxType().Result;
            return View(model);
        }



        public ActionResult Create()
        {
            GetViewBagData();
            return View();
        }
        public void GetViewBagData()
        {
            ViewBag.BoxType = new SelectList(_bts.GetBoxTypes().Result, "ID", "Type");
        }

        [HttpPost]
        public ActionResult Create(BoxDTO model)
        {
            if (ModelState.IsValid)
            {
                // boxtype name i verilip ox type ID si dmnen servis yazılacak
                // var boxTypeID = _bts.GetBoxTypes().Result.Where(x => x.Type == model.).Select(x => x.ID).FirstOrDefault();
                BoxDTO boxDTO = new BoxDTO
                {
                    BoxName = model.BoxName,
                    BoxTypeID = model.BoxTypeID,
                    Description = model.Description,
                    ImageUrl = model.ImageUrl,
                    Price = model.Price,
                    UnitsInStock = model.UnitsInStock
                };
                var result = _bs.AddBox(boxDTO);

                return RedirectToAction("Index", "AdminBox");
            }
            GetViewBagData();
            return View();
        }


        //Get Edit
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var result = _bs.GetBoxById(id);
            BoxDTO boxDTO = result.Result;

            if (boxDTO == null)
            {
                return HttpNotFound();
            }
            GetViewBagData();
            return View("Edit", boxDTO);
        }

        //Post Edit
        [HttpPost]
        public ActionResult Edit(BoxDTO boxDTO)
        {
            if (ModelState.IsValid)
            {
                //  var result = _bs.UpdateBox(boxDTO.ID);
                var result = _bs.UpdateBox(boxDTO);

                return RedirectToAction("Index", "AdminBox");
            }
            GetViewBagData();
            return View(boxDTO);
        }

        //Get Details
        public ActionResult Details(int id)
        {
            BoxDTO boxDTO = _bs.GetBoxById(id).Result;
            if (boxDTO == null)
            {
                return HttpNotFound();
            }
            return View(boxDTO);
        }

        //Get Delete
        public ActionResult Delete(int id)
        {
            BoxDTO boxDTO = _bs.GetBoxById(id).Result;
            if (boxDTO == null)
            {
                return HttpNotFound();
            }
            return View(boxDTO);

        }

        //Post Delete Confirmed
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var result = _bs.DeleteBox(id);
            return RedirectToAction("Index");
        }

        //protected override void Dispose(bool disposing)
        //{
        //    base.Dispose(disposing);
        //}
    }
}