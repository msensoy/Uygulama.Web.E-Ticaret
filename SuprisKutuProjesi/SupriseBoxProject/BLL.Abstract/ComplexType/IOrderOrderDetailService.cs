using Common;
using Dtos.DTOModels.ComplexDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.Abstract.ComplexType
{
    public interface IOrderOrderDetailService
    {
        ServiceResult AddOrderOrderDetail(OrderOrderDetailDTO orders);
    }
}
