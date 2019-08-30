using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Ezreal.EasyPay.Common
{
    public static class EnumExtension
    {

        /// <summary>
        /// 获取枚举的基类型值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static T GetUnderlyingValue<T>(this Enum value) where T : struct, IComparable, IComparable<T>, IConvertible, IEquatable<T>, IFormattable
        {
            if (Enum.GetUnderlyingType(value.GetType()) == typeof(T))
            {
                return (T)(value as ValueType);
            }
            else
            {
                throw new Exception($"Enumeration is not based on {typeof(T).Name}");
            }
        }

        /// <summary>
        /// 获得枚举的<see cref="DescriptionAttribute"/>
        /// </summary>
        /// <param name="value">枚举值</param>
        /// <param name="nameInstend">当枚举没有定义<see cref="DescriptionAttribute"/>,是否用枚举名代替，默认使用</param>
        /// <returns>枚举的Description</returns>
        public static string GetDescription(this Enum value, bool nameInstend = true)
        {
            Type type = value.GetType();
            string name = Enum.GetName(type, value);
            if (name == null)
            {
                return null;
            }
            FieldInfo field = type.GetField(name);
            DescriptionAttribute attribute = System.Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) as DescriptionAttribute;
            if (attribute == null && nameInstend == true)
            {
                return name;
            }
            return attribute == null ? null : attribute.Description;
        }
    }
}
