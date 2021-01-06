using Ezreal.EasyPay.WeChat.ApiModels.Request;
using Ezreal.EasyPay.WeChat.ApiModels.Response;
using Ezreal.EasyPay.WeChat.Attributes;
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
    [Ezreal.EasyPay.WeChat.Filter.WeChatSignFilter]
    public interface IWeChatPayContract : IWeChatPayApiContract
    {
        [HttpPost("pay/micropay")]
        [WeChatPayXmlReturn]
        ITask<WeChatPayMicroPayResponse> MicroPay(
        WeChatSignSettings weChatSignSettings,
        [XmlContent]WeChatPayMicroPayRequest microPayRequest,
        [Timeout]TimeSpan? timeout = null,
        CancellationToken cancellationToken = default(CancellationToken));

        [HttpPost("pay/facepay")]
        [WeChatPayXmlReturn]
        ITask<WeChatPayFacePayResponse> FacePay(
             WeChatSignSettings weChatSignSettings,
            [XmlContent]WeChatPayFacePayRequest facePayRequest,
            [Timeout]TimeSpan? timeout = null,
            CancellationToken cancellationToken = default(CancellationToken));


        [HttpPost("pay/orderquery")]
        [WeChatPayXmlReturn]
        ITask<WeChatPayOrderQueryResponse> OrderQuery(
        WeChatSignSettings weChatSignSettings,
        [XmlContent]WeChatPayOrderQueryRequest facePayQueryRequest,
        [Timeout]TimeSpan? timeout = null,
        CancellationToken cancellationToken = default(CancellationToken));


        [HttpPost("pay/facepayquery")]
        [WeChatPayXmlReturn]
        ITask<WeChatPayFacePayQueryResponse> FacePayQuery(
        WeChatSignSettings weChatSignSettings,
        [XmlContent]WeChatPayFacePayQueryRequest facePayQueryRequest,
        [Timeout]TimeSpan? timeout = null,
        CancellationToken cancellationToken = default(CancellationToken));



        [HttpPost("secapi/pay/facepayreverse")]
        [WeChatPayXmlReturn]
        ITask<WeChatPayFacePayReverseResponse> FacePayReverse(
        WeChatSignSettings weChatSignSettings,
        [XmlContent]WeChatPayFacePayReverseRequest facePayReverseRequest,
        [Timeout]TimeSpan? timeout = null,
        CancellationToken cancellationToken = default(CancellationToken));


        [HttpPost("secapi/pay/reverse")]
        [WeChatPayXmlReturn]
        ITask<WeChatPayReverseResponse> Reverse(
        WeChatSignSettings weChatSignSettings,
        [XmlContent]WeChatPayReverseRequest facePayReverseRequest,
        [Timeout]TimeSpan? timeout = null,
        CancellationToken cancellationToken = default(CancellationToken));



        [HttpPost("secapi/pay/refund")]
        [WeChatPayXmlReturn]
        ITask<WeChatPayRefundResponse> Refund(
        WeChatSignSettings weChatSignSettings,
        [XmlContent]WeChatPayRefundRequest refundRequest,
        [Timeout]TimeSpan? timeout = null,
        CancellationToken cancellationToken = default(CancellationToken));


        [HttpPost("pay/refundquery")]
        [WeChatPayXmlReturn]
        ITask<WeChatPayRefundQueryResponse> RefundQuery(
        WeChatSignSettings weChatSignSettings,
        [XmlContent]WeChatPayRefundQueryRequest refundQueryRequest,
        [Timeout]TimeSpan? timeout = null,
        CancellationToken cancellationToken = default(CancellationToken));

    }
}
