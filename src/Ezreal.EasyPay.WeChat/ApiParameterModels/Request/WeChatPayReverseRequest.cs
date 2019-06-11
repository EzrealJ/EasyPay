using System.Collections.Generic;
using Ezreal.EasyPay.WeChat.ApiParameterModels.Response;

namespace Ezreal.EasyPay.WeChat.ApiParameterModels.Request
{
    /// <summary>
    /// 撤销订单
    /// </summary>
    public class WeChatPayReverseRequest 
    {
        /// <summary>
        /// 应用ID
        /// </summary>
        public string AppId { get; set; }

        /// <summary>
        /// 子商户公众账号ID
        /// </summary>
        public string SubAppId { get; set; }

        /// <summary>
        /// 子商户号
        /// </summary>
        public string SubMchId { get; set; }

        /// <summary>
        /// 微信订单号
        /// </summary>
        public string TransactionId { get; set; }

        /// <summary>
        /// 商户订单号
        /// </summary>
        public string OutTradeNo { get; set; }

        #region IWeChatPayCertificateRequest Members

        public string GetRequestUrl()
        {
            return "https://api.mch.weixin.qq.com/secapi/pay/reverse";
        }


        #endregion
    }
}
