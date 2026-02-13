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
    public class APIRequestException : HttpRequestException
    {
        public ErrorCategory ErrorCategory = ErrorCategory.ExternalSystem;
        public APIRequestException(string Message,string path,HttpStatusCode statusCode) : base(Message + $" Path : {path} Status Code :{statusCode.ToString()}")
        {
        }

    }
}
