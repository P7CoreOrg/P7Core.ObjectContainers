namespace P7Core.ObjectCaches
{
    public interface ISingletonObjectCache<TContaining, T> : IObjectCache<TContaining, T>
        where TContaining : class
        where T : class
    {
    }
}