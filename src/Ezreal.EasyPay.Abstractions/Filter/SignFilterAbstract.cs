using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiClient;
using WebApiClient.Contexts;

namespace Ezreal.EasyPay.Abstractions.Filter
{
    public abstract class SignFilterAbstract : IApiActionFilter
    {
        public async Task OnBeginRequestAsync(ApiActionContext context)
        {

            await this.SignRequestAsync(context);

        }

        public abstract Task SignRequestAsync(ApiActionContext context);

        public Task OnEndRequestAsync(ApiActionContext context)
        {
#if NET45
            return Task.FromResult<object>(null);
#else
            return Task.CompletedTask;
#endif
        }
    }
}
