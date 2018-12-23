using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ObjectContainersTests.Models; 
using P7Core.ObjectContainers;
using P7Core.ObjectContainers.Extensions;

namespace ObjectContainersTests
{
    public class Startup
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        public IConfiguration Configuration { get; set; }

        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            _hostingEnvironment = env;
            Configuration = configuration;
        }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddObjectContainer();
            services.AddScoped<MyScopedStringContainer>();
            services.AddScoped<MySingletonStringContainer>();

            services.AddScoped<MyScopedObjectTwo>();
            services.AddScoped<MyScopedObjectOne>();


            services.AddScoped<MyScopedAutoPersonContainer>();
            services.AddScoped<MySingletonAutoPersonContainer>();
            services.AddTransient<ObjectAllocator<MyScopedAutoPersonContainer, Person>>();
            services.AddTransient<ObjectAllocator<MySingletonAutoPersonContainer, Person>>();

            return services.BuildServiceProvider();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            // only called with the webHost is run
        }
    }
}