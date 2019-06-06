using Ezreal.EasyPay.Abstractions.Sign;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ezreal.EasyPay.WeChat.Sign
{
    public class WeChatSignSettings : ISignSettings
    {
        public string Key { get; set; }

        public string Secret { get; set; }

        public SignType SignType { get; set; }
    }
}
