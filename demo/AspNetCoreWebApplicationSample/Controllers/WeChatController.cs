using System;
using System.Linq;
using System.Threading.Tasks;
using Ezreal.EasyPay.WeChat.ApiContract;
using Ezreal.EasyPay.WeChat.ApiModels.Request;
using Ezreal.EasyPay.WeChat.ApiModels.Response;
using Ezreal.EasyPay.WeChat.Sign;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreWebApplicationSample.Controllers
{
    [Route("[controller]")]
    public class WeChatController : Controller
    {
        private readonly IWeChatPayContract _weChatPayClient;

        public WeChatController(IWeChatPayContract weChatPayClient)
        {
            this._weChatPayClient = weChatPayClient;
        }

        [HttpPost(nameof(FacePayAuth))]
        public async Task<WeChatPayFacePayAuthResponse> FacePayAuth([FromServices] IWeChatPayAuthContract weChatPayAuthContract, [FromQuery] WeChatSignSettings weChatSignSettings, [FromBody] WeChatPayFacePayAuthRequest microPayRequest)
        {
            try
            {

                WeChatPayFacePayAuthResponse result = await weChatPayAuthContract.FacePayAuth(weChatSignSettings, microPayRequest);

                return result;
            }
            catch (Exception ex)
            {

                throw;
            }
        }


        /// <summary>
        /// 刷卡支付
        /// </summary>
        /// <param name="weChatSignSettings"></param>
        /// <param name="microPayRequest"></param>
        /// <returns></returns>
        [HttpPost(nameof(MicroPay))]
        public async Task<WeChatPayMicroPayResponse> MicroPay([FromQuery] WeChatSignSettings weChatSignSettings, [FromBody] WeChatPayMicroPayRequest microPayRequest)
        {
            try
            {

                WeChatPayMicroPayResponse result = await _weChatPayClient.MicroPay(weChatSignSettings,microPayRequest);
                WeChatPayReverseResponse a = await _weChatPayClient.Reverse(weChatSignSettings,new WeChatPayReverseRequest()
                {
                    OutTradeNo = result.OutTradeNo,
                    SubMchId = result.SubMchId,
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
        public async Task<WeChatPayRefundResponse> Refund([FromQuery] WeChatSignSettings weChatSignSettings, [FromBody] WeChatPayRefundRequest refundRequest)
        {
            try
            {

                WeChatPayRefundResponse result = await _weChatPayClient.Refund( weChatSignSettings, refundRequest);
                return result;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
