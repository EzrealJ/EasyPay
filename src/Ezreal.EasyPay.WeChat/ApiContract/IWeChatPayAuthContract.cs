using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Ezreal.EasyPay.WeChat.ApiParameterModels.Request;
using Ezreal.EasyPay.WeChat.ApiParameterModels.Response;
using Ezreal.EasyPay.WeChat.Attributes;
using Ezreal.EasyPay.WeChat.Sign;
using WebApiClient;
using WebApiClient.Attributes;

namespace Ezreal.EasyPay.WeChat.ApiContract
{
    [HttpHost("https://payapp.weixin.qq.com/")]
    [Ezreal.EasyPay.WeChat.Filter.WeChatSignFilter]
    public interface IWeChatPayAuthContract : IHttpApi
    {
        [HttpPost("face/get_wxpayface_authinfo")]
        [WeChatPayXmlReturn]
        ITask<WeChatPayFacePayAuthResponse> FacePayAuth(
        WeChatSignSettings weChatSignSettings,
        [XmlContent]WeChatPayFacePayAuthRequest facePayAuthRequest,
        [Timeout]TimeSpan? timeout = null,
        CancellationToken cancellationToken = default(CancellationToken));
    }
}
