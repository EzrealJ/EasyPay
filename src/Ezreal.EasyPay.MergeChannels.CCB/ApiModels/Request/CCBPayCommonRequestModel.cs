using System;
using System.Collections.Generic;
using System.Text;
using Ezreal.EasyPay.MergeChannels.CCB.Enums;

namespace Ezreal.EasyPay.MergeChannels.CCB.ApiModels.Request
{
    public abstract class CCBPayCommonRequestModel
    {
        /// <summary>
        /// 商户代码
        /// </summary>

        public string MERCHANTID { get; set; }
        /// <summary>
        /// 柜台代码
        /// </summary>

        public string POSID { get; set; }

        /// <summary>
        /// 分行代码
        /// </summary>

        public string BRANCHID { get; set; }
        /// <summary>
        /// 商户类型
        /// </summary>

        public EnumMerchantType MERFLAG { get; set; }

        /// <summary>
        /// 商户类型为 <see cref="EnumMerchantType.线下商户"/> 时上送
        /// </summary>
        public string TERMNO1 { get; set; }
        /// <summary>
        /// 商户类型为 <see cref="EnumMerchantType.线下商户"/> 时上送
        /// </summary>
        public string TERMNO2 { get; set; }
        /// <summary>
        /// 订单号
        /// </summary>
        public string ORDERID { get; set; }
    }
}
