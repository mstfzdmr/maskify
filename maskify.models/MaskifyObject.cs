using System.Collections.Generic;

namespace maskify.models
{
    public class MaskifyObject
    {
        public MaskifyObject()
        {
            Properties = new Dictionary<string, object>();
        }
        public Dictionary<string, object> Properties { get; set; }
    }
}
