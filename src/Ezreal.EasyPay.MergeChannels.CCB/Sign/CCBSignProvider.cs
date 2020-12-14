using System;
using System.Collections.Generic;
using System.Text;
using Ezreal.EasyPay.Abstractions.Sign;
using WebApiClient.DataAnnotations;

namespace Ezreal.EasyPay.MergeChannels.CCB.Sign
{
    public class CCBSignProvider : ISignProvider
    {
        public CCBSignProvider(CCBSignSettings signSettings)
        {
            SignSettings = signSettings;
        }

        public CCBSignSettings SignSettings { get; }
        public  string SignString { get; private set; }

        public string SignWithLast30BitsOfPublicKey(SortedDictionary<string, string> dictionary)
        {
            StringBuilder stringBuilder = null;
            foreach (KeyValuePair<string, string> item in dictionary)
            {
                if (stringBuilder == null)
                {
                    stringBuilder = new StringBuilder();
                }
                else
                {
                    stringBuilder.Append("&");
                }
                stringBuilder.Append(item.Key + "=" + item.Value);
            }
            stringBuilder?.Append("&PUB=" + SignSettings.Last30OfPublicKey);
            SignString= stringBuilder?.ToString();
            return Common.Security.MD5Hash.HashToHex(SignString).ToLower();
        }
    }
}
