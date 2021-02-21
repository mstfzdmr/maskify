using maskify.core.Extensions.Default;
using maskify.core.Extensions.Email;
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
                //case "Id":
                //case "Password":
                //case "FirstName":
                //case "LastName":
                //case "Address":
                //case "Phone":
                default:
                    return new DefaultMaskedProcessor();
            }
        }
    }
}
