using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class ServiceResult<T>: ServiceResult
    {
        public ServiceResult(ProcessStateEnum state, string message, T result):base(state,message)
        {
            Result = result;
        }
        public T Result { get; set; }

    }
    public class ServiceResult
    {
        public ServiceResult(ProcessStateEnum state, string message)
        {
            Message = message;
            State = state;
        }
        public string Message { get; set; }
        public ProcessStateEnum State { get; set; }
    }
}
