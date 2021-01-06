using System.Xml.Serialization;
using Ezreal.EasyPay.Abstractions.ApiModels;

namespace Ezreal.EasyPay.WeChat.ApiModels.Response
{
    /// <summary>
    /// 微信支付撤销订单响应模型
    /// </summary>
    [XmlRoot("xml")]
    public class WeChatPayReverseResponse : WeChatPayServiceProviderCompatibleGenericBusinessResponse, ISupportCompleted
    {
        /// <summary>
        /// 是否重调	
        /// </summary>
        [XmlElement("recall")]
        public string Recall { get; set; }
    }
}
