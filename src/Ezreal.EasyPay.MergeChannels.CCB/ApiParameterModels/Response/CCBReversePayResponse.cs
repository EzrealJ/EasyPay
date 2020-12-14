using System;
using System.Collections.Generic;
using System.Text;
using Ezreal.EasyPay.Abstractions.ApiParameterModels.Response;

namespace Ezreal.EasyPay.MergeChannels.CCB.ApiParameterModels.Response
{
    public class CCBReversePayResponse:CCBPayCommonResponseModel,IResponseModel
    {
        /// <summary>
        /// 是否重调
        /// </summary>
        public string RECALL { get; set; }

    }
}
