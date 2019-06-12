using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Ezreal.EasyPay.WeChat.ApiParameterModels.Response
{

    /// <summary>
    /// 微信支付服务商兼容接口的通用响应模型
    /// </summary>
    public abstract class WeChatPayServiceProviderCompatibleGenericBusinessResponse : WeChatPayGenericBusinessResponse
    {
        /// <summary>
        /// 子商户公众账号ID
        /// </summary>
        [XmlElement("sub_appid")]
        public string SubAppId { get; set; }

        /// <summary>
        /// 子商户号
        /// </summary>
        [XmlElement("sub_mch_id")]
        public string SubMchId { get; set; }
    }
}
