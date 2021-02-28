using Newtonsoft.Json;
using System.Collections.Generic;

namespace maskify.models
{
    [JsonObject]
    public class MaskifyExtensionData
    {
        [JsonExtensionData]
        public Dictionary<string, object> Properties { get; set; }
    }
}
