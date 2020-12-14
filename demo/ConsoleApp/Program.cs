using System;
using Ezreal.EasyPay.MergeChannels.CCB;
using Ezreal.EasyPay.MergeChannels.CCB.ApiParameterModels.Request;
using Ezreal.EasyPay.MergeChannels.CCB.ApiParameterModels.Response;
using Ezreal.EasyPay.MergeChannels.CCB.Enums;
using Ezreal.EasyPay.MergeChannels.CCB.HttpInterface;
using Ezreal.EasyPay.MergeChannels.CCB.Sign;
using WebApiClient;

namespace ConsoleApp
{
    class Program
    {
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            HttpApi.Register<ICCBPayContract>();
            ICCBPayContract ccbPayClient = HttpApi.Resolve<ICCBPayContract>();

            CCBPayOptions options = new CCBPayOptions();


            CCBPrePayRequest prePayRequest = new CCBPrePayRequest()
            {
                MERCHANTID = options.MerchantId,
                POSID = options.PosId,
                BRANCHID = options.BranchId,
                PAYMENT = 0.01m,
                ORDERID = DateTime.Now.ToString("yyyyMMddHHmmssf"),
                RETURNTYPE = EnumReturnType.JsonWithQRCodeOfMergeChannelUrl
            };
            CCBPrePayResponse result = await ccbPayClient.PrePay(new CCBSignSettings() { Last30BitsOfPublicKey = options.Last30OfPublicKey }, prePayRequest);
            string payurl = result.PAYURL;
            Console.ReadKey();
        }
    }
}
