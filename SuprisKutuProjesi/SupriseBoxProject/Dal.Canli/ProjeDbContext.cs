using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Canlimmmmmmmmmmmmmmmmmmmmmmmmmmmmmm
{
    public class ProjeCanliDbContext 
    {
#if DEBUG
        public ProjeCanliDbContext()
        {
            throw new Exception("Debug modda canlı dal kullanılamaz.");
        }
#else
         public ProjeCanliDbContext(): base("server=.;database=CanliDB;User ID=sa;password=12345")
        {
            Helper.Helpers.IsTest = false;
        }
#endif

    }
}
