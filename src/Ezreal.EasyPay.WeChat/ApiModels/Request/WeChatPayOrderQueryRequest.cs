using System.Collections.Generic;
using System.Xml.Serialization;
using Ezreal.EasyPay.Abstractions.Attributes;
using Ezreal.EasyPay.WeChat.ApiModels.Response;

namespace Ezreal.EasyPay.WeChat.ApiModels.Request
{
    /// <summary>
    /// 微信支付订单查询请求模型
    /// </summary>
    [XmlRoot("xml")]
    public class WeChatPayOrderQueryRequest : WeChatPayServiceProviderCompatibleRequest
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



    }
}
