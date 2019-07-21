namespace Entity
{
    using Common;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Customer : IEntity
    {
        public Customer()
        {
            Members = new HashSet<Member>();
            Orders = new HashSet<Order>();
        }

        public int ID { get; set; }

 
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int UserID { get; set; }

        public virtual User User { get; set; }

        public bool IsDelete { get; set; }

        [StringLength(35)]
        public string Email { get; set; }

        public virtual ICollection<Member> Members { get; set; }


        public virtual ICollection<Order> Orders { get; set; }

    }
}
