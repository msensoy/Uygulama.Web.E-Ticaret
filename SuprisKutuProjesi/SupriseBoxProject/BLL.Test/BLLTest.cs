using System;
using BLL;
using BLL.Absract;
using BLL.Module;
using Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;

namespace Project.Test
{
    [TestClass]
    public class BLLTest
    {
        public static IKernel Kernel { get; protected set; }
        

        private void IocRegister()
        {
            Kernel = new StandardKernel();
            Kernel.Load(new BLLModule());

            
        }

        //[TestMethod]
        //public void InsertCategory()
        //{
        //    IocRegister();
        //    ICategoryService cs = Kernel.Get<ICategoryService>();
        //    Category category = new Category() {

        //        CategoryName = "canli",
        //        Description = "canli",
        //        Id = Guid.NewGuid(),
        //         IsDelete=false,
        //    };
        //    cs.AddCategory(category);
        //}

        //[TestMethod]
        //public void InsertProduct()
        //{
        //    IocRegister();
        //    IProductService ps = Kernel.Get<IProductService>();
        //    Product product = new Product()
        //    {
        //        Id = Guid.NewGuid(),
        //        ProductName = "alaf",
        //        CategoryId = Guid.Parse("CB4AA1A1-41E3-47A0-A223-60D3A07288E3"),
        //        IsDelete = false,
        //        Price = 34.56M,
        //        Stock = 10
        //    };
        //    ps.AddProduct(product);
        //}
    }

   
}
