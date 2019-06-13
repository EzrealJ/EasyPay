using Ezreal.EasyPay.WeChat.Api;
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
        private readonly WeChatPayClient _weChatPayClient;

        public WeChatController(WeChatPayClient weChatPayClient)
        {
            this._weChatPayClient = weChatPayClient;
        }

        /// <summary>
        /// 刷卡支付
        /// </summary>
        /// <param name="weChatSignSettings"></param>
        /// <param name="microPayRequest"></param>
        /// <returns></returns>
        [HttpPost(nameof(MicroPay))]
        public async Task<WeChatPayMicroPayResponse> MicroPay([FromQuery]WeChatSignSettings weChatSignSettings, [FromBody]WeChatPayMicroPayRequest microPayRequest)
        {
            try
            {

                WeChatPayMicroPayResponse result = await _weChatPayClient.MicroPay(microPayRequest, weChatSignSettings);
                var a = await _weChatPayClient.Reverse(new WeChatPayReverseRequest() {
                    OutTradeNo=result.OutTradeNo,
                    SubMchId=result.SubMchId,
                });
                return result;
            }
            catch (Exception ex)
            {

                throw;
            }
        }


        /// <summary>
        /// 退款
        /// </summary>
        /// <param name="weChatSignSettings"></param>
        /// <param name="refundRequest"></param>
        /// <returns></returns>
        [HttpPost(nameof(Refund))]
        public async Task<WeChatPayRefundResponse> Refund([FromQuery]WeChatSignSettings weChatSignSettings, [FromBody]WeChatPayRefundRequest refundRequest)
        {
            try
            {

                WeChatPayRefundResponse result = await _weChatPayClient.Refund(refundRequest, weChatSignSettings);
                return result;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
