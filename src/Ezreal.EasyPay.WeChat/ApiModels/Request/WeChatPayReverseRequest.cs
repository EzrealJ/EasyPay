﻿using System.Collections.Generic;
using System.Xml.Serialization;
using Ezreal.EasyPay.Abstractions.ApiModels;
using Ezreal.EasyPay.WeChat.ApiModels.Response;

namespace Ezreal.EasyPay.WeChat.ApiModels.Request
{
    /// <summary>
    /// 微信支付撤销订单请求模型
    /// </summary>
    [XmlRoot("xml")]
    public class WeChatPayReverseRequest : WeChatPayServiceProviderCompatibleRequest, ISupportCompleted
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
