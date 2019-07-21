using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.DTOModels.ComplexDTOs
{
    public class BoxBoxTypeDTO
    {
        public int BoxID { get; set; }
        public string BoxName { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string BoxType { get; set; }
        public int UnitsInStock { get; set; }
        public bool IsDelete { get; set; }
    }
}
