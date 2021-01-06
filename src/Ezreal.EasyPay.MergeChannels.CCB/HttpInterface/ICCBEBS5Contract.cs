using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Ezreal.EasyPay.MergeChannels.CCB.ApiModels.Request;
using Ezreal.EasyPay.MergeChannels.CCB.ApiModels.Response;
using WebApiClient;
using WebApiClient.Attributes;

namespace Ezreal.EasyPay.MergeChannels.CCB.HttpInterface
{
    [TraceFilter(OutputTarget = OutputTarget.Console)]

    public interface ICCBEBS5Contract : IHttpApi
    {
        [HttpPost]
        [XmlReturn(EnsureSuccessStatusCode = false)]
        ITask<CCBRefundResponse> Refund(
            [Uri] string ebsHttpEndpoint,
            [FormContent] CCBEBS5HttpRequest<CCBRefundRequest> request,
            [Timeout] TimeSpan? timeout = null,
            CancellationToken cancellationToken = default);
    }
}
