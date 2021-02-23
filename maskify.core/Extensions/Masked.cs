using maskify.core.Extensions.Default;
using maskify.core.Extensions.Email;
using maskify.core.Extensions.Phone;
using maskify.core.Libraries;

namespace maskify.core.Extensions
{
    public class Masked : IMasked
    {
        public IMaskedProcessor GetMaskedProcessor(string propertyName)
        {
            switch (propertyName)
            {
                case "Email":
                    return new EmailMaskedProcessor();
                case "Phone":
                case "MobilePhone":
                    return new PhoneMaskedProcessor();
                default:
                    return new DefaultMaskedProcessor();
            }
        }
    }
}
