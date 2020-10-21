using System;
using System.Collections.Generic;
using System.Text;

namespace Ezreal.EasyPay.Abstractions.Attributes
{
    /// <summary>
    /// 签名排序
    /// </summary>
    public class SignOrderAttribute : Attribute
    {
        public SignOrderAttribute(int order)
        {
            Order = order;
        }

        public int Order { get; }
    }
}
