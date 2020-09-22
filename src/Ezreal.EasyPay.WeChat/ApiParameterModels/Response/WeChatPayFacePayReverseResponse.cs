using System.Xml.Serialization;
using Ezreal.EasyPay.Abstractions.ApiParameterModels;

namespace Ezreal.EasyPay.WeChat.ApiParameterModels.Response
{
    /// <summary>
    /// 微信支付人脸支付撤销订单响应模型
    /// </summary>
    [XmlRoot("xml")]
    public class WeChatPayFacePayReverseResponse : WeChatPayServiceProviderCompatibleGenericBusinessResponse, ISupportCompleted
    {
        /// <summary>
        /// 是否重调	
        /// </summary>
        [XmlElement("recall")]
        public string Recall { get; set; }
    }
}
