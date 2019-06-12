using System.Collections.Generic;
using System.Xml.Serialization;
using Ezreal.EasyPay.WeChat.ApiParameterModels.Response;

namespace Ezreal.EasyPay.WeChat.ApiParameterModels.Request
{
    /// <summary>
    /// 查询退款
    /// </summary>
    [XmlRoot("xml")]
    public class WeChatPayRefundQueryRequest :WeChatPayServiceProviderCompatibleRequest
    {

        /// <summary>
        /// 微信订单号
        /// </summary>
        [XmlElement("transaction_id")]
        public string TransactionId { get; set; }

        /// <summary>
        /// 商户订单号
        /// </summary>
        [XmlElement("out_trade_no")]
        public string OutTradeNo { get; set; }

        /// <summary>
        /// 商户退款单号
        /// </summary>
        [XmlElement("out_refund_no")]
        public string OutRefundNo { get; set; }

        /// <summary>
        /// 微信退款单号
        /// </summary>
        [XmlElement("refund_id")]
        public string RefundId { get; set; }

        /// <summary>
        /// 偏移量
        /// </summary>
        [XmlElement("offset")]
        public string Offset { get; set; }

        #region IWeChatPayRequest Members

        public string GetRequestUrl()
        {
            return "https://api.mch.weixin.qq.com/pay/refundquery";
        }



        #endregion
    }
}
