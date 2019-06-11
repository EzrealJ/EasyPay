using Ezreal.EasyPay.WeChat.ApiContract;
using Ezreal.EasyPay.WeChat.ApiParameterModels.Request;
using Ezreal.EasyPay.WeChat.ApiParameterModels.Response;
using Ezreal.EasyPay.WeChat.Sign;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreWebApplicationSample.Controllers
{
    [Route("[controller]")]
    public class WeChatController : Controller
    {
        private readonly IWeChatPayContract _weChatPayContract;

        public WeChatController(IWeChatPayContract weChatPayContract)
        {
            this._weChatPayContract = weChatPayContract;
        }

        /// <summary>
        /// 刷卡支付
        /// </summary>
        /// <param name="weChatSignSettings"></param>
        /// <param name="weChatPayMicroPayRequest"></param>
        /// <returns></returns>
        [HttpPost(nameof(MicroPay))]
        public async Task<WeChatPayMicroPayResponse> MicroPay([FromQuery]WeChatSignSettings weChatSignSettings, [FromBody]WeChatPayMicroPayRequest weChatPayMicroPayRequest)
        {
            try
            {

                WeChatPayMicroPayResponse result = await _weChatPayContract.MicroPay(weChatSignSettings, weChatPayMicroPayRequest);
                return result;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
