using Bll.Abstract.ComplexType;
using Common;
using Core.DAL;
using Dtos.DTOModels.ComplexDTOs;
using DTOs.DTOModels.EntityDTOs;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.ComplexType
{
    public class OrderOrderDetailService:IOrderOrderDetailService
    {
        IUnitOfWork _uow;
        IRepository<Order> _or;
        IRepository<OrderDetail> _odr;
        public OrderOrderDetailService(IUnitOfWork uow)
        {
            _uow = uow;
            _or = uow.GetRepository<Order>();
            _odr = uow.GetRepository<OrderDetail>();
        }

        public ServiceResult AddOrderOrderDetail(OrderOrderDetailDTO orders)
        {
            _uow.BeginTran();

            Order newOrder = new Order()
            {
                CustomerID = orders.CustomerID,
                Adress = orders.Adress,
                OrderDate = orders.OrderDate,
                SubTotal= orders.SelectedOrders.Sum(x => x.TotalAmount)
            };

            _or.Add(newOrder);
            try
            {
                foreach (var item in orders.SelectedOrders)
                {
                    item.OrderID = newOrder.ID;
                    var orderDetail= Helper.Helpers.Mapping<OrderDetailDTO, OrderDetail>(item);
                    _odr.Add(orderDetail);
                    
                }

                _uow.CommitTran();
                return new ServiceResult(ProcessStateEnum.Success, "Kayıt başarıyla yapılmıştır.");

            }
            catch (Exception)
            {
                _uow.RollBackTran();
                return new ServiceResult(ProcessStateEnum.Error, "Bir hata nedeniyle kayıt yapılamamıştır.");
            }
            finally
            {
                _uow.Dispose();
            }


        }
    }
}
