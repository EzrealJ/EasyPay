using System;
using System.Collections.Generic;
using System.Text;
using Ezreal.EasyPay.Abstractions.ApiParameterModels.Request;
using Ezreal.EasyPay.Abstractions.Attributes;
using WebApiClient.DataAnnotations;

namespace Ezreal.EasyPay.MergeChannels.CCB.ApiParameterModels.Request
{
    public abstract class CCBPayRequest : IRequestModel
    {
        /// <summary>
        /// 商户代码
        /// </summary>
        [AliasAs("MERCHANTID")]
        [SignOrder(0)]
        public string MerchantId { get; set; }
        /// <summary>
        /// 柜台代码
        /// </summary>
        [AliasAs("POSID")]
        [SignOrder(1)]
        public string PosId { get; set; }

        /// <summary>
        /// 分行代码
        /// </summary>
        [AliasAs("BRANCHID")]
        [SignOrder(2)]
        public string BranchId { get; set; }
        /// <summary>
        /// 交易代码
        /// </summary>
        [AliasAs("TXCODE")]
        public abstract string TXCODE { get;}
    }
}
