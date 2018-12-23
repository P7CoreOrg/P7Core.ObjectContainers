using System;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ObjectContainersTests
{
    public abstract class WebhostContainerTestBase
    {
        public WebhostContainer WebhostContainer { get; private set; }
        public IServiceScope ServiceScopeOne { get; set; }
        public IServiceScope ServiceScopeTwo { get; set; }
        public IServiceProvider ServiceProvider { get; private set; }

        [TestInitialize()]
        public void Initialize()
        {
            var webHost = WebHost.CreateDefaultBuilder()
                .UseStartup<Startup>()
                .Build();
            WebhostContainer = new WebhostContainer(webHost);
            ServiceScopeOne = WebhostContainer.ServiceScope;
            ServiceScopeTwo = WebhostContainer.ServiceScope;
            ServiceProvider = WebhostContainer.ServiceProvider;
        }



        [TestCleanup()]
        public void Cleanup()
        {
            ServiceScopeOne.Dispose();
            ServiceScopeOne = null;

            ServiceScopeTwo.Dispose();
            ServiceScopeTwo = null;
        }
    }
}