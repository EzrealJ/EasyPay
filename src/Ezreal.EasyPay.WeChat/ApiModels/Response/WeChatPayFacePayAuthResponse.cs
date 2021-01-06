using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using Ezreal.EasyPay.Abstractions.ApiModels;

namespace Ezreal.EasyPay.WeChat.ApiModels.Response
{
    /// <summary>
    /// 微信支付获取人脸调用凭证响应模型
    /// </summary>
    [XmlRoot("xml")]
    public class WeChatPayFacePayAuthResponse : WeChatPayServiceProviderCompatibleGenericBusinessResponse, ISupportCompleted
    {
        /// <summary>
        /// SDK调用凭证。用于调用SDK的人脸识别接口。
        /// </summary>
        [XmlElement("authinfo")]
        public string AuthInfo { get; set; }
        /// <summary>
        /// authinfo的有效时间, 单位秒
        /// </summary>
        [XmlElement("expires_in")]
        public int ExpiresIn { get; set; }


        public override bool IsEffectiveResult =>
            (!string.IsNullOrWhiteSpace(this.ReturnCode))
            && this.ReturnCode.ToUpper() == "SUCCESS";
    }
}
