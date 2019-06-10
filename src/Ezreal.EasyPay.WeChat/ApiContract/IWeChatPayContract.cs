using Ezreal.EasyPay.WeChat.ApiParameterModels.Request;
using Ezreal.EasyPay.WeChat.ApiParameterModels.Response;
using Ezreal.EasyPay.WeChat.Sign;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WebApiClient;
using WebApiClient.Attributes;
using WebApiClient.DataAnnotations;

namespace Ezreal.EasyPay.WeChat.ApiContract
{
    [HttpHost("https://api.mch.weixin.qq.com/")]
    [TraceFilter(OutputTarget = OutputTarget.Console)]
    public interface IWeChatPayContract : IHttpApi
    {
        ITask<string> FacePay(
            [XmlContent]WeChatPayFacePayRequest facePayRequest,
            [Timeout]TimeSpan? timeout = null,
            CancellationToken cancellationToken = default(CancellationToken));
        [HttpPost("pay/micropay")]
        [XmlReturn]
        ITask<WeChatPayMicroPayResponse> MicroPay(
            WeChatSignSettings weChatSignSettings,
            [XmlContent]WeChatPayMicroPayRequest microPayRequest,
            [Timeout]TimeSpan? timeout = null,
            CancellationToken cancellationToken = default(CancellationToken));
    }
}
