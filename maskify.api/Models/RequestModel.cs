namespace maskify.api.Models
{
    public class RequestModel
    {
        public string KeyValueJsonModel { get; set; }
        public string Replacement { get; set; }
    }

    public class RequestModel<T> : RequestModel
    {
        public T Model { get; set; }
    }
}
