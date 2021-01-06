using System;
using System.Collections.Generic;
using System.Text;
using Ezreal.EasyPay.Abstractions.ApiModels.Response;

namespace Ezreal.EasyPay.MergeChannels.CCB.ApiModels.Response
{
    public class CCBReversePayResponse:CCBPayCommonResponseModel,IResponseModel
    {
        /// <summary>
        /// 是否重调
        /// </summary>
        public string RECALL { get; set; }

    }
}
