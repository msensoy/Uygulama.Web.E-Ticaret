namespace Entity
{
    using Common;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public class Member : IEntity
    {

        public int ID { get; set; }

       
        public int CustomerID { get; set; }

        public int MemberTypeID { get; set; }

        [Column(TypeName = "date")]
        public DateTime StartDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime EndDate { get; set; }

        public int UserID { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual MemberType MemberType { get; set; }
        public bool IsDelete { get ; set ; }
    }
}
