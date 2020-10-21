using System.Collections.Generic;
using Ezreal.EasyPay.Abstractions.ApiParameterModels;
using Ezreal.EasyPay.Abstractions.Attributes;

namespace Ezreal.EasyPay.MergeChannels.CCB.ApiParameterModels
{
    public interface IParameterNameComparer:IComparer<string>

    {
        SignOrderAttribute GetSignOrderAttribute(string key);
    }
}
