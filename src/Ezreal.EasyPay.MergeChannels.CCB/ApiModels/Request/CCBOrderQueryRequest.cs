using System;
using System.Collections.Generic;
using System.Text;
using Ezreal.EasyPay.Abstractions.ApiModels.Request;
using Ezreal.EasyPay.MergeChannels.CCB.Enums;

namespace Ezreal.EasyPay.MergeChannels.CCB.ApiModels.Request
{
    public class CCBOrderQueryRequest : CCBPayCommonRequestModel, ICCBPayRequest
    {




        /// <summary>
        /// 查询次数
        /// </summary>
        public string QRYTIME { get; set; }
        /// <summary>
        /// 二维码类型
        /// </summary>
        public EnumCodeType QRCODETYPE { get; set; }

        public string TXCODE => "PAY101";
    }
}
