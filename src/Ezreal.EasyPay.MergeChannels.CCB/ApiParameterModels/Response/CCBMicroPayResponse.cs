using System;
using System.Collections.Generic;
using System.Text;
using Ezreal.EasyPay.Abstractions.ApiParameterModels.Response;
using Ezreal.EasyPay.MergeChannels.CCB.Enums;

namespace Ezreal.EasyPay.MergeChannels.CCB.ApiParameterModels.Response
{
  public  class CCBMicroPayResponse: CCBPayCommonResponseModel,IResponseModel
    {


        /// <summary>
        /// 订单金额
        /// </summary>
        public string AMOUNT { get; set; }
        /// <summary>
        /// 二维码类型
        /// </summary>
        public EnumCodeType QRCODETYPE { get; set; }
        /// <summary>
        /// 等待时间
        /// </summary>
        public string WAITTIME { get; set; }
        /// <summary>
        /// 全局事件跟踪号
        /// </summary>
        public string TRACEID { get; set; }


    }
}
