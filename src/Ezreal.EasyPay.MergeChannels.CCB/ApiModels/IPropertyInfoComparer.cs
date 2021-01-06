using System.Collections.Generic;
using Ezreal.EasyPay.Abstractions.ApiModels;
using Ezreal.EasyPay.Abstractions.Attributes;

namespace Ezreal.EasyPay.MergeChannels.CCB.ApiModels
{
    public interface IParameterNameComparer:IComparer<string>

    {
        SignOrderAttribute GetSignOrderAttribute(string key);
    }
}
