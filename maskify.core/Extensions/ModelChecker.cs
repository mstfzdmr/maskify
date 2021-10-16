using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace maskify.core
{
    public static class ModelChecker
    {
        public static bool IsArrayModel(this object models)
        {
            var dynamicModels = JsonConvert.DeserializeObject<dynamic>(models.ToString());
            switch ((dynamicModels).Type)
            {
                case JTokenType.Array: 
                    return true;
                default:
                    return false;
            }
        }
    }
}
