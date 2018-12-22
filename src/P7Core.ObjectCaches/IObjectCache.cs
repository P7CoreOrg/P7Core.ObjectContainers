namespace P7Core.ObjectCaches
{
    public interface IObjectCache<TContaining, T> where TContaining : class where T : class
    {
        T Value { get; set; }
    }
}