using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Category : IEntity
    {
        public Category()
        {
            Products = new HashSet<Box>();
        }

        public Guid Id { get; set; }
        public string CategoryName { get; set; }
        public string  Description { get; set; }
        public bool IsDelete { get ; set ; }


        public virtual ICollection<Box> Products { get; set; }
    }
}
