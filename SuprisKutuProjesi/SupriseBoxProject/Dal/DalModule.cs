using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class DalModule : NinjectModule
    {
        public override void Load()
        {
        
            Kernel.Bind<DbContext>().To<SurpriseBoxDbContext>();
        }
    }
}
