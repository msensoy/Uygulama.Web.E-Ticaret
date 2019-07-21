using Bll.Abstract.ComplexType;
using Bll.Abstract.EntityType;
using Dtos.DTOModels.ComplexDTOs;
using DTOs.DTOModels.EntityDTOs;
using SupriseBox.MvcUI.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SupriseBox.MvcUI.Controllers
{
    [Auth]
    public class CheckOutController : Controller
    {
        ICustomerUserService _cus;
        IOrderOrderDetailService _oods;


        

        public CheckOutController(ICustomerUserService cus,IOrderOrderDetailService oods )
        {
            _cus = cus;
            _oods = oods;

        }
        // GET: CheckOut
        
        public ActionResult Index()
        {
            var userID = (int?)Session["userID"];
            if (userID!=null)
            {
                var model = _cus.GetCustomerUserByUserId(userID.Value);
                if (model.Result!= null)
                {
                    ViewBag.currentUser=(model.Result);
                }
            }
            var boxes = (List<OrderDetailDTO>)Session["cartDetails"];
            var SubTotal = boxes.Sum(x => x.TotalAmount);
            ViewBag.SubTotal = SubTotal;
            return View(boxes);
        }


        [HttpPost]
        public ActionResult PlaceOrder(OrderDTO model)
        {
            var orderDetails = (List<OrderDetailDTO>)Session["cartDetails"];

            var customerID = model.CustomerID;
            var adress = model.Adress;

            var orderOrderDetailDto = new OrderOrderDetailDTO()
            {
                CustomerID = customerID,
                Adress = adress,
                OrderDate = DateTime.Now,
                SelectedOrders = orderDetails
            };

            _oods.AddOrderOrderDetail(orderOrderDetailDto);



            //alttakine benzer bi kod bloğu olacak sipariş bilgilerini aldıktan sonra
            //id leri transaction ile ayarlamamız gerekiyor bi hata olursa o siparişi oluşturmasın db de diye

            //ShippingDetail shpDetails = new ShippingDetail();
            //shpDetails.ShippingID = shpID;
            //shpDetails.FirstName = getCheckoutDetails["FirstName"];
            //shpDetails.LastName = getCheckoutDetails["LastName"];
            //shpDetails.Email = getCheckoutDetails["Email"];
            //shpDetails.Mobile = getCheckoutDetails["Mobile"];
            //shpDetails.Address = getCheckoutDetails["Address"];
            //shpDetails.Province = getCheckoutDetails["Province"];
            //shpDetails.City = getCheckoutDetails["City"];
            //shpDetails.PostCode = getCheckoutDetails["PostCode"];
            //db.ShippingDetails.Add(shpDetails);
            //db.SaveChanges();

            //Payment pay = new Payment();
            //pay.PaymentID = payID;
            //pay.Type = Convert.ToInt32(getCheckoutDetails["PayMethod"]);
            //db.Payments.Add(pay);
            //db.SaveChanges();

            //Order o = new Order();
            //o.OrderID = orderID;
            //o.CustomerID = TempShpData.UserID;
            //o.PaymentID = payID;
            //o.ShippingID = shpID;
            //o.Discount = Convert.ToInt32(getCheckoutDetails["discount"]);
            //o.TotalAmount = Convert.ToInt32(getCheckoutDetails["totalAmount"]);
            //o.isCompleted = true;
            //o.OrderDate = DateTime.Now;
            //db.Orders.Add(o);
            //db.SaveChanges();

            //foreach (var OD in TempShpData.items)
            //{
            //    OD.OrderID = orderID;
            //    OD.Order = db.Orders.Find(orderID);
            //    OD.Product = db.Products.Find(OD.ProductID);
            //    db.OrderDetails.Add(OD);
            //    db.SaveChanges();
            //}


            //return RedirectToAction("Index", "ThankYou");



            //_uow.BeginTran();
            //try
            //{
            //    Customer newCustomer = new Customer();
            //    newCustomer.UserID = newUser.ID;
            //    newCustomer.FirstName = customeruser.FirstName;
            //    newCustomer.LastName = customeruser.LastName;
            //    newCustomer.Email = customeruser.eMail;
            //    _cr.Add(newCustomer);

            //    _uow.CommitTran();
            //    return new ServiceResult(ProcessStateEnum.Success, "Kayıt başarıyla yapılmıştır.");
            //}
            //catch (Exception)
            //{
            //    _uow.RollBackTran();
            //    return new ServiceResult(ProcessStateEnum.Error, "Bir hata nedeniyle kayıt yapılamamıştır.");
            //}

            return RedirectToAction("Confirmation", "CheckOut");
        }


        public ActionResult Confirmation()
        {
            return View();
        }
    }
}