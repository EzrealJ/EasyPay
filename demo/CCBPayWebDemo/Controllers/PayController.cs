using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CCBPayWebDemo.Filters;
using Ezreal.EasyPay.MergeChannels.CCB;
using Ezreal.EasyPay.MergeChannels.CCB.ApiModels.Request;
using Ezreal.EasyPay.MergeChannels.CCB.ApiModels.Response;
using Ezreal.EasyPay.MergeChannels.CCB.Enums;
using Ezreal.EasyPay.MergeChannels.CCB.HttpInterface;
using Ezreal.EasyPay.MergeChannels.CCB.Sign;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CCBPayWebDemo.Controllers
{
    public class PayController : Controller
    {
        [HttpGet]
        public IActionResult PrePayView()
        {
            return View();
        }
        public class PrePayRequest
        {
            public decimal Amount { get; set; }
        }
        [HttpPost]
        [CCBPayOptionsAsyncSetter]
        public async Task<JsonResult> PrePayAsync([FromServices] ICCBPayContract cCBPayContract, [FromServices] CCBPayOptions options, [FromBody] PrePayRequest request)
        {
            CCBPrePayRequest prePayRequest = new CCBPrePayRequest()
            {
                MERCHANTID = options.MerchantId,
                POSID = options.PosId,
                BRANCHID = options.BranchId,
                PAYMENT = request.Amount,
                ORDERID = DateTime.Now.ToString("yyyyMMddHHmmssf"),
                RETURNTYPE = EnumReturnType.Json
            };
            CCBPrePayResponse result = await cCBPayContract.PrePay(new CCBSignSettings() { Last30OfPublicKey = options.Last30OfPublicKey }, prePayRequest);
            string qrUrlPrefix = "https://ibsbjstar.ccb.com.cn/CCBIS/QR?QRCODE=CCB";
            switch (prePayRequest.RETURNTYPE)
            {
                case EnumReturnType.Default:
                    //直接输出页面
                    break;
                case EnumReturnType.Json:
                    //在这里拿到QR内容，在前端会因为跨域禁止
                    if (result.SUCCESS && !string.IsNullOrWhiteSpace(result.PAYURL))
                    {
                        CCBGetMergeChannelRedirectResponse getMergeChannelRedirectResponse = await cCBPayContract.GetMergeChannelRedirectUrl(result.PAYURL);
                        getMergeChannelRedirectResponse.QRURL = qrUrlPrefix + getMergeChannelRedirectResponse.QRURL;
                        return Json(new { Type = "MakeQR", Content = getMergeChannelRedirectResponse });
                    }
                    break;
                case EnumReturnType.QRCodeOfMergeChannelHtml:
                    //直接输出页面
                    break;
                case EnumReturnType.JsonWithQRCodeOfMergeChannelUrl:
                    if (result.SUCCESS && !string.IsNullOrWhiteSpace(result.PAYURL))
                    {
                        CCBGetMergeChannelRedirectResponse getMergeChannelRedirectResponse = await cCBPayContract.GetMergeChannelRedirectUrl(result.PAYURL);
                        getMergeChannelRedirectResponse.QRURL = Uri.UnescapeDataString(getMergeChannelRedirectResponse.QRURL);
                        return Json(new { Type = "Redirect", Content = getMergeChannelRedirectResponse });
                    }
                    break;
                default:
                    break;
            }

            return Json(new { Type = "ReWritDOM", Content = result.Raw });
        }

        [HttpPost]
        [CCBPayOptionsAsyncSetter]
        public async Task<JsonResult> RefundAsync([FromServices] ICCBEBS5Contract cCBEBS5Contract,string ebsHttpEndpoint, [FromServices] CCBPayOptions options, [FromBody] CCBRefundRequest request)
        {
            CCBRefundRequest refundRequest = new CCBRefundRequest()
            {
                CUST_ID = options.MerchantId,
                USER_ID = "",
                PASSWORD = "",
                REQUEST_SN = DateTime.Now.ToString("yyMMddHHmmssffff"),
                TX_INFO = new CCBRefundRequest.Content
                {
                    ORDER = request.TX_INFO.ORDER,
                    MONEY = request.TX_INFO.MONEY,
                }
            };
            CCBRefundResponse result = await cCBEBS5Contract.Refund(ebsHttpEndpoint, new CCBEBS5HttpRequest<CCBRefundRequest>(refundRequest));
            return Json(result);
        }
    }
}
