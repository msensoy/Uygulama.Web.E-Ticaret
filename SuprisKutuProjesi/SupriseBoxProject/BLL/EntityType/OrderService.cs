using Bll.Abstract.EntityType;
using BLL.Base;
using Common;
using Core.DAL;
using DTOs.DTOModels.EntityDTOs;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL.EntityType
{
    public class OrderService : BaseService<Order>, IOrderService
    {
        IRepository<Order> _or;
        IUnitOfWork _uow;
        public OrderService(IUnitOfWork uow)
        {
            _uow = uow;
            _or = uow.GetRepository<Order>();

        }
        public ServiceResult CreateOrder(OrderDTO orderDTO)
        {
            int ess = 0;
            Order order = new Order();
            order =Helper.Helpers.Mapping<OrderDTO,Order>(orderDTO);
            ess = _or.Add(order);

            if (ess > 0)
            {
                return new ServiceResult(ProcessStateEnum.Success, "Kayıt Başarılı");
            }
            else
            {
                return new ServiceResult(ProcessStateEnum.Warning, "Herhangi bir değişiklik algılanmadığından kayıt yapılamamıştır");
            }

        }

        public ServiceResult<IEnumerable<OrderDTO>> GetOrders()
        {
            var orders = _or.GetList();
 
            if (orders.Count==0)
            {
                return new ServiceResult<IEnumerable<OrderDTO>>(ProcessStateEnum.Warning, "Gösterecek order bulunamadı", null);
            }
            var ordersDTOs = Helper.Helpers.Mapping<Order, OrderDTO>(orders);
            return new ServiceResult<IEnumerable<OrderDTO>>(ProcessStateEnum.Success, "", ordersDTOs);

        }
    }
}
