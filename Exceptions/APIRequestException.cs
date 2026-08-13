using Firisbe.Worker.Exception.Handler.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Firisbe.Worker.Exception.Handler.Exceptions
{
    public class APIRequestException : FirisbeException
    {
        public ErrorCategory ErrorCategory = ErrorCategory.ExternalSystem;
        public APIRequestException(string Message,string path,HttpStatusCode statusCode) : base(Message + $" Path : {path} Status Code :{statusCode.ToString()}")
        {
            switch (statusCode) {
                case HttpStatusCode.Unauthorized:
                case HttpStatusCode.Forbidden:
                case HttpStatusCode.NotImplemented:
                case HttpStatusCode.BadGateway:
                    ErrorCategory = ErrorCategory.ExternalSystem;
                    break;
                case HttpStatusCode.BadRequest:
                case HttpStatusCode.NotFound:
                case HttpStatusCode.Conflict:
                case HttpStatusCode.RequestTimeout:
                    ErrorCategory = ErrorCategory.Business;
                    break;
            }
        }

    }
}
