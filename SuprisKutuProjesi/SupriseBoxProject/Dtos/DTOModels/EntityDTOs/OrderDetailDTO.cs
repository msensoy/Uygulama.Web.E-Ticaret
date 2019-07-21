using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.DTOModels.EntityDTOs
{
    public class OrderDetailDTO
    {
        public OrderDetailDTO()
        {
            BoxAmount = 1;
        }
        public int ID { get; set; }
        public int BoxID { get; set; }
        public string BoxName { get; set; }
        public int OrderID { get; set; }
        public int BoxAmount { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalAmount { get; set; }
        public string ImageUrl { get; set; }
        public Nullable<System.DateTime> OrderDate { get; set; }
        public bool IsDelete { get; set; }
    }
}
