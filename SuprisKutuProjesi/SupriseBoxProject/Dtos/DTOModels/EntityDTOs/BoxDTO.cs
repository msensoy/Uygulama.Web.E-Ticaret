using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.DTOModels.EntityDTOs
{
    public class BoxDTO
    {
        public int ID { get; set; }
        public string BoxName { get; set; }
        public int BoxTypeID { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public int UnitsInStock { get; set; }
        public decimal Price { get; set; }
        public bool IsDelete { get; set; }
    }
}
