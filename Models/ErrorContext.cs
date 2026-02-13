using Firisbe.Worker.Exception.Handler.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    public class ErrorContext
    {
        public Exception Exception { get; set; }
        public ErrorCategory Category { get; set; }
        public bool IsRetryable { get; set; }
    }

