using System.Collections.Generic;
using Ezreal.EasyPay.WeChat.ApiParameterModels.Response;

namespace Ezreal.EasyPay.WeChat.ApiParameterModels.Request
{
    /// <summary>
    /// 撤销订单
    /// </summary>
    public class WeChatPayReverseRequest : WeChatPayServiceProviderCompatibleRequest, ISupportCompleted
    {

        /// <summary>
        /// 微信订单号
        /// </summary>
        public string TransactionId { get; set; }

        /// <summary>
        /// 商户订单号
        /// </summary>
        public string OutTradeNo { get; set; }

    }
}
