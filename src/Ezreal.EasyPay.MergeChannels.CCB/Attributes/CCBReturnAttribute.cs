using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Ezreal.EasyPay.MergeChannels.CCB.ApiModels.Response;
using WebApiClient.Attributes;
using WebApiClient.Contexts;

namespace Ezreal.EasyPay.MergeChannels.CCB.Attributes
{
    public class CCBReturnAttribute : ApiReturnAttribute
    {
        public static string JsonMediaType => "application/json";
        public static string HtmlMediaType => "text/html";

        /// <summary>
        /// 配置请求头的accept
        /// </summary>
        /// <param name="accept">请求头的accept</param>
        /// <returns></returns>
        protected override void ConfigureAccept(HttpHeaderValueCollection<MediaTypeWithQualityHeaderValue> accept)
        {
            accept.Add(new MediaTypeWithQualityHeaderValue(HtmlMediaType));
        }

        /// <summary>
        /// 获取异步结果
        /// </summary>
        /// <param name="context">上下文</param>
        /// <returns></returns>
        protected override async Task<object> GetTaskResult(ApiActionContext context)
        {
            HttpResponseMessage response = context.ResponseMessage;
            string resultString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            resultString = resultString?.TrimStart()?.TrimEnd();
            object result = null;
            Type dataType = context.ApiActionDescriptor.Return.DataType.Type;
            if (resultString.StartsWith("{"))
            {
                result = context.HttpApiConfig.JsonFormatter.Deserialize(resultString, dataType);
            }

            if (typeof(CCBPayResponse).IsAssignableFrom(dataType))
            {
                if (result == null)
                {
                    result = Activator.CreateInstance(dataType);
                }
                (result as CCBPayResponse).Raw = resultString;

            }

            return result;
        }
    }
}
