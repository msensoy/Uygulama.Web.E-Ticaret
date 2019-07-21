using Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityMapping.EntityMappings
{
    public class MemberTypeMapping: EntityTypeConfiguration<MemberType>
    {
        public MemberTypeMapping()
        {
            ToTable("MemberType");

            Property(m => m.Type)
                .IsRequired()
                .IsUnicode(false)
                .HasMaxLength(10);
        }
    }
}
