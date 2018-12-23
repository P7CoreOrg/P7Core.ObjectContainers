namespace P7Core.ObjectCaches
{
    public interface IObjectAllocator<TContaining, out T> where TContaining : class where T : class
    {
        T Allocate();
    }
}