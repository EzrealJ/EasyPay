using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Ezreal.EasyPay.WeChat.ApiModels.Response
{
    /// <summary>
    /// 描述需要解析微信返回结果中列表属性的接口
    /// </summary>
    interface IWeChatPayXmlReturnListPropertParser
    {
        void ParseListProperty(IEnumerable<XElement> elements);
    }
}
