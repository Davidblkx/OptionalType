namespace System.Optional
{
    public interface IOption
    {
        bool HasValue();
        Option<T> ToType<T>();
    }
}
