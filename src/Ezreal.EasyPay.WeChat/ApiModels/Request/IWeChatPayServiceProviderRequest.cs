using Ezreal.EasyPay.Abstractions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Ezreal.EasyPay.WeChat.ApiModels.Request
{
    /// <summary>
    /// 描述服务商代发起支付的请求
    /// <para>
    /// 实现此接口的所有类都应隐式实现本接口的所有成员并完整复制成员的特性
    /// </para>
    /// </summary>
   public interface IWeChatPayServiceProviderRequest
    {
        /// <summary>
        /// 特约商户公众账号ID
        /// <para>
        /// 服务商模式专有参数，微信分配的特约商户公众账号ID
        /// </para>
        /// </summary>
        [XmlElement("sub_appid")]
        string SubAppId { get; set; }

        /// <summary>
        /// 特约商户号
        /// <para>
        /// 服务商模式下必填,微信支付分配的特约商户号
        /// </para>
        /// </summary>
        [XmlElement("sub_mch_id"), MustProvide]
        string SubMchId { get; set; }
    }
}
