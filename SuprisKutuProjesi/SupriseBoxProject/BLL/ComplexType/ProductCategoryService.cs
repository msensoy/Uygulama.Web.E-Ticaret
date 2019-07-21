using Bll.Abstract.ComplexType;
using Common;
using Core.DAL;
using DTOs.DTOModels.ComplexDTOs;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.ComplexType
{
    public class ProductCategoryService : IProductCategoryService
    {
        //IUnitOfWork _uow;
        //IRepository<Category> _cr;
        //IRepository<Box> _pr;
        //public ProductCategoryService(IUnitOfWork uow)
        //{
        //    _uow = uow;
        //    _cr = _uow.GetRepository<Category>();
        //    _pr = _uow.GetRepository<Box>();
        //}
        //public ServiceResult<IEnumerable<ProductCategoryDto>> GetProductCategoryList()
        //{
        //    var sorgu = (from c in _cr.GetQuery()
        //                 join p in _pr.GetQuery() on c.Id equals p.CategoryId
        //                 select new ProductCategoryDto
        //                 {
        //                     CategoryName = c.CategoryName,
        //                     Price = p.Price,
        //                     ProductName = p.ProductName
        //                 });

        //    var result = sorgu.ToList();

        //    return new ServiceResult<IEnumerable<ProductCategoryDto>>(ProcessStateEnum.Success, "kayıt başarıyla okundu", result);
        //}
        public ServiceResult<IEnumerable<ProductCategoryDTO>> GetProductCategoryList()
        {
            throw new NotImplementedException();
        }
    }
}
