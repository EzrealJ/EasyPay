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


        [HttpPost("~/Notify/CCB")]
        public async Task CCBNotify(CCBPrePayNotify notify)
        {
            Console.WriteLine(JsonConvert.SerializeObject(notify));
            await Task.CompletedTask;
        }
    }
}
