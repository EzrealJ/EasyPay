using Ezreal.EasyPay.Abstractions.Attributes;
using Ezreal.EasyPay.Common.XML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Ezreal.EasyPay.Abstractions.ApiModels;

namespace Ezreal.EasyPay.WeChat.ApiModels.Request
{
    /// <summary>
    /// 微信支付刷卡支付请求模型
    /// </summary>
    [XmlRoot("xml")]
    public class WeChatPayMicroPayRequest :WeChatPayServiceProviderCompatibleRequest, ISupportCompleted
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
        public string FeeType { get; set; } = "CNY";

        /// <summary>
        /// 终端IP
        /// <para>支持IPV4和IPV6两种格式的IP地址。调用微信支付API的机器IP</para>
        /// </summary>
        [XmlElement("spbill_create_ip"), MustProvide]
        public string SpbillCreateIP { get; set; }

        /// <summary>
        /// 订单优惠标记
        /// </summary>
        [XmlElement("goods_tag")]
        public string GoodsTag { get; set; }

        /// <summary>
        /// 指定支付方式
        /// <para>
        /// no_credit--指定不能使用信用卡支付
        /// </para>
        /// </summary>
        [XmlElement("limit_pay")]
        public string LimitPay { get; set; }

        /// <summary>
        /// 交易起始时间
        /// </summary>
        [XmlElement("time_start")]
        public string TimeStart { get; set; }

        /// <summary>
        /// 交易结束时间
        /// <para>
        /// 订单失效时间，格式为yyyyMMddHHmmss，如2009年12月27日9点10分10秒表示为20091227091010。注意：最短失效时间间隔需大于1分钟
        /// </para>
        /// </summary>
        [XmlElement("time_expire")]
        public string TimeExpire { get; set; }

        /// <summary>
        /// 授权码
        /// <para>
        /// 扫码支付授权码，设备读取用户微信中的条码或者二维码信息（注：用户付款码条形码规则：18位纯数字，以10、11、12、13、14、15开头）
        /// </para>
        /// </summary>
        [XmlElement("auth_code"), MustProvide]
        public string AuthCode { get; set; }
        /// <summary>
        /// 电子发票入口开放标识
        /// <para>
        /// Y，传入Y时，支付成功消息和支付详情页将出现开票入口。需要在微信支付商户平台或微信公众平台开通电子发票功能，传此字段才可生效
        /// </para>
        /// </summary>
        [XmlElement("receipt")]
        public string Receipt { get; set; }

        /// <summary>
        /// 场景信息
        /// </summary>
        [XmlElement("scene_info")]
        public string SceneInfo { get; set; }

    }
}
