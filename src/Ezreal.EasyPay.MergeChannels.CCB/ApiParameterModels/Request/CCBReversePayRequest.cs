﻿using System;
using System.Collections.Generic;
using System.Text;
using Ezreal.EasyPay.Abstractions.ApiParameterModels.Request;
using Ezreal.EasyPay.MergeChannels.CCB.Enums;

namespace Ezreal.EasyPay.MergeChannels.CCB.ApiParameterModels.Request
{
    public class CCBReversePayRequest : CCBPayCommonRequestModel, ICCBPayRequest
    {
        public string TXCODE => "PAY102";
        /// <summary>
        /// 二维码类型
        /// </summary>
        public EnumCodeType QRCODETYPE { get; set; }
    }
}
