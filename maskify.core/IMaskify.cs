using maskify.models;
using System.Collections.Generic;

namespace maskify.core
{
    public interface IMaskify
    {
        MaskifyObject Mask(object model, string replacedJsonKeyValues, string replacement);
        List<MaskifyObject> Masks(object model, string replacedJsonKeyValues, string replacement);
    }
}
