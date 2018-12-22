using System;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace ObjectCacheTests
{
    [TestClass]
    public class ScopedObjectTest
    {
        public WebhostContainer WebhostContainer { get; private set; }
        public IServiceScope ServiceScope { get; set; }
        public IServiceProvider ServiceProvider { get; private set; }

        [TestInitialize()]
        public void Initialize()
        {
            var webHost = WebHost.CreateDefaultBuilder()
                .UseStartup<Startup>()
                .Build();
            WebhostContainer = new WebhostContainer(webHost);
            ServiceScope = WebhostContainer.ServiceScope;
            ServiceProvider = WebhostContainer.ServiceProvider;
        }

     

        [TestCleanup()]
        public void Cleanup()
        {
            ServiceScope.Dispose();
            ServiceScope = null;
        }

        /// <summary>
        /// This tests that resolving the same service twice in the same scope returns the same service
        /// </summary>
        [TestMethod]
        public void Test_Simple_MyScopedObjectOne_ScopeIntegrity()
        {
            var myScopedObjectOne_1 = ServiceScope.GetService<MyScopedObjectOne>();
            var myScopedObjectOne_2 = ServiceScope.GetService<MyScopedObjectOne>();

            myScopedObjectOne_1.Name = Guid.NewGuid().ToString();
            myScopedObjectOne_1.Name.ShouldBe(myScopedObjectOne_2.Name);
        }

        /// <summary>
        /// This tests that resolving the same service twice in the same scope returns the same service
        /// </summary>
        [TestMethod]
        public void Test_Simple_MyScopedObjectTwo_ScopeIntegrity()
        {
            var myScopedObjectTwo_1 = ServiceScope.GetService<MyScopedObjectTwo>();
            var myScopedObjectTwo_2 = ServiceScope.GetService<MyScopedObjectTwo>();

            myScopedObjectTwo_1.Name = Guid.NewGuid().ToString();
            myScopedObjectTwo_1.Name.ShouldBe(myScopedObjectTwo_2.Name);

        }

        /// <summary>
        /// This tests that resolving 2 different service are truly different, but internally these 2 service will share a common scoped object
        /// </summary>
        [TestMethod]
        public void Test_Simple_MyScopedObjectOne_MyScopedObjectTwo_ScopeIntegrity()
        {
            var myScopedObjectOne = ServiceScope.GetService<MyScopedObjectOne>();
            var myScopedObjectTwo = ServiceScope.GetService<MyScopedObjectTwo>();

            myScopedObjectOne.Name = Guid.NewGuid().ToString();
            myScopedObjectOne.Name.ShouldNotBe(myScopedObjectTwo.Name);
        }

        /// <summary>
        /// This tests that resolving 2 different service are truly different, but internally these 2 service will share a common scoped object
        /// </summary>
        [TestMethod]
        public void Test_Simple_MyScopedObjectOne_MyScopedObjectTwo_SameContained_ScopeIntegrity()
        {
            var myScopedObjectOne = ServiceScope.GetService<MyScopedObjectOne>();
            var myScopedObjectTwo = ServiceScope.GetService<MyScopedObjectTwo>();

            myScopedObjectOne.ScopedName = Guid.NewGuid().ToString();
            myScopedObjectTwo.ScopedName.ShouldBe(myScopedObjectTwo.ScopedName);
        }

    }
}
