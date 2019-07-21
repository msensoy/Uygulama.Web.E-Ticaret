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
    public interface ICustomerService:IService<Customer>
    {
        ServiceResult<IEnumerable<Customer>> AddCustomer(Customer customer);
        ServiceResult<IEnumerable<Customer>> GetAllCustomers();
        
    }
}
