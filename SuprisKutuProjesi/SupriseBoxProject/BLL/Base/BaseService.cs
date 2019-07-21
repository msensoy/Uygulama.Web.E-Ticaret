using BLL.Absract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Base
{
   public class BaseService<T>:IService<T>
        where T:class,new()
    {
    }
}
