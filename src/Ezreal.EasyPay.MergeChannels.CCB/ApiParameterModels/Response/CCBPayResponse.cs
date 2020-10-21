using Ezreal.EasyPay.Abstractions.ApiParameterModels.Response;
using WebApiClient.DataAnnotations;

namespace Ezreal.EasyPay.MergeChannels.CCB.ApiParameterModels.Response
{
    public class CCBPayResponse:IResponseModel
    {
        [IgnoreSerialized]
        public string Raw { get; set; }
    }
}
