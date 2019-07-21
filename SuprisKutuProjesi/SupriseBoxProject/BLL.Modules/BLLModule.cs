using Bll.Abstract.ComplexType;
using Bll.Abstract.EntityType;
using BLL.Absract;
using BLL.ComplexType;
using BLL.EntityType;
using Core.DAL;
using Core.DAL.SqlServer.EntityFramework;
using Dal;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Module
{
    public class BLLModule : NinjectModule
    {
        public override void Load()
        {
            Kernel.Bind<IUnitOfWork>().To<UnitOfWork>().InSingletonScope();
            //Kernel.Bind<ICategoryService>().To<CategoryService>();
            //Kernel.Bind<IProductService>().To<ProductService>();
            //Kernel.Bind<IProductCategoryService>().To<ProductCategoryService>();
            Kernel.Bind<IBoxService>().To<BoxService>();
            Kernel.Bind<IUserService>().To<UserService>();
            
            Kernel.Bind<ICustomerUserService>().To<CustomerUserService>();
            Kernel.Bind<IBoxBoxTypeService>().To<BoxBoxTypeService>();
            Kernel.Bind<IBoxTypeService>().To<BoxTypeService>();
            Kernel.Bind<IProductService>().To<ProductService>();
            Kernel.Bind<IOrderService>().To<OrderService>();
            Kernel.Bind<IOrderDetailService>().To<OrderDetailService>();
            Kernel.Bind<IOrderOrderDetailService>().To<OrderOrderDetailService>();


            List<INinjectModule> moduleList = new List<INinjectModule>();
#if DEBUG
             moduleList.Add(new Dal.DalModule());
#else
            moduleList.Add(new Dal.Canli.DalModule());
#endif
            Kernel.Load(moduleList);
        }
    }
}
