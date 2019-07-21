using Bll.Abstract.EntityType;
using BLL.Base;
using Common;
using Core.DAL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.EntityType
{
    public class UserService : BaseService<User>, IUserService
    {
        IUnitOfWork _uow;
        IRepository<User> _ur;
        public UserService(IUnitOfWork uow)
        {
            _uow = uow;
            _ur = _uow.GetRepository<User>();
        }

        public ServiceResult<IEnumerable<User>> GetAllUsers()
        {
            try
            {
                var result = _ur.GetList();
                return new ServiceResult<IEnumerable<User>>(ProcessStateEnum.Success, "Kullanıcılar başarıyla listelendi.", result);
            }
            catch (Exception)
            {
                return new ServiceResult<IEnumerable<User>>(ProcessStateEnum.Error, "Bir hata oluştu.", null);
            }
           
        }


        public ServiceResult<User> GetUserByUserName(string userName)
        {
            try
            {
                var result = _ur.GetQuery().Where(u => u.UserName == userName).SingleOrDefault();
                if (result!=null)
                {
                    return new ServiceResult<User>(ProcessStateEnum.Success, "İşlem başarılı.", result);
                }
                else
                {
                    return new ServiceResult<User>(ProcessStateEnum.Warning, "Bu kullanıcı adına ait bir kullanıcı bulunamadı.", null);
                }
            }
            catch (Exception ex)
            {
                return new ServiceResult<User>(ProcessStateEnum.Error,ex.Message, null);
            }
        }
    }
}
