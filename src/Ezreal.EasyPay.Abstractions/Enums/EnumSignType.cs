using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ezreal.EasyPay.Abstractions.Enums
{
    public enum EnumSignType
    {
        [Description("MD5")]
        MD5 = 0,
        [Description("HMAC-SHA256")]
        HMACSHA256 = 1,
        [Description("RSA")]
        RSA = 2,
        [Description("RSA2")]
        RSA2 = 3,
    }
}
