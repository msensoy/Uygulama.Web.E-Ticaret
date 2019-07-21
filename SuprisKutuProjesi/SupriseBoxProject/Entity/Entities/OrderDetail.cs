namespace Entity
{
    using Common;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;


    public class OrderDetail : IEntity
    {
     
        public int ID { get; set; }
        public int BoxID { get; set; }
        public int OrderID { get; set; }
        public int BoxAmount { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalAmount { get; set; }
        public Nullable<System.DateTime> OrderDate { get; set; }

        public virtual Box Box { get; set; }
        public virtual Order Order { get; set; }

        public bool IsDelete { get; set ; }
    }
}
