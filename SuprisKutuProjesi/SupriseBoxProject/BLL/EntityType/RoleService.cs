using Bll.Abstract.EntityType;
using Core.DAL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.EntityType
{
    public class RoleService : IRoleService
    {
        IUnitOfWork _uow;
        IRepository<User> _ur;
        IRepository<Role> _rr;
        
        public RoleService(IUnitOfWork uow)
        {
            _uow = uow;
            _ur = _uow.GetRepository<User>();
            _rr = _uow.GetRepository<Role>();

        }
        public string GetUserRole(string userName)
        {
            var user = _ur.Get(x => x.UserName == userName);

            if (user!=null)
            {
              
            }
            return null;
        }
    }
}
