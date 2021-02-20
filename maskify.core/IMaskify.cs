namespace maskify.core
{
    public interface IMaskify<T>
    {
        T Mask(T model, string keyValueJsonModel);
    }
}
