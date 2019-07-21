using Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityMapping.EntityMappings
{
    public class UserMapping:EntityTypeConfiguration<User>
    {
        public UserMapping()
        {
            Property(p => p.UserName)
                .IsRequired()
                .HasMaxLength(15);

            Property(p => p.Password)
                .IsRequired()
                .HasMaxLength(15);


        }
    }
}
