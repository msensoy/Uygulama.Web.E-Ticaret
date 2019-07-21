using BLL.Absract;
using Common;
using DTOs.DTOModels.EntityDTOs;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.Abstract.EntityType
{
    public interface IOrderDetailService:IService<OrderDetail>
    {
        ServiceResult CreateOrderDetail(OrderDetailDTO OrderDetail);
    }
}
