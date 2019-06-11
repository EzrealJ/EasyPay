using Ezreal.EasyPay.WeChat.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ezreal.EasyPay.WeChat.Attributes
{
    public class WeChatPayScenesAttribute : System.Attribute
    {
        public WeChatPayScenesAttribute(EnumWeChatPayChannel weChatPayChannel)
        {
            WeChatPayChannel = weChatPayChannel;
        }

        public EnumWeChatPayChannel WeChatPayChannel { get; }
    }
}
