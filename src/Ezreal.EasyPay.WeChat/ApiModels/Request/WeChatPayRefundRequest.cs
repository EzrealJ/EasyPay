using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Ezreal.EasyPay.WeChat.ApiModels.Response;

namespace Ezreal.EasyPay.WeChat.ApiModels.Request
{
    /// <summary>
    /// 微信支付申请退款请求模型
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
        /// 以元计的总金额
        /// <para>
        /// 对其设置会更改<see cref="TotalFee"/>,同理<see cref="TotalFee"/>值的更改也会影响本属性的值
        /// </para>
        /// </summary>
        [XmlIgnore]
        public decimal TotalFeeDecimal { get => Convert.ToDecimal(TotalFee) / 100; set => TotalFee = (int)(100 * value); }

        /// <summary>
        /// 申请退款金额
        /// </summary>
        [XmlElement("refund_fee")]
        public int RefundFee { get; set; }

        /// <summary>
        /// 以元计的退款金额
        /// <para>
        /// 对其设置会更改<see cref="RefundFee"/>,同理<see cref="RefundFee"/>值的更改也会影响本属性的值
        /// </para>
        /// </summary>
        [XmlIgnore]
        public decimal RefundFeeDecimal { get => Convert.ToDecimal(RefundFee) / 100; set => RefundFee = (int)(100 * value); }
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

    }
}
