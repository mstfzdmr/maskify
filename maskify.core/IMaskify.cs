using maskify.models;
using System.Collections.Generic;

namespace maskify.core
{
    public interface IMaskify
    {
        List<MaskifyObject> Mask(object model, string replacedJsonKeyValues, string replacement);
    }
}
