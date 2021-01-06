using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Ezreal.EasyPay.MergeChannels.CCB.ApiModels.Request
{
    [XmlRoot("TX")]
    public class CCBRefundRequest
    {
        /// <summary>
        /// 请求序列号,只可以使用数字
        /// </summary>
        public string REQUEST_SN { get; set; }
        /// <summary>
        /// 商户号
        /// </summary>

        public string CUST_ID { get; set; }
        /// <summary>
        /// 操作员号
        /// </summary>

        public string USER_ID { get; set; }
        /// <summary>
        /// 操作员密码
        /// </summary>

        public string PASSWORD { get; set; }
        /// <summary>
        /// 交易码
        /// </summary>

        public string TX_CODE { get; set; } = "5W1004";
        /// <summary>
        /// 语言
        /// </summary>

        public string LANGUAGE { get; set; } = "CN";

        public Content TX_INFO { get; set; }
        public class Content
        {
            /// <summary>
            /// 退款金额
            /// </summary>
            public decimal MONEY { get; set; }
            /// <summary>
            /// 订单号
            /// </summary>
            public string ORDER { get; set; }
            /// <summary>
            /// 退款流水号 文档标记可空 可不填，商户可根据需要填写，退款流水号由商户的系统生成。
            /// </summary>
            public string REFUND_CODE { get; set; }
        }
        /// <summary>
        /// 签名信息 文档标记可空
        /// </summary>
        public string SIGN_INFO { get; set; }
        /// <summary>
        /// 签名CA信息 文档标记可空 客户采用socket连接时，建行客户端自动添加
        /// </summary>
        public string SIGNCERT { get; set; }
    }
}
