using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ezreal.EasyPay.Abstractions.Filter;
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
            string query = context.RequestMessage.RequestUri.Query;
        }
    }
}
