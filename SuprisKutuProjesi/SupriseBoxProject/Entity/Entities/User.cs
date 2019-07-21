namespace Entity
{
    using Common;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;


    public class User : IEntity
    {
        public User()
        {
            Customers = new HashSet<Customer>();
            Roles = new HashSet<Role>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(15)]
        public string UserName { get; set; }

        [Required]
        [StringLength(15)]
        public string Password { get; set; }

        public virtual ICollection<Customer> Customers { get; set; }

        public virtual ICollection<Role> Roles { get; set; }
        public bool IsDelete { get; set; }
    }
}
