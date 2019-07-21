using Bll.Abstract.EntityType;
using DTOs.DTOModels.EntityDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SupriseBox.MvcUI.Controllers
{
    public class ManageBasket
    {
        IBoxService _bs;
        public ManageBasket(IBoxService bs)
        {
            _bs = bs;
            if (HttpContext.Current.Session["cartDetails"] == null)
            {
                List<OrderDetailDTO> orders = new List<OrderDetailDTO>();
                HttpContext.Current.Session["cartDetails"] = orders;

            }
        }

        public object AddBoxToBasket (int BoxID)
        {
            object JsonData = null;
            var box = _bs.GetBoxById(BoxID);
            var selectedBox = ((List<OrderDetailDTO>)HttpContext.Current.Session["cartDetails"]).Where(x => x.BoxID == BoxID).FirstOrDefault(); //Sepette verilen id ye göre olan kutu getirilir

            if (selectedBox != null)//O kutu sepete atıldıysa işlem yapılmaz
            {
                JsonData = new { message = " isimli ürün mevcut sayı arttırmak ıcın sepetinize gidiniz", box = box.Result.BoxName };
            }
            else //Sepette o kutu yoksa yeni bir OrderDetail oluşturularak bilgileri alınır.
            {
                var orderDetail = new OrderDetailDTO()
                {
                    BoxID = box.Result.ID,
                    BoxName = box.Result.BoxName,
                    UnitPrice = box.Result.Price,
                    ImageUrl = box.Result.ImageUrl,
                    OrderDate = DateTime.Now
                };

                ((List<OrderDetailDTO>)HttpContext.Current.Session["cartDetails"]).Add(orderDetail);
                JsonData = new { message = " isimli ürün sepete başarıyla eklenmiştir", box = box.Result.BoxName };
            }

            return JsonData;
        }
    }
}