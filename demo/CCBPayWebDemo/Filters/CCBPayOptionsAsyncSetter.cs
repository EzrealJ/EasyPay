using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ezreal.EasyPay.MergeChannels.CCB;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;

namespace CCBPayWebDemo.Filters
{
    public class CCBPayOptionsAsyncSetter : ActionFilterAttribute
    {
        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            await Task.CompletedTask;
            //如果需要异步从其它位置获取 建议放在异步拦截器里
            CCBPayOptions options =context.HttpContext.RequestServices.GetRequiredService<CCBPayOptions>();

            options.MerchantId = "";
            options.PosId = "";
            options.BranchId = "";
            options.PublicKey = "";

            await next();
        }
    }
}
