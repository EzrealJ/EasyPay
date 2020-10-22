using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ezreal.EasyPay.Abstractions.ApiParameterModels;
using Ezreal.EasyPay.Abstractions.Attributes;
using Ezreal.EasyPay.Abstractions.Filter;
using Ezreal.EasyPay.MergeChannels.CCB.ApiParameterModels;
using Ezreal.EasyPay.MergeChannels.CCB.Sign;
using WebApiClient.Contexts;

namespace Ezreal.EasyPay.MergeChannels.CCB.Filters
{
    public class CCBSignFilterAttribute : SignFilterAbstractAttribute
    {
        public override async Task SignRequestAsync(ApiActionContext context)
        {
            await Task.CompletedTask;
            CCBSignSettings signSettings = context.ApiActionDescriptor.Arguments.FirstOrDefault(arg => arg is CCBSignSettings) as CCBSignSettings;
            IParameterNameComparer parameterNameComparer=context.ApiActionDescriptor.Arguments.FirstOrDefault(arg => arg is IParameterNameComparer) as IParameterNameComparer;
            string query = context.RequestMessage.RequestUri.Query;
            if (!string.IsNullOrWhiteSpace(query))
            {
                IEnumerable<KeyValuePair<string, string>> kvs = query
                    .Split('&')
                    .Select(s => new KeyValuePair<string, string>(s.Split('=')[0], s.Split('=')[1]));
                SortedDictionary<string,string> sortedDictionary=new SortedDictionary<string, string>(parameterNameComparer);
                foreach (KeyValuePair<string, string> item in kvs)
                {
                    SignOrderAttribute signOrderAttribute = parameterNameComparer?.GetSignOrderAttribute(item.Key);
                    if (signOrderAttribute != null)
                    {
                        sortedDictionary.Add(item.Key,item.Value);
                    }
                }

                CCBSignProvider ccbSignProvider = new CCBSignProvider(signSettings);
                string sign = ccbSignProvider.SignWithLast30BitsOfPublicKey(sortedDictionary);
                string signString = ccbSignProvider.SignString;
                Uri uri = new Uri(context.RequestMessage.RequestUri.AbsoluteUri + "&MAC=" + sign);
                context.RequestMessage.RequestUri = uri;
            }
        }
    }
}
