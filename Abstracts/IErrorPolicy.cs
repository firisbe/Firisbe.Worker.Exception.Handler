using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firisbe.Worker.Exception.Handler.Abstracts
{
    public interface IErrorPolicy<T> where T : ErrorContext
    {
        Task ApplyAsync(T context);
    }
}
