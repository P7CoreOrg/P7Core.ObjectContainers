using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace ObjectCacheTests
{
    public class WebhostContainer
    {
        private readonly IWebHost _webHost;

        /// <inheritdoc />
        public WebhostContainer(IWebHost WebHost) => _webHost = WebHost;

        public IServiceScope ServiceScope => _webHost.Services.CreateScope();
        public IServiceProvider ServiceProvider => _webHost.Services;

    }
}