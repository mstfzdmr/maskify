using maskify.core.Constant;
using maskify.core.Libraries;
using maskify.core.Models;
using System;
using System.Text.RegularExpressions;

namespace maskify.core.Extensions.Default
{
    public class DefaultMaskedProcessor : IMaskedProcessor
    {
        public ProcessMaskedResult ProcessMask(ProcessMaskedRequest processMaskedRequest)
        {
            if (!processMaskedRequest.MaskifyPropertyValue.Equals(""))
            {
                return new ProcessMaskedResult
                {
                    PropertyValue = Convert.ChangeType(processMaskedRequest.MaskifyPropertyValue, processMaskedRequest.PropertyType)
                };
            }

            var newPropertyValue = Regex.Replace($"{processMaskedRequest.PropertyValue}", Patterns.DefaultPattern, processMaskedRequest.Replacement);

            return new ProcessMaskedResult
            {
                PropertyValue = Convert.ChangeType(newPropertyValue, processMaskedRequest.PropertyType)
            };
        }
    }
}
