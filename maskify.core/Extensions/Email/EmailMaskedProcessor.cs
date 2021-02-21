using maskify.core.Libraries;
using maskify.core.Models;
using System;

namespace maskify.core.Extensions.Email
{
    public class EmailMaskedProcessor : IMaskedProcessor
    {
        public ProcessMaskedResult ProcessMask(ProcessMaskedRequest processMaskedRequest)
        {




            return new ProcessMaskedResult
            {
                PropertyValue = Convert.ChangeType(processMaskedRequest.PropertyValue, processMaskedRequest.PropertyType)
            };
        }
    }
}