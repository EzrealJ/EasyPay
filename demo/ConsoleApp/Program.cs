using System;
using System.Collections.Generic;
using System.Text;
using Ezreal.EasyPay.Common.Security;
using Ezreal.EasyPay.MergeChannels.CCB;
using Ezreal.EasyPay.MergeChannels.CCB.Api;
using Ezreal.EasyPay.MergeChannels.CCB.ApiContract;
using Ezreal.EasyPay.MergeChannels.CCB.ApiParameterModels.Request;
using Ezreal.EasyPay.MergeChannels.CCB.ApiParameterModels.Response;
using Ezreal.EasyPay.MergeChannels.CCB.Enums;
using WebApiClient;

namespace ConsoleApp
{
    class Program
    {
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            HttpApi.Register<ICCBPayContract>();
            CCBPayClient ccbPayClient = new CCBPayClient();
            ccbPayClient.GetDefaultCCBOptions = () =>
            {
                CCBPayOptions options = new CCBPayOptions();
                options.MerchantId = "105584073990033";
                options.PosId = "100000415";
                options.BranchId = "442000000";
                options.Last30BitsOfPublicKey = "bd0f9a0658b5640c37378787020111";
                return options;
            };
            CCBPrePayRequest prePayRequest = new CCBPrePayRequest()
            {
                Amount = 0.01m,
                OrderIdSuffix = DateTime.Now.ToString("yyyyMMddHHmmssf"),
                ReturnType = EnumReturnType.Json
            };
            CCBPrePayResponse result = await ccbPayClient.PrePay(prePayRequest);
            Console.ReadKey();
        }
    }
}
