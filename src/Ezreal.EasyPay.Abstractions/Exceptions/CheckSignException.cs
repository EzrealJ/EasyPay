using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Ezreal.EasyPay.Abstractions.Exceptions
{
    /// <summary>
    /// 校验签名异常
    /// </summary>
    public class CheckSignException : Exception
    {
        public CheckSignException()
        {
        }

        public CheckSignException(string message) : base(message)
        {
        }

        public CheckSignException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected CheckSignException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
