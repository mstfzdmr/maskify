namespace maskify.api.V1.Models.Requests
{
    public class MaskifyRequestModel
    {
        public string ReplacedJsonKeyValues { get; set; }
        public string Replacement { get; set; }
        public object Model { get; set; }
    }
}
