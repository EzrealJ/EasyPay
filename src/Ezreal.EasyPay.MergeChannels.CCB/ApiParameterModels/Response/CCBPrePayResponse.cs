﻿

namespace Ezreal.EasyPay.MergeChannels.CCB.ApiParameterModels.Response
{
    public class CCBPrePayResponse:CCBPayResponse
    {

        public bool SUCCESS { get; set; }


        public string PAYURL { get; set; }
    }
}
