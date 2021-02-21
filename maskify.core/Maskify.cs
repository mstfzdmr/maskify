using maskify.core.Services;
using maskify.models;
using Newtonsoft.Json;
using System.ComponentModel;

namespace maskify.core
{
    public class Maskify<T> : IMaskify<T> where T : class
    {
        private readonly IMaskedService _maskedService;

        public Maskify(IMaskedService maskedService)
        {
            _maskedService = maskedService;
        }

        public T Mask(T model, string keyValueJsonModel)
        {
            var maskifyProperty = JsonConvert.DeserializeObject<MaskifyProperty>(keyValueJsonModel);

            var properties = TypeDescriptor.GetProperties(typeof(T));
            foreach (PropertyDescriptor property in properties)
            {
                if (maskifyProperty.Properties.TryGetValue(property.DisplayName, out object maskifyPropertyValue))
                {
                    var processMaskedResult = _maskedService.ProcessMask(new Models.ProcessMaskedRequest
                    {
                        PropertyName = property.DisplayName,
                        PropertyValue = property.GetValue(model),
                        PropertyType = property.PropertyType,
                        MaskifyPropertyValue = maskifyPropertyValue
                    });

                    property.SetValue(model, processMaskedResult.PropertyValue);
                }
            }

            return model;
        }
    }
}
