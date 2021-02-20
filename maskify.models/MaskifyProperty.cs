using Newtonsoft.Json;
using System.Collections.Generic;

namespace maskify.models
{
    [JsonObject]
    public class MaskifyProperty
    {
        [JsonExtensionData]
        public Dictionary<string, object> Properties { get; set; }
    }
}
