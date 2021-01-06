using System;
using System.Collections.Generic;
using System.Text;

namespace Ezreal.EasyPay.MergeChannels.CCB.ApiModels.Response
{
   public abstract class CCBPayCommonResponseModel: CCBPayResponse
    {
        /// <summary>
        /// 结果
        /// </summary>
        public string RESULT { get; set; }
        /// <summary>
        /// 订单号
        /// </summary>
        public string ORDERID { get; set; }

        /// <summary>
        /// 错误码
        /// </summary>
        public string ERRCODE { get; set; }
        /// <summary>
        /// 错误信息
        /// </summary>
        public string ERRMSG { get; set; }
        /// <summary>
        /// 签名
        /// </summary>
        public string SIGN { get; set; }
    }
}
