using Ezreal.EasyPay.WeChat.ApiParameterModels.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WebApiClient;
using WebApiClient.Attributes;

namespace Ezreal.EasyPay.WeChat.ApiContract
{
    public interface IWeChatPay : IHttpApi
    {
        ITask<string> FacePay(
            [XmlContent]WeChatPayFacePayRequest facePayRequest,
            [Timeout]TimeSpan? timeout = null,
            CancellationToken cancellationToken = default(CancellationToken));

    }
}
