using Ezreal.EasyPay.Abstractions.Sign;
using Ezreal.EasyPay.Common.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ezreal.EasyPay.WeChat.Sign
{
    public class WeChatSignProvider: ISignProvider
    {
        public WeChatSignProvider(WeChatSignSettings signSettings)
        {
            SignSettings = signSettings ?? throw new ArgumentNullException(nameof(signSettings));
        }

        public WeChatSignSettings SignSettings { get; set; }
        public string SignWithKey(SortedDictionary<string, string> dictionary)
        {
            var sb = new StringBuilder();
            foreach (var iter in dictionary)
            {
                if (!string.IsNullOrEmpty(iter.Value) && iter.Key != "sign")
                {
                    sb.Append(iter.Key).Append('=').Append(iter.Value).Append("&");
                }
            }
            var signContent = sb.Append("key=").Append(SignSettings.Key).ToString();
            switch (SignSettings.SignType)
            {
                case SignType.MD5:
                    return MD5Hash.HashToHex(signContent).ToUpper();
                case SignType.HMACSHA256:
                    return HMACSHA256Hash.HashString(signContent, SignSettings.Key).ToUpper();
                default:
                    break;
            }
            return null;
        }

        public string SignWithSecret(SortedDictionary<string, string> dictionary,List<string> include)
        {
            var sb = new StringBuilder();
            foreach (var iter in dictionary)
            {
                if (!string.IsNullOrEmpty(iter.Value) && include.Contains(iter.Key))
                {
                    sb.Append(iter.Key).Append('=').Append(iter.Value).Append("&");
                }
            }
            var signContent = sb.Append("secret=").Append(SignSettings.Secret).ToString();
            return MD5Hash.HashToHex(signContent).ToUpper();
        }
    }
}
