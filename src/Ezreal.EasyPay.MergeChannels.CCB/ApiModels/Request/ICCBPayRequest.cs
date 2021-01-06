using System;
using System.Collections.Generic;
using System.Text;
using Ezreal.EasyPay.Abstractions.ApiModels.Request;
using Ezreal.EasyPay.Abstractions.Attributes;

namespace Ezreal.EasyPay.MergeChannels.CCB.ApiModels.Request
{
    public interface  ICCBPayRequest : IRequestModel
    {

        /// <summary>
        /// 交易代码
        /// </summary>
        string TXCODE { get;}
    }
}
