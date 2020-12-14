using System;
using System.Collections.Generic;
using System.Text;
using Ezreal.EasyPay.Abstractions.ApiParameterModels.Response;

namespace Ezreal.EasyPay.MergeChannels.CCB.ApiParameterModels.Response
{
   public class CCBOrderQueryResponse:CCBPayCommonResponseModel,IResponseModel
    {

        /// <summary>
        /// 订单金额
        /// </summary>

        public string  AMOUNT { get; set; }
        /// <summary>
        /// 等待时间
        /// </summary>
        public string  WAITTIME { get; set; }

        
    }
}
