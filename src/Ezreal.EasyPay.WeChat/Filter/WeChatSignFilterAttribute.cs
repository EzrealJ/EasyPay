using Ezreal.EasyPay.Abstractions.Filter;
using Ezreal.EasyPay.Common;
using Ezreal.EasyPay.Extensions;
using Ezreal.EasyPay.WeChat.Sign;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using WebApiClient.Contexts;

namespace Ezreal.EasyPay.WeChat.Filter
{
    /// <summary>
    /// 微信签名拦截器特性
    /// </summary>
    public class WeChatSignFilterAttribute : SignFilterAbstractAttribute
    {
        public override async Task SignRequestAsync(ApiActionContext context)
        {
            WeChatSignSettings signSettings = context.ApiActionDescriptor.Arguments.FirstOrDefault(arg => arg is WeChatSignSettings) as WeChatSignSettings;
            string xmlstring = await context.RequestMessage.Content.ReadAsStringAsync();
            XDocument xml = XDocument.Parse(xmlstring);

            XElement bodyDoc = xml.Root;
            bodyDoc.Add(new XElement("sign_type", signSettings.SignType.GetDescription()));
            SortedDictionary<string, string> parameters = new SortedDictionary<string, string>();
            foreach (XElement element in bodyDoc.Elements())
            {
                if (!string.IsNullOrEmpty(element.Name.LocalName) && !string.IsNullOrEmpty(element.Value))
                {
                    parameters.Add(element.Name.LocalName, element.Value);
                }
            }
            string sign = new WeChatSignProvider(signSettings).SignWithKey(parameters);
            bodyDoc.Add(new XElement("sign", sign));
            context.RequestMessage.Content = new StringContent(bodyDoc.ToString(), Encoding.UTF8, "application/xml");
        }
    }
}
