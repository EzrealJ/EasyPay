using System.Collections.Generic;
using System.Xml.Serialization;
using Ezreal.EasyPay.WeChat.ApiParameterModels.Response;

namespace Ezreal.EasyPay.WeChat.ApiParameterModels.Request
{
    /// <summary>
    /// 申请退款
    /// </summary>
    [XmlRoot("xml")]
    public class WeChatPayRefundRequest:WeChatPayServiceProviderCompatibleRequest
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
        /// 订单金额
        /// </summary>
        [XmlElement("total_fee")]
        public int TotalFee { get; set; }

        /// <summary>
        /// 申请退款金额
        /// </summary>
        [XmlElement("refund_fee")]
        public int RefundFee { get; set; }

        /// <summary>
        /// 退款货币种类
        /// </summary>
        [XmlElement("refund_fee_type")]
        public string RefundFeeType { get; set; }

        /// <summary>
        /// 退款原因
        /// </summary>
        [XmlElement("refund_desc")]
        public string RefundDesc { get; set; }

        /// <summary>
        /// 退款资金来源
        /// </summary>
        [XmlElement("refund_account")]
        public string RefundAccount { get; set; }

        /// <summary>
        /// 退款结果通知url
        /// </summary>
        [XmlElement("notify_url")]
        public string NotifyUrl { get; set; }

        #region IWeChatPayCertificateRequest Members

        public string GetRequestUrl()
        {
            return "https://api.mch.weixin.qq.com/secapi/pay/refund";
        }


        #endregion
    }
}
