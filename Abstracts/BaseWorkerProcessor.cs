using Firisbe.Worker.Exception.Handler.Abstracts;
using Firisbe.Worker.Exception.Handler.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Firisbe.Worker.Handler.Abstracts
{
    public abstract class BaseWorkerProcessor
    {
        protected async Task ExecuteBatchSafelyAsync<T>(
        Func<Task> action,
        IErrorPolicy<T> errorPolicy,
        Func<System.Exception, T> contextFactory) where T : ErrorContext
        {
            try
            {
                await action();
            }
            catch (System.Exception ex)
            {
                T context = contextFactory(ex);
                await errorPolicy.ApplyAsync(context);
            }
        }


       protected virtual ErrorCategory ResolveCategory(System.Exception ex)
        {
            return ex switch
            {
                FirisbeException
                    => ErrorCategory.Business,

                HttpRequestException
                    => ErrorCategory.Infrastructure,

                TimeoutException
                    => ErrorCategory.Infrastructure,

                _ => ErrorCategory.Unknown
            };
        }
    }

}

