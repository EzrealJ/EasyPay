using WebApiClient.DataAnnotations;

namespace Ezreal.EasyPay.MergeChannels.CCB.ApiParameterModels.Response
{
    public class CCBPrePayResponse:CCBPayResponse
    {
        [AliasAs("SUCCESS")]
        public bool IsSuccess { get; set; }

        [AliasAs("PAYURL")]
        public string PayUrl { get; set; }
    }
}
