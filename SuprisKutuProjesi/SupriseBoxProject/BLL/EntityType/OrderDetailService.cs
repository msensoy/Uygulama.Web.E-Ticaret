using Bll.Abstract.EntityType;
using BLL.Base;
using Common;
using Core.DAL;
using DTOs.DTOModels.EntityDTOs;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.EntityType
{
    public class OrderDetailService : BaseService<Order>, IOrderDetailService
    {
        IRepository<OrderDetail> _odr;
        IUnitOfWork _uow;
         
        public OrderDetailService(IUnitOfWork uow)
        {
            _uow = uow;
            _odr = uow.GetRepository<OrderDetail>();
        }
        public ServiceResult CreateOrderDetail(OrderDetailDTO orderDetail)
        {
            int ess = 0;
            var od= Helper.Helpers.Mapping<OrderDetailDTO, OrderDetail>(orderDetail);
            ess = _odr.Add(od);
            if (ess > 0)
            {
                return new ServiceResult(ProcessStateEnum.Success, "Kayıt başarılı");
            }
            else
            {
                return new ServiceResult(ProcessStateEnum.Warning, "Herhangi değişiklik algılanmadığından kayıt yapılmamıştır.");
            }
        }
    }
}
