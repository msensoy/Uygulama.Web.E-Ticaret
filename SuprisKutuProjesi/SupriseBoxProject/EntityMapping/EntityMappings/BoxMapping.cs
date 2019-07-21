using Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityMapping.EntityMappings
{
    public class BoxMapping :EntityTypeConfiguration<Box>
    {
        public BoxMapping()
        {
            Property(e => e.BoxName)
                .IsRequired()
                .HasMaxLength(20);
                

            Property(e => e.Description)
                .IsUnicode(false)
                .IsRequired()
                .HasMaxLength(100);

            HasMany(e => e.OrderDetails)
                .WithRequired(e => e.Box)
                .WillCascadeOnDelete(false);

            //HasMany(e => e.Interests)
            //    .WithMany(e => e.Boxes)
            //    .Map(m => m.ToTable("BoxInterest").MapLeftKey("BoxID").MapRightKey("InterestID"));

            //HasMany(e => e.Products)
            //    .WithMany(e => e.Boxes)
            //    .Map(m => m.ToTable("BoxProduct").MapLeftKey("BoxID").MapRightKey("ProductID"));
        }
        
    }
}
