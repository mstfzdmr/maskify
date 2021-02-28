namespace maskify.core.Models
{
    public class ProcessMaskedRequest
    {
        public string PropertyName { get; set; }
        public object PropertyValue { get; set; }
        public object MaskifyPropertyValue { get; set; }
        public string Replacement { get; set; }
    }
}
