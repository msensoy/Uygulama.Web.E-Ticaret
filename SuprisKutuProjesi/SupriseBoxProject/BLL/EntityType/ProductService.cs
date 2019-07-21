using BLL.Absract;
using BLL.Base;
using Common;
using Core.DAL;
using Dtos.DTOModels.EntityDTOs;
using Entity;
using Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.EntityType
{
    public class ProductService : BaseService<Product>, IProductService
    {
        // IUnitOfWork _uow;
        // public ProductService(IUnitOfWork uow)
        // {
        //     _uow = uow;
        // }

        // public ServiceResult AddProduct(Box product)
        // {
        //     //validation
        //     if(product.Price<=0)
        //     {
        //         return new ServiceResult(ProcessStateEnum.Error, "Ürün fiyatı 0 dan büyük olmalıdır.");
        //     }

        //     try
        //     {
        //         int ess = _uow.GetRepository<Box>().Add(product);
        //         if (ess > 0)
        //         {
        //             return new ServiceResult(ProcessStateEnum.Success, "Kayıt Başarılıdır");
        //         }
        //         else
        //         {
        //             return new ServiceResult(ProcessStateEnum.Warning, "Herhangi kayıt yapılmadı.");
        //         }
        //     }
        //     catch (Exception e)
        //     {
        //         //exception log.. (kaydedilecek ögeyi git json a serilize et ve db ye kaydet...)
        //         return new ServiceResult(ProcessStateEnum.Error, "Bir hata nedeniyle kayıt yapılamadı. Lokasyon:12.10, ErrorKod:"+e.HResult);
        //     }

        // }

        // public ServiceResult<IEnumerable<Box>> GetProducts()
        // {
        //var result=  _uow.GetRepository<Box>().GetList();
        //     return new ServiceResult<IEnumerable<Box>>(ProcessStateEnum.Success, "Okuma başarılı", result);
        // }
      
        public ServiceResult AddProduct(ProductDTO product)
        {
            throw new NotImplementedException();
        }


        ServiceResult<IEnumerable<ProductDTO>> IProductService.GetProducts()
        {
            throw new NotImplementedException();
        }
    }
}
