namespace P7Core.ObjectCaches
{
    public interface IObjectContainer<TContaining, T> where TContaining : class where T : class
    {
        T Value { get; set; }
    }
}