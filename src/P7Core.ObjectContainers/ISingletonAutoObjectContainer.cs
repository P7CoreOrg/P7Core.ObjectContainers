namespace P7Core.ObjectCaches
{
    public interface ISingletonAutoObjectContainer<TContaining, T> : IObjectContainer<TContaining, T>
        where TContaining : class
        where T : class
    {
    }
}