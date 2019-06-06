using Ezreal.EasyPay.Abstractions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Ezreal.EasyPay.WeChat.ApiParameterModels.Request
{
    public class WeChatPayFacePayRequest : WeChatPayRequestBase
    {

        /// <summary>
        /// 终端设备号
        /// <para>
        /// 终端设备号(商户自定义，如门店编号)
        /// </para>
        /// </summary>
        [XmlElement("device_info")]
        public string DeviceInfo { get; set; }
        /// <summary>
        /// 商品描述
        /// <para>
        /// 商品或支付单简要描述，格式要求：门店品牌名-城市分店名-实际商品名称
        /// </para>
        /// </summary>
        [XmlElement("body"), MustProvide]
        public string Body { get; set; }
        /// <summary>
        /// 商品详情
        /// <para>请按照微信要求提供参数，EasyPay不做深入实现</para>
        /// </summary>
        [XmlElement("detail")]
        public string Detail { get; set; }
        /// <summary>
        /// 附加数据
        /// <para>
        /// 附加数据，在查询 API 和支付通知中原样返回，该字段主要用于商户携带订单的自定义数据</para>
        /// </summary>
        [XmlElement("attach")]
        public string Attach { get; set; }
        /// <summary>
        /// 商户订单号
        /// <para>
        /// 商户系统内部的订单号,32 个字符内、可包含字母；更换授权码必须要换新的商户订单号 其他说明见商户订单号
        /// </para>
        /// </summary>
        [XmlElement("out_trade_no"), MustProvide]
        public string OutTradeNo { get; set; }
        /// <summary>
        /// 总金额
        /// <para>
        /// 订单总金额，单位为分，只能为整数，详见支付金额
        /// </para>
        /// </summary>
        [XmlElement("total_fee"), MustProvide]
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
        /// 货币类型
        /// <para>ISO 4217 标准的三位字母,默认CNY</para>
        /// </summary>
        [XmlElement("fee_type")]
        public string FeeType { get; set; }
        /// <summary>
        /// 终端 IP 
        /// </summary>
        [XmlElement("spbill_create_ip"),MustProvide]
        public string SpbillCreateIP { get; set; }
        /// <summary>
        /// 商品标记
        /// </summary>
        [XmlElement("goods_tag")]
        public string GoodsTag { get; set; }
        /// <summary>
        /// 用户标识
        /// </summary>
        [XmlElement("openid"),MustProvide]
        public string OpenId { get; set; }
        /// <summary>
        /// 人脸凭证
        /// </summary>
        [XmlElement("face_code"),MustProvide]
        public string FaceCode { get; set; }
    }
}
