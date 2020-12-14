using System;
using System.Collections.Generic;
using System.Text;
using Ezreal.EasyPay.Abstractions.ApiParameterModels.Request;
using Ezreal.EasyPay.Abstractions.Attributes;

namespace Ezreal.EasyPay.MergeChannels.CCB.ApiParameterModels.Request
{
    public interface  ICCBPayRequest : IRequestModel
    {

        /// <summary>
        /// 交易代码
        /// </summary>
        string TXCODE { get;}
    }
}
