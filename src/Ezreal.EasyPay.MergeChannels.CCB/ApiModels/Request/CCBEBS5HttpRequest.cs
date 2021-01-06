using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace Ezreal.EasyPay.MergeChannels.CCB.ApiModels.Request
{
    public class CCBEBS5HttpRequest<TXMLRequest>
    {
        public CCBEBS5HttpRequest(TXMLRequest content)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                new XmlSerializer(typeof(TXMLRequest)).Serialize(stream, content);
                RequestXml = Encoding.GetEncoding("GB2312").GetString(stream.ToArray());
            }
        }
        [WebApiClient.DataAnnotations.AliasAs("requestXml")]
        public string RequestXml { get;private set; }


    }
}
