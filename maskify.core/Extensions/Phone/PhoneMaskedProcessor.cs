﻿using maskify.core.Constant;
using maskify.core.Libraries;
using maskify.core.Models;
using System.Text.RegularExpressions;

namespace maskify.core.Extensions.Phone
{
    public class PhoneMaskedProcessor : IMaskedProcessor
    {
        public ProcessMaskedResult ProcessMask(ProcessMaskedRequest processMaskedRequest)
        {
            return !processMaskedRequest.MaskifyPropertyValue.Equals("")
                ? new ProcessMaskedResult { PropertyValue = processMaskedRequest.MaskifyPropertyValue }
                : new ProcessMaskedResult { PropertyValue = Regex.Replace($"{processMaskedRequest.PropertyValue}", Patterns.PhoneNumberPattern, processMaskedRequest.Replacement) };
        }
    }
}
