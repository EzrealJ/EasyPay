using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Ezreal.EasyPay.MergeChannels.CCB.ApiModels.Response
{
    [XmlRoot("TX")]
    public class CCBRefundResponse
    {
        /// <summary>
        /// 同请求报文中的序列号
        /// </summary>
        public string REQUEST_SN { get; set; }
        /// <summary>
        /// 同请求报文中的商户号
        /// </summary>

        public string CUST_ID { get; set; }


        /// <summary>
        /// 交易码
        /// </summary>

        public string TX_CODE { get; set; }
        /// <summary>
        /// 语言
        /// </summary>

        public string LANGUAGE { get; set; } = "CN";
        /// <summary>
        /// 同请求报文中的交易码
        /// </summary>

        public string RETURN_CODE { get; set; }
        /// <summary>
        /// 交易响应信息
        /// </summary>

        public string RETURN_MSG { get; set; }

        public Content TX_INFO { get; set; }

        public class Content
        {

            /// <summary>
            /// 订单号
            /// </summary>

            public string ORDER_NUM { get; set; }
            /// <summary>
            /// 支付金额
            /// </summary>

            public decimal PAY_AMOUNT { get; set; }
            /// <summary>
            /// 退款金额
            /// </summary>


            public decimal AMOUNT { get; set; }

            public string REM1 { get; set; }

            public string REM2 { get; set; }
        }
    }
}
