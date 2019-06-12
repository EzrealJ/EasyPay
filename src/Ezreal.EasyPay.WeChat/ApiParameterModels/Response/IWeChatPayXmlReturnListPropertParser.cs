using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Ezreal.EasyPay.WeChat.ApiParameterModels.Response
{
    interface IWeChatPayXmlReturnListPropertParser
    {
        void ParseListPropert(IEnumerable<XElement> elements);
    }
}
