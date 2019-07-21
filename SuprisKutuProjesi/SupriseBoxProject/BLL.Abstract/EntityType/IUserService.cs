using BLL.Absract;
using Common;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.Abstract.EntityType
{
    public interface IUserService:IService<User>
    {
        ServiceResult<IEnumerable<User>> GetAllUsers();
        ServiceResult<User> GetUserByUserName(string userName);

    }
}
