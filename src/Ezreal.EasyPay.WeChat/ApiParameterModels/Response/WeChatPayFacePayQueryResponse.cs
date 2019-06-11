using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Ezreal.EasyPay.WeChat.ApiParameterModels.Response
{
    /// <summary>
    /// 微信查询人脸支付的响应参数模型
    /// </summary>
    public class WeChatPayFacePayQueryResponse : WeChatPayServiceProviderCompatibleGenericBusinessResponse
    {
        /// <summary>
        /// 设备号
        /// </summary>
        [XmlElement("device_info")]
        public string DeviceInfo { get; set; }


        /// <summary>
        /// 用户标识	
        /// </summary>
        [XmlElement("openid")]
        public string OpenId { get; set; }

        /// <summary>
        /// 是否关注公众账号	
        /// </summary>
        [XmlElement("is_subscribe")]
        public string IsSubscribe { get; set; }

        /// <summary>
        /// 用户子标识	
        /// </summary>
        [XmlElement("sub_openid")]
        public string SubOpenId { get; set; }

        /// <summary>
        /// 是否关注子公众账号	
        /// </summary>
        [XmlElement("sub_is_subscribe")]
        public string SubIsSubscribe { get; set; }

        /// <summary>
        /// 交易类型
        /// </summary>
        [XmlElement("trade_type")]
        public string TradeType { get; set; }

        /// <summary>
        /// 交易状态
        /// </summary>
        [XmlElement("trade_state")]
        public string TradeState { get; set; }

        /// <summary>
        /// 付款银行	
        /// </summary>
        [XmlElement("bank_type")]
        public string BankType { get; set; }

        /// <summary>
        /// 标价币种	
        /// </summary>
        [XmlElement("fee_type")]
        public string FeeType { get; set; }

        /// <summary>
        /// 标价金额		
        /// </summary>
        [XmlElement("total_fee")]
        public string TotalFee { get; set; }

        /// <summary>
        /// 现金支付币种	
        /// </summary>
        [XmlElement("cash_fee_type")]
        public string CashFeeType { get; set; }

        /// <summary>
        /// 现金支付金额	
        /// </summary>
        [XmlElement("cash_fee")]
        public string CashFee { get; set; }


        /// <summary>
        /// 微信支付订单号	
        /// </summary>
        [XmlElement("transaction_id")]
        public string TransactionId { get; set; }

        /// <summary>
        /// 商户订单号	
        /// </summary>
        [XmlElement("out_trade_no")]
        public string OutTradeNo { get; set; }


        /// <summary>
        /// 商品详情
        /// <para>请按照微信要求提供参数，EasyPay不做深入实现</para>
        /// </summary>
        [XmlElement("detail")]
        public string Detail { get; set; }

        /// <summary>
        /// 商家数据包	
        /// </summary>
        [XmlElement("attach")]
        public string Attach { get; set; }


        /// <summary>
        /// 营销详情
        /// <para>
        /// 营销详情，请参考文档<![CDATA[https://pay.weixin.qq.com/wiki/doc/api/danpin.php?chapter=9_101&index=1]]>
        /// EasyPay不做深入实现
        /// </para>
        /// </summary>
        [XmlElement("promotion_detail")]
        public string PromotionDetail { get; set; }

        /// <summary>
        /// 支付完成时间	
        /// </summary>
        [XmlElement("time_end")]
        public string TimeEnd { get; set; }



















    }
}
