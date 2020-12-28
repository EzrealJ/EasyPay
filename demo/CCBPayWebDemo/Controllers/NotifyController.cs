using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Ezreal.EasyPay.MergeChannels.CCB.ApiParameterModels.Notify;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CCBPayWebDemo.Controllers
{
    public class NotifyController : Controller
    {
        [HttpGet("~/NotifyUrl/CBBPayNotifyUrl/{companyCode}")]
        public async Task CCBNotifyGet(CCBPrePayNotify notify,[FromRoute]string companyCode)
        {
            Console.WriteLine(companyCode);
            Console.WriteLine("I m get");
            Console.WriteLine(JsonConvert.SerializeObject(notify));
            await Task.CompletedTask;
        }

        [HttpPost("~/NotifyUrl/CBBPayNotifyUrl/{companyCode}")]
        public async Task CCBNotify(CCBPrePayNotify notify, [FromRoute] string companyCode)
        {
            Console.WriteLine(companyCode);
            Console.WriteLine("I m post");
            Console.WriteLine(JsonConvert.SerializeObject(notify));
            await Task.CompletedTask;
        }
    }
}
