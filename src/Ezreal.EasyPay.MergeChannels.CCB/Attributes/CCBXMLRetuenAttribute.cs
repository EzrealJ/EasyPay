using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using WebApiClient.Attributes;
using WebApiClient.Contexts;

namespace Ezreal.EasyPay.MergeChannels.CCB.Attributes
{
    public class CCBXMLRetuenAttribute : XmlReturnAttribute
    {
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
            byte[] temp = await response.Content.ReadAsByteArrayAsync().ConfigureAwait(false);           
            string resultString =Encoding.GetEncoding("GB2312").GetString(temp) ;
            resultString = resultString?.TrimStart()?.TrimEnd();
            Type dataType = context.ApiActionDescriptor.Return.DataType.Type;
            object result = context.HttpApiConfig.XmlFormatter.Deserialize(resultString, dataType);
            return result;
        }
    }
}
