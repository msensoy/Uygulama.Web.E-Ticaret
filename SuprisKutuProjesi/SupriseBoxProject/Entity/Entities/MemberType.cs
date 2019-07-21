namespace Entity
{
    using Common;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;


    public class MemberType : IEntity
    {
        public MemberType()
        {
            Members = new HashSet<Member>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(10)]
        public string Type { get; set; }

        public virtual ICollection<Member> Members { get; set; }
        public bool IsDelete { get ; set; }
    }
}
