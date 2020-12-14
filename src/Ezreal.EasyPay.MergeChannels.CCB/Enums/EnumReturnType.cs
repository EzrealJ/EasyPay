using System;
using System.Collections.Generic;
using System.Text;

namespace Ezreal.EasyPay.MergeChannels.CCB.Enums
{
    public enum EnumReturnType
    {
        /// <summary>
        ///  0或空：返回页面二维码
        ///  <para>返回的是html 不可通过success判断</para>
        /// </summary>
        Default = 0,
        /// <summary>
        ///  1：返回JSON格式【二维码信息串】
        /// </summary>
        Json = 1,
        /// <summary>
        ///  2：返回聚合扫码页面二维码
        /// <para>
        /// 返回一个显示二维码的网页内容，没有PayUrl，参考Raw
        /// </para>
        /// </summary>
        QRCodeOfMergeChannelHtml = 2,
        /// <summary>
        ///  3：返回聚合扫码JSON格式【二维码信息串】
        ///  <para>
        ///  返回一个Json{succes:bool,payUlr:二维码的网页url}
        /// </para>
        /// </summary>
        JsonWithQRCodeOfMergeChannelUrl = 3


    }
}
