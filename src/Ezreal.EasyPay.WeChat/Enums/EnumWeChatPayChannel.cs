using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ezreal.EasyPay.WeChat.Enums
{
    [Flags]
    public enum EnumWeChatPayChannel
    {
        /// <summary>
        /// 用户付款码(条码/二维码)
        /// </summary>
        AuthCode = 0b1,
        /// <summary>
        /// 通过调用微信App的内置的JSAPI发起支付
        /// </summary>
        JSAPI = 0b11,
        /// <summary>
        /// 用户打开扫一扫,扫商户的二维码完成支付
        /// </summary>
        Native = 0b111,
        /// <summary>
        /// 商户APP中集成微信支付SDK，用户点击后拉起微信支付
        /// </summary>
        APP = 0b1111,
        /// <summary>
        /// 用户在微信意外的收集浏览器请求微信支付的场景唤醒微信支付 
        /// </summary>
        H5 = 0b11111,
        /// <summary>
        /// 在微信小程序内使用微信支付
        /// </summary>
        Applet = 0b111111,
        /// <summary>
        /// 无需收集，用户凭人脸完成支付
        /// </summary>
        Face = 0b1111111,
    }
}
