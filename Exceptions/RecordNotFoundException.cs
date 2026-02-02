using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firisbe.Worker.Exception.Handler.Exceptions
{
    public class RecordNotFoundException : FirisbeException
    {
        public RecordNotFoundException(string Message,string PrimaryKeyId,string ObjectType) : base(Message + $" Primary Key Id : {PrimaryKeyId} , Object Type: {ObjectType}")
        {
        }
    }
}
