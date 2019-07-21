using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.DTOModels.ComplexDTOs
{
   public class ProductCategoryDTO
    {
        public string  ProductName { get; set; }
        
        public string  CategoryName { get; set; }

        public decimal  Price { get; set; }
    }
}
