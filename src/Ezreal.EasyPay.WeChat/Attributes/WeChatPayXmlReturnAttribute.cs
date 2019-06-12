using Ezreal.EasyPay.WeChat.ApiParameterModels.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using WebApiClient.Attributes;
using WebApiClient.Contexts;

namespace Ezreal.EasyPay.WeChat.Attributes
{
    public class WeChatPayXmlReturnAttribute : XmlReturnAttribute
    {
        protected override async Task<object> GetTaskResult(ApiActionContext context)
        {
            var response = context.ResponseMessage;
            var xml = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            var dataType = context.ApiActionDescriptor.Return.DataType.Type;
            var result = context.HttpApiConfig.XmlFormatter.Deserialize(xml, dataType);

            IEnumerable<XElement> elements = XDocument.Parse(xml)?.Root?.Elements();
            if (elements != null && elements.Any())
            {
                if (result is IWeChatPayXmlReturnListPropertParser weChatPayXmlReturnListPropertParser)
                {
                    weChatPayXmlReturnListPropertParser.ParseListPropert(elements);
                }
            }
            return result;
        }
    }
}
