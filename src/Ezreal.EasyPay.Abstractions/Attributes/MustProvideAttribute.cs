using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ezreal.EasyPay.Abstractions.Attributes
{
    /// <summary>
    /// 标识参数是否是必须的
    /// <para>
    /// 使用此特性默认参数是必须的，但可以使用<see cref="MustProvideAttribute(bool)"/>来显式指定
    /// </para>
    /// </summary>
    public class MustProvideAttribute:System.Attribute
    {
        public MustProvideAttribute()
        {
        }

        public MustProvideAttribute(bool mustProvide)
        {
            MustProvide = mustProvide;
        }

        public bool MustProvide { get; set; } = true;
    }
}
