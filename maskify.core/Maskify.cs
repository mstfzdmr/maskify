using maskify.core.Constant;
using maskify.core.Services;
using maskify.models;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace maskify.core
{
    public class Maskify : IMaskify
    {
        private readonly IMaskedService _maskedService;
        public Maskify(IMaskedService maskedService)
        {
            _maskedService = maskedService;
        }

        public MaskifyObject Mask(object model, string replacedJsonKeyValues, string replacement)
        {
            return ToObject(model, replacedJsonKeyValues, replacement);
        }

        public List<MaskifyObject> Masks(object model, string replacedJsonKeyValues, string replacement)
        {
            var requestModel = JsonConvert.DeserializeObject<dynamic>(model.ToString());

            List<MaskifyObject> maskifyObjects = new List<MaskifyObject>();
            foreach (var item in requestModel)
            {
                var maskifyObject = ToObject(item, replacedJsonKeyValues, replacement);
                maskifyObjects.Add(maskifyObject);
            }

            return maskifyObjects;
        }

        private MaskifyObject ToObject(object model, string replacedJsonKeyValues, string replacement)
        {
            MaskifyExtensionData requestModel = JsonConvert.DeserializeObject<MaskifyExtensionData>(model.ToString());
            MaskifyExtensionData maskifyExtensionData = JsonConvert.DeserializeObject<MaskifyExtensionData>(replacedJsonKeyValues);

            MaskifyObject responseObjectModel = new MaskifyObject();

            foreach (KeyValuePair<string, object> item in requestModel.Properties)
            {
                if (maskifyExtensionData.Properties.TryGetValue(item.Key, out object maskifyExtensionDataValue))
                {
                    var processMaskedResult = _maskedService.ProcessMask(new Models.ProcessMaskedRequest
                    {
                        PropertyName = item.Key,
                        PropertyValue = item.Value,
                        MaskifyPropertyValue = maskifyExtensionDataValue,
                        Replacement = !string.IsNullOrEmpty(replacement) ? replacement : Replacements.DefaultReplacement
                    });

                    responseObjectModel.Properties.Add(item.Key, processMaskedResult.PropertyValue);
                }
                else
                {
                    responseObjectModel.Properties.Add(item.Key, item.Value);
                }
            }

            return responseObjectModel;
        }
    }
}
