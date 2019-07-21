using DTOs.DTOModels.EntityDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.DTOModels.ComplexDTOs
{
    public class OrderOrderDetailDTO
    {
        public int ID { get; set; }
        public DateTime OrderDate { get; set; }
        public int CustomerID { get; set; }
        public string Adress { get; set; }
        public decimal SubTotal { get; set; }
        public bool IsDelete { get; set; }
        public List<OrderDetailDTO> SelectedOrders { get; set; }
    }
}
