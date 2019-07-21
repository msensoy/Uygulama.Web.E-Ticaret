using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Canli
{
    class SurpriseBoxDbContext
    {
#if DEBUG
        public SurpriseBoxDbContext()
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

