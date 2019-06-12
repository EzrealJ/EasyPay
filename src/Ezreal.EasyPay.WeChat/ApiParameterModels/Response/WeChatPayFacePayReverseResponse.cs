using System.Xml.Serialization;

namespace Ezreal.EasyPay.WeChat.ApiParameterModels.Response
{
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
