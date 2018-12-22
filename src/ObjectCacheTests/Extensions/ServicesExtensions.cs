using System;
using Microsoft.Extensions.DependencyInjection;

namespace ObjectCacheTests.Extensions
{
    public static class ServicesExtensions
    {
        public static T GetService<T>(this IServiceScope serviceScope)
        {
            var services = serviceScope.ServiceProvider;
            try
            {
                var scopedService = services.GetRequiredService<T>();
                return scopedService;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}