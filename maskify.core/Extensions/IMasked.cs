using maskify.core.Libraries;

namespace maskify.core.Extensions
{
    public interface IMasked
    {
        IMaskedProcessor GetMaskedProcessor(string propertyType);
    }
}
