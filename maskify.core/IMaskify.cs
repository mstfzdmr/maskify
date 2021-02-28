using maskify.models;

namespace maskify.core
{
    public interface IMaskify
    {
        MaskifyObject Mask(object model, string keyValueJsonModel, string replacement);
    }
}
