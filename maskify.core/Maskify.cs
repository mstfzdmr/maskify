using maskify.models;
using Newtonsoft.Json;
using System.ComponentModel;

namespace maskify.core
{
    public class Maskify<T> : IMaskify<T> where T : class
    {
        public T Mask(T model, string keyValueJsonModel)
        {
            var maskifyProperty = JsonConvert.DeserializeObject<MaskifyProperty>(keyValueJsonModel);

            var properties = TypeDescriptor.GetProperties(typeof(T));
            foreach (PropertyDescriptor property in properties)
            {

            }

            return model;
        }
    }
}
