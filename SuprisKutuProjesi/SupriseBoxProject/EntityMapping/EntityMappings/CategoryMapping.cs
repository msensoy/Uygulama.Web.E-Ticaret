using Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityMapping
{
    public class CategoryMapping:EntityTypeConfiguration<Category>
    {
        public CategoryMapping()
        {
            Property(c => c.CategoryName)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsRequired();

            Property(c => c.Description)
               .HasMaxLength(50)
               .IsUnicode(false)
               .IsRequired();



            //HasMany(c=>c.Products).WithRequired(p=>p.Category)
            //    .HasForeignKey(p => p.CategoryId)
            //    .WillCascadeOnDelete(false);
        }
    }
}
