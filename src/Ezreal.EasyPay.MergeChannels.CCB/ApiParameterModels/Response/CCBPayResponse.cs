using Ezreal.EasyPay.Abstractions.ApiParameterModels.Response;
using WebApiClient.DataAnnotations;

namespace Ezreal.EasyPay.MergeChannels.CCB.ApiParameterModels.Response
{
    public class CCBPayResponse:IResponseModel
    {
        /// <summary>
        /// 返回的原始报文
        /// </summary>
        [IgnoreSerialized]
        public string Raw { get; set; }
    }
}
