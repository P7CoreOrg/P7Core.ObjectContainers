namespace P7Core.ObjectCaches
{
    public interface IObjectCacheAllocator<TContaining, out T> where TContaining : class where T : class
    {
        T Allocate();
    }
}