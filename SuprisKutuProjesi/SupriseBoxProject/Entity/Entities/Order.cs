namespace Entity
{
    using Common;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;


    public class Order : IEntity
    {
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int ID { get; set; }

        [Column(TypeName = "date")]
        public DateTime OrderDate { get; set; }

        public int CustomerID { get; set; }

        public string Adress { get; set; }

        public decimal SubTotal { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public bool IsDelete { get ; set; }
    }
}
