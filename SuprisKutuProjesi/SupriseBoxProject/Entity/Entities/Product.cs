using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entities
{
    public class Product : IEntity
    {
        public Product()
        {
            Boxes = new HashSet<Box>();
        }
        public int ID { get; set; }
        public string ProductName { get; set; }
        public string Stock { get; set; }
        public decimal Price { get; set; }
        public bool IsDelete { get ; set; }

        public virtual ICollection<Box> Boxes { get; set; }
    }
}
