using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Xml.Serialization;

namespace Ezreal.EasyPay.MergeChannels.CCB.ApiModels.Request
{
    public class CCBEBS5HttpRequest<TXMLRequest>:StringContent
    {
        public CCBEBS5HttpRequest(TXMLRequest content)
            :base("requestXml="+ObjectAsXmlString(content))
        {
        }

        private static string ObjectAsXmlString(TXMLRequest content)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                new XmlSerializer(typeof(TXMLRequest)).Serialize(stream, content);
                return Encoding.GetEncoding("GB2312").GetString(stream.ToArray());
            }
        }


    }
}
