using System;
using System.Collections.Generic;
using System.Text;

namespace Ezreal.EasyPay.MergeChannels.CCB.ApiParameterModels.Response
{
    /// <summary>
    /// 请求"换取到的可在微信/支付宝内重定向拉起支付的Url"接口的结果
    /// </summary>
    public class CCBGetMergeChannelRedirectResponse
    {
        public bool SUCCESS { get; set; }
        /// <summary>
        /// 用escape解码就是一个浏览器地址，在微信里会拉起微信支付，支付宝里拉起支付宝
        /// </summary>
        public string QRURL { get; set; }
    }
}
