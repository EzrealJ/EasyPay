using System;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using Ezreal.EasyPay.MergeChannels.CCB;
using Ezreal.EasyPay.MergeChannels.CCB.ApiModels.Request;
using Ezreal.EasyPay.MergeChannels.CCB.ApiModels.Response;
using Ezreal.EasyPay.MergeChannels.CCB.HttpInterface;
using WebApiClient;

namespace ConsoleApp
{
    class Program
    {
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            HttpApi.Register<ICCBEBS5Contract>();
            ICCBEBS5Contract ccbPayClient = HttpApi.Resolve<ICCBEBS5Contract>();

            CCBPayOptions options = new CCBPayOptions();


            while(true)
            {
                Func<string> y = () => { Console.WriteLine("请输入退款订单"); return Console.ReadLine(); };
                Func<decimal> x = () => { Console.WriteLine("请输入退款金额"); return decimal.Parse(Console.ReadLine()); };
               
                CCBRefundRequest refundRequest = new CCBRefundRequest()
                {
                    CUST_ID = options.MerchantId,
                    USER_ID = "",
                    PASSWORD = "",
                    REQUEST_SN = DateTime.Now.ToString("yyMMddHHmmssffff"),
                    TX_INFO = new CCBRefundRequest.Content
                    {
                        ORDER = y.Invoke(),
                        MONEY = x.Invoke(),                 
                    }
                };
                CCBRefundResponse result = await ccbPayClient.Refund(ebsHttpEndpoint: "http://192.168.0.205:30001", new CCBEBS5HttpRequest<CCBRefundRequest>(refundRequest));
                Console.ReadKey();
            }
          
        }
    }
}
