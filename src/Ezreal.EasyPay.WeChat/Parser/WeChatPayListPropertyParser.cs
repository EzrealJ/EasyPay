﻿using System;
using System.Collections.Generic;
using System.Linq;
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
            var flag = true;
            var list = new List<T>();
            var i = 0;

            while (flag)
            {
                var type = typeof(T);
                var obj = Activator.CreateInstance(type);
                var properties = type.GetProperties();
                var isFirstProperty = true;

                foreach (var propertie in properties)
                {
                    if (propertie.PropertyType == typeof(List<TChildren>))
                    {
                        var chidrenList = Parse<TChildren, object>(elements, i);
                        propertie.SetValue(obj, chidrenList);
                        continue;
                    }

                    var renameAttribute = propertie.GetCustomAttributes(typeof(XmlElementAttribute), true);
                    if (renameAttribute.Length > 0)
                    {
                        var key = ((XmlElementAttribute)renameAttribute[0]).ElementName;

                        if (index > -1)
                        {
                            key += $"_{index}";
                        }

                        key += $"_{i}";

                        var value = elements.FirstOrDefault(e => e.Name == key);
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
