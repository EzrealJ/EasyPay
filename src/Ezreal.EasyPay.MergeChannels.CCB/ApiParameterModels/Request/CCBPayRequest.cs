using System;
using System.Collections.Generic;
using System.Text;
using Ezreal.EasyPay.Abstractions.ApiParameterModels.Request;
using Ezreal.EasyPay.Abstractions.Attributes;

namespace Ezreal.EasyPay.MergeChannels.CCB.ApiParameterModels.Request
{
    public abstract class CCBPayRequest : IRequestModel
    {
        /// <summary>
        /// 商户代码
        /// </summary>
        [SignOrder(0)]
        public string MERCHANTID { get; set; }
        /// <summary>
        /// 柜台代码
        /// </summary>
        [SignOrder(1)]
        public string POSID { get; set; }

        /// <summary>
        /// 分行代码
        /// </summary>
        [SignOrder(2)]
        public string BRANCHID { get; set; }
        /// <summary>
        /// 交易代码
        /// </summary>
        public abstract string TXCODE { get;}
    }
}
