using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace maskify.api
{
    public static class ModelChecker
    {
        public static bool IsArrayModel(this object models)
        {
            var dynamicModels = JsonConvert.DeserializeObject<dynamic>(models.ToString());
            if (((JArray)dynamicModels).Type == JTokenType.Array)
            {
                return true;
            }

            return false;
        }
    }
}
