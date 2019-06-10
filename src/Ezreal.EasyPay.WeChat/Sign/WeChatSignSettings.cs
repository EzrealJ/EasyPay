using Ezreal.EasyPay.Abstractions.Sign;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiClient.DataAnnotations;

namespace Ezreal.EasyPay.WeChat.Sign
{
    public class WeChatSignSettings : ISignSettings
    {
        [IgnoreSerialized]
        public string Key { get; set; }

        [IgnoreSerialized]
        public string Secret { get; set; }

        [IgnoreSerialized]
        public SignType SignType { get; set; }
    }
}
