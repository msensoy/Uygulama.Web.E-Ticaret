namespace Entity
{
    using Common;
    using Entity.Entities;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Box : IEntity
    {
        public Box()
        {
            OrderDetails = new HashSet<OrderDetail>();
            Products = new HashSet<Product>();
        }

        public int ID { get; set; }

        public int BoxTypeID { get; set; }

       
        public string BoxName { get; set; }
        public decimal Price { get; set; }

        public int UnitsInStock { get; set; }
        public string Description { get; set; }

        public virtual BoxType BoxType { get; set; }

        public string ImageUrl { get; set; }

        public bool IsDelete { get; set; }


        public virtual ICollection<OrderDetail> OrderDetails { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
