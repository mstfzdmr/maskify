namespace maskify.api.Models
{
    public class Request
    {
        public string KeyValueJsonModel { get; set; }
        public string Replacement { get; set; }
    }

    public class Request<T> : Request
    {
        public T Model { get; set; }
    }
}
