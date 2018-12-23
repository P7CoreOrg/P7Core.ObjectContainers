namespace P7Core.ObjectCaches
{
    public interface IScopedObjectContainer<TContaining, T> : IObjectContainer<TContaining, T>
        where TContaining : class
        where T : class
    {
    }
}