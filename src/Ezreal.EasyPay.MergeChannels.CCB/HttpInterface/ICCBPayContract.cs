using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using Ezreal.EasyPay.MergeChannels.CCB.ApiParameterModels.Request;
using Ezreal.EasyPay.MergeChannels.CCB.ApiParameterModels.Response;
using Ezreal.EasyPay.MergeChannels.CCB.Attributes;
using Ezreal.EasyPay.MergeChannels.CCB.Filters;
using Ezreal.EasyPay.MergeChannels.CCB.Sign;
using Newtonsoft.Json;
using WebApiClient;
using WebApiClient.Attributes;

namespace Ezreal.EasyPay.MergeChannels.CCB.HttpInterface
{
    [CCBSignFilter]
    [TraceFilter(OutputTarget = OutputTarget.Console)]
    [HttpHost("https://ibsbjstar.ccb.com.cn/CCBIS/ccbMain?CCB_IBSVersion=V6")]
    public interface ICCBPayContract : IHttpApi
    {
        [CCBReturn]
        ITask<CCBPrePayResponse> PrePay(CCBSignSettings signSettings, [PathQuery] CCBPrePayRequest prePayRequest,
        [Timeout] TimeSpan? timeout = null,
        CancellationToken cancellationToken = default);
    }
}
