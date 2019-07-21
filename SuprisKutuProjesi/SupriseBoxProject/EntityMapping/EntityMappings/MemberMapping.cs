using Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityMapping.EntityMappings
{
    public class MemberMapping:EntityTypeConfiguration<Member>
    {
        public MemberMapping()
        {
            Property(m => m.StartDate)
                .HasColumnType("date");

            Property(m => m.EndDate)
                .HasColumnType("date");

            Property(m => m.CustomerID)
                .IsRequired();

            Property(m => m.MemberTypeID)
                .IsRequired();

            Property(m => m.UserID)
                .IsRequired();

            
        }
    }
}
