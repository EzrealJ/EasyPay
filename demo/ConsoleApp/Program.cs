using System;
using System.Collections.Generic;
using System.Text;
using Ezreal.EasyPay.Common.Security;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);//注册中文代码页
            SortedDictionary<string, string> dictionary = new SortedDictionary<string, string>(new ASCIIComparer());
            dictionary.Add("AccessKeyId", "e2xxxxxx-99xxxxxx-84xxxxxx-7xxxx");
            dictionary.Add("order-id", "1234567890");
            dictionary.Add("SignatureMethod", "HmacSHA256");
            dictionary.Add("Timestamp", "2017-05-11T15%3A19%3A30");
            dictionary.Add("SignatureVersion", "2");


            StringBuilder sb = new StringBuilder();
            sb.AppendLine(@"GET\n");
            sb.AppendLine(@"api.huobi.pro\n");
            sb.AppendLine(@"/v1/order/orders\n");


            foreach (KeyValuePair<string, string> iter in dictionary)
            {
                if (!string.IsNullOrEmpty(iter.Value))
                {
                    sb.Append(iter.Key).Append('=').Append(iter.Value).Append("&");
                }
            }
            sb.Remove(sb.Length - 1, 1);
            Console.WriteLine(sb.ToString());

            string value = HMACSHA256Hash.HashToBase64(sb.ToString(), "b0xxxxxx-c6xxxxxx-94xxxxxx-dxxxx", "GBK");
            Console.WriteLine(value);
            Console.ReadKey();
        }
    }
}
