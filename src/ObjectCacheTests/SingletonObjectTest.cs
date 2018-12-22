using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace ObjectCacheTests
{
    [TestClass]
    public class SingletonObjectTest : WebhostContainerTestBase
    {  
        /// <summary>
        /// This tests that resolving 2 different service are truly different, but internally these 2 service will share a common singleton object
        /// </summary>
        [TestMethod]
        public void Test_Simple_MyScopedObjectOne_MyScopedObjectTwo_SameContained_Scope()
        {
            var myScopedObjectOne_scope1 = ServiceScopeOne.GetService<MyScopedObjectOne>();
            var myScopedObjectTwo_scope1 = ServiceScopeOne.GetService<MyScopedObjectTwo>();

            myScopedObjectOne_scope1.SingletonName = Guid.NewGuid().ToString();
            myScopedObjectOne_scope1.SingletonName.ShouldBe(myScopedObjectTwo_scope1.SingletonName);
        }

        /// <summary>
        /// This tests that resolving the same service twice in the same scope returns the same service
        /// </summary>
        [TestMethod]
        public void Test_Simple_MyScopedObjectOne_Two_Scopes()
        {
            var myScopedObjectOne_scope1 = ServiceScopeOne.GetService<MyScopedObjectOne>();
            var myScopedObjectTwo_scope1 = ServiceScopeOne.GetService<MyScopedObjectTwo>();

            myScopedObjectOne_scope1.SingletonName = Guid.NewGuid().ToString();

            myScopedObjectOne_scope1.SingletonName.ShouldBe(myScopedObjectTwo_scope1.SingletonName);

            var myScopedObjectOne_scope2 = ServiceScopeTwo.GetService<MyScopedObjectOne>();
            var myScopedObjectTwo_scope2 = ServiceScopeTwo.GetService<MyScopedObjectTwo>();

            myScopedObjectOne_scope1.SingletonName.ShouldBe(myScopedObjectOne_scope2.SingletonName);
            myScopedObjectOne_scope1.SingletonName.ShouldBe(myScopedObjectTwo_scope2.SingletonName);
        }
    }
}