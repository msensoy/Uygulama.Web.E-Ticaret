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
    public class CustomerUserService : ICustomerUserService
    {
        IUnitOfWork _uow;
        IRepository<Customer> _cr;
        IRepository<User> _ur;
        public CustomerUserService(IUnitOfWork uow)
        {
            _uow = uow;
            _cr = _uow.GetRepository<Customer>();
            _ur = _uow.GetRepository<User>();
        }
        public ServiceResult AddCustomerUser(CustomerUserDTO customeruser)
        {
            User newUser = new User();
            newUser.UserName = customeruser.UserName;
            newUser.Password = customeruser.Password;


            _ur.Add(newUser);

            _uow.BeginTran();
            try
            {
                Customer newCustomer = new Customer();
                newCustomer.UserID = newUser.ID;
                newCustomer.FirstName = customeruser.FirstName;
                newCustomer.LastName = customeruser.LastName;
                newCustomer.Email = customeruser.eMail;
                _cr.Add(newCustomer);

                _uow.CommitTran();
                return new ServiceResult(ProcessStateEnum.Success, "Kayıt başarıyla yapılmıştır.");
            }
            catch (Exception)
            {
                _uow.RollBackTran();
                return new ServiceResult(ProcessStateEnum.Error, "Bir hata nedeniyle kayıt yapılamamıştır.");
            }


        }

        public ServiceResult<CustomerUserDTO> GetCustomerUserByUserId(int id)
        {
            var sorgu = from c in _cr.GetQuery()
                        join u in _ur.GetQuery() on c.UserID equals u.ID
                        where u.ID == id
                        select new CustomerUserDTO
                        {
                            CustomerID=c.ID,
                            UserName = u.UserName,
                            FirstName = c.FirstName,
                            LastName = c.LastName,
                            eMail = c.Email,
                        };
            var result = sorgu.FirstOrDefault();


            if (result == null)
            {
                return new ServiceResult<CustomerUserDTO>(ProcessStateEnum.Warning, "Kullanıcı bulunamadı", null);
            }

            return new ServiceResult<CustomerUserDTO>(ProcessStateEnum.Success, "Kullanıcı işlemi başarılı.", result);

        }
    }
}
