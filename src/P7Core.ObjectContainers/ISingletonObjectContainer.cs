namespace P7Core.ObjectCaches
{
    public interface ISingletonObjectContainer<TContaining, T> : IObjectContainer<TContaining, T>
        where TContaining : class
        where T : class
    {
    }
}