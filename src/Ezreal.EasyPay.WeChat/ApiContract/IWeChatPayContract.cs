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
        [HttpPost("pay/facepay")]
        [XmlReturn]
        ITask<WeChatPayFacePayResponse> FacePay(
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

        [HttpPost("pay/facepayquery")]
        [XmlReturn]
        ITask<WeChatPayFacePayQueryResponse> Facepayquery(
        WeChatSignSettings weChatSignSettings,
        [XmlContent]WeChatPayFacePayQueryRequest facePayQueryRequest,
        [Timeout]TimeSpan? timeout = null,
        CancellationToken cancellationToken = default(CancellationToken));

        [HttpPost("secapi/pay/refund")]
        [XmlReturn]
        ITask<WeChatPayRefundResponse> Facepayquery(
        WeChatSignSettings weChatSignSettings,
        [XmlContent]WeChatPayRefundRequest refundRequest,
        [Timeout]TimeSpan? timeout = null,
        CancellationToken cancellationToken = default(CancellationToken));

    }
}
