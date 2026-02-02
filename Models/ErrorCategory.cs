using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firisbe.Worker.Exception.Handler.Models
{
    public enum ErrorCategory
    {
        Unknown,          // default error category
        Business,        // validation, format, kural ihlali, batch ile alakalı hatalar
        ExternalSystem,  // API vb. kaynaklardan gelen hatalar
        Infrastructure   // DB, network, timeout,dosya silme hataları.
    }
}
