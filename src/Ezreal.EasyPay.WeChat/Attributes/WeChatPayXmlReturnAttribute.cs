using Ezreal.EasyPay.Abstractions.Exceptions;
using Ezreal.EasyPay.WeChat.ApiModels.Response;
using Ezreal.EasyPay.WeChat.Sign;
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
            System.Net.Http.HttpResponseMessage response = context.ResponseMessage;
            string xml = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            Type dataType = context.ApiActionDescriptor.Return.DataType.Type;
            object result = context.HttpApiConfig.XmlFormatter.Deserialize(xml, dataType);

            IEnumerable<XElement> elements = XDocument.Parse(xml)?.Root?.Elements();
            if (elements != null && elements.Any())
            {
                if (result is WeChat.ApiModels.Response.WeChatPayResponse weChatPayResponse)
                {
                    weChatPayResponse.OriginalContent = xml;
                }

                {//验签
                    string returnSign = elements.FirstOrDefault(e => e.Name == "sign")?.Value;
                    if (!string.IsNullOrWhiteSpace(returnSign))
                    {
                        WeChatSignSettings signSettings = context.ApiActionDescriptor.Arguments.FirstOrDefault(arg => arg is WeChatSignSettings) as WeChatSignSettings;
                        SortedDictionary<string, string> parameters = new SortedDictionary<string, string>();
                        foreach (XElement element in elements)
                        {
                            if (!string.IsNullOrEmpty(element.Name.LocalName) && !string.IsNullOrEmpty(element.Value))
                            {
                                parameters.Add(element.Name.LocalName, element.Value);
                            }
                        }
                        string sign = new WeChatSignProvider(signSettings).SignWithKey(parameters);

                        if (sign != returnSign)
                        {
                            throw new CheckSignException($"targetSign:{sign} != {returnSign}");
                        }
                    }
                }

                if (result is IWeChatPayXmlReturnListPropertParser weChatPayXmlReturnListPropertParser)
                {
                    weChatPayXmlReturnListPropertParser.ParseListProperty(elements);
                }
            }
            return result;
        }
    }
}
