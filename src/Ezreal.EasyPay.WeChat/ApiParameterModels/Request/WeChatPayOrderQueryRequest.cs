using System.Collections.Generic;
using System.Xml.Serialization;
using Ezreal.EasyPay.Abstractions.Attributes;
using Ezreal.EasyPay.WeChat.ApiParameterModels.Response;

namespace Ezreal.EasyPay.WeChat.ApiParameterModels.Request
{
    /// <summary>
    /// 查询订单
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
