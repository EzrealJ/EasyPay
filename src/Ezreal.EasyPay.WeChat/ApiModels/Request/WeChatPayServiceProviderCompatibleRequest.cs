using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Ezreal.EasyPay.WeChat.ApiModels.Request
{
    /// <summary>
    /// 微信支付服务商兼容接口的请求模型
    /// </summary>
    public class WeChatPayServiceProviderCompatibleRequest : WeChatPayRequest, IWeChatPayServiceProviderRequest
    {
        /// <summary>
        /// 特约商户公众账号ID
        /// <para>
        /// 服务商模式专有参数，微信分配的特约商户公众账号ID
        /// </para>
        /// </summary>
        [XmlElement("sub_appid")]
        public string SubAppId { get; set; }

        /// <summary>
        /// 特约商户号
        /// <para>
        /// 服务商模式下必填,微信支付分配的特约商户号
        /// </para>
        /// </summary>
        [XmlElement("sub_mch_id")]
        public string SubMchId { get; set; }
    }
}
