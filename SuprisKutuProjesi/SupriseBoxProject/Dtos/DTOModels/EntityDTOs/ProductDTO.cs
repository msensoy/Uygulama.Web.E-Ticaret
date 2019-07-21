using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.DTOModels.EntityDTOs
{
    public class ProductDTO
    {
        
        public int ID { get; set; }
        public string ProductName { get; set; }
        public string Stock { get; set; }
        public decimal Price { get; set; }
        public bool IsDelete { get; set; }

    
    }
}
