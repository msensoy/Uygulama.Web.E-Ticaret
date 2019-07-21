using Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityMapping.EntityMappings
{
    public class CustomerMapping :EntityTypeConfiguration<Customer>
    {
        public CustomerMapping()
        {
            Property(e => e.FirstName)
                .IsUnicode(false)
                .IsRequired()
                .HasMaxLength(20);

            Property(e => e.LastName)
                .IsUnicode(false)
                .IsRequired()
                .HasMaxLength(20);

            HasMany(e => e.Members)
                .WithRequired(e => e.Customer)
                .HasForeignKey(e => e.CustomerID)
                .WillCascadeOnDelete(false);

            HasMany(e => e.Orders)
                .WithRequired(e => e.Customer)
                .WillCascadeOnDelete(false);

         
        }
    }
}
