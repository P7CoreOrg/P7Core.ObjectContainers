using System;

namespace P7Core.ObjectCaches
{
    public interface IScopedAutoObjectContainer<TContaining, T> : IObjectContainer<TContaining, T>
        where TContaining : class
        where T : class
    {
    }
}
