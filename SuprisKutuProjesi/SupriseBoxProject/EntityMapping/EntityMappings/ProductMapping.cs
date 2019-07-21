using Entity;
using Entity.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityMapping
{
    public class ProductMapping:EntityTypeConfiguration<Product>
    {
        public ProductMapping()
        {
            Property(p => p.ProductName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .IsRequired();

            Property(p => p.Price)
                .HasColumnType("money");

            //Oncekı productun keyi
            //HasRequired(p => p.Category).WithMany(c => c.Products)
            //    .HasForeignKey(p => p.CategoryId)
            //    .WillCascadeOnDelete(false);
        }
    }
}
