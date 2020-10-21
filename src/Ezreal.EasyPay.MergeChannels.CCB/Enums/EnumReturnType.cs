using System;
using System.Collections.Generic;
using System.Text;

namespace Ezreal.EasyPay.MergeChannels.CCB.Enums
{
    public enum EnumReturnType
    {
        /// <summary>
        ///  0或空：返回页面二维码
        /// </summary>
        Default = 0,
        /// <summary>
        ///  1：返回JSON格式【二维码信息串】
        /// </summary>
        Json = 1,
        /// <summary>
        ///  2：返回聚合扫码页面二维码
        /// </summary>
        QRCodeOfMergeChannelHtml=2,
        /// <summary>
        ///  3：返回聚合扫码JSON格式【二维码信息串】
        /// </summary>
        JsonWithQRCodeOfMergeChannelUrl = 3
       
       
    }
}
