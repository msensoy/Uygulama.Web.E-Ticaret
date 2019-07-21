using Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityMapping.EntityMappings
{
    public class BoxTypeMapping : EntityTypeConfiguration<BoxType>
    {
        public BoxTypeMapping()
        {
            Property(e => e.Type)
                
                .IsUnicode(false)
                .IsRequired()
                .HasMaxLength(20);

            HasMany(e => e.Boxes)
                .WithRequired(e => e.BoxType)
                .WillCascadeOnDelete(false);

        }
    }
}
