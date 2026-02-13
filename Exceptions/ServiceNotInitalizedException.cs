using Firisbe.Worker.Exception.Handler.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firisbe.Worker.Exception.Handler.Exceptions
{
    public class ServiceNotInitalizedException : FirisbeException
    {
        public ServiceNotInitalizedException(string Message) : base(Message)
        {
            base.Category = ErrorCategory.Internal;
        }
    }
}
