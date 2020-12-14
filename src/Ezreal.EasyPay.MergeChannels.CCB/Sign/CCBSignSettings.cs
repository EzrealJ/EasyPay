using System;
using System.Collections.Generic;
using System.Text;
using WebApiClient.DataAnnotations;

namespace Ezreal.EasyPay.MergeChannels.CCB.Sign
{
    public class CCBSignSettings
    {
        /// <summary>
        /// 柜台的公钥后30位,用于二维码接口(预支付创建订单)的签名
        /// </summary>
        [IgnoreSerialized]
        public string Last30OfPublicKey { get; set; }
    }
}
