namespace maskify.models
{
    public class MaskifyRequest
    {
        public string ReplacedJsonKeyValues { get; set; }
        public string Replacement { get; set; }
        public object Model { get; set; }
    }
}
