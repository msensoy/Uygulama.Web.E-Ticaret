using Common;
using DTOs.DTOModels.ComplexDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.Abstract.ComplexType
{
   public interface IProductCategoryService
    {
        ServiceResult<IEnumerable<ProductCategoryDTO>> GetProductCategoryList();
    }
}
