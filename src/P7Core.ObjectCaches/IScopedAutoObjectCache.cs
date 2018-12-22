using System;

namespace P7Core.ObjectCaches
{
    public interface IScopedAutoObjectCache<TContaining, T> : IObjectCache<TContaining, T>
        where TContaining : class
        where T : class
    {
    }
}
