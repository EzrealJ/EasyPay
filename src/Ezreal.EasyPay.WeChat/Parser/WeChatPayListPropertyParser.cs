using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Ezreal.EasyPay.WeChat.Parser
{
    public class WeChatPayListPropertyParser
    {
        public List<T> Parse<T, TChildren>(IEnumerable<XElement> elements, int index = -1)
        {
            bool flag = true;
            List<T> list = new List<T>();
            int i = 0;

            while (flag)
            {
                Type type = typeof(T);
                object obj = Activator.CreateInstance(type);
                PropertyInfo[] properties = type.GetProperties();
                bool isFirstProperty = true;

                foreach (PropertyInfo propertie in properties)
                {
                    if (propertie.PropertyType == typeof(List<TChildren>))
                    {
                        List<TChildren> chidrenList = Parse<TChildren, object>(elements, i);
                        propertie.SetValue(obj, chidrenList);
                        continue;
                    }

                    object[] renameAttribute = propertie.GetCustomAttributes(typeof(XmlElementAttribute), true);
                    if (renameAttribute.Length > 0)
                    {
                        string key = ((XmlElementAttribute)renameAttribute[0]).ElementName;

                        if (index > -1)
                        {
                            key += $"_{index}";
                        }

                        key += $"_{i}";

                        XElement value = elements.FirstOrDefault(e => e.Name == key);
                        if (value == null)
                        {
                            if (isFirstProperty)
                            {
                                flag = false;
                                break;
                            }

                            continue;
                        }

                        isFirstProperty = false;
                        propertie.SetValue(obj, Convert.ChangeType(value, propertie.PropertyType));
                    }
                }

                if (!flag)
                {
                    return list;
                }

                list.Add((T)obj);
                i++;
            }

            return list;
        }
    }
}
