using Common;
using Dtos.DTOModels.EntityDTOs;
using Entity;
using Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Absract
{
    public interface IProductService:IService<ProductDTO>
    {
        ServiceResult<IEnumerable<ProductDTO>> GetProducts();
        ServiceResult AddProduct(ProductDTO product);
    }
}
