using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ObjectCacheTests.Extensions;
using ObjectCacheTests.Models;
using Shouldly;

namespace ObjectCacheTests
{
    [TestClass]
    public class ScopedObjectTest : WebhostContainerTestBase
    {
        /// <summary>
        /// This tests that resolving the same service twice in the same scope returns the same service
        /// </summary>
        [TestMethod]
        public void Test_Simple_MyScopedObjectOne_Same_Scope()
        {
            var myScopedObjectOne_1_scope1 = ServiceScopeOne.GetService<MyScopedObjectOne>();
            var myScopedObjectOne_2_scope1 = ServiceScopeOne.GetService<MyScopedObjectOne>();

            myScopedObjectOne_1_scope1.Name = Guid.NewGuid().ToString();
            myScopedObjectOne_1_scope1.Name.ShouldBe(myScopedObjectOne_2_scope1.Name);
        }

        /// <summary>
        /// This tests that resolving the same service twice in the same scope returns the same service
        /// </summary>
        [TestMethod]
        public void Test_Simple_MyScopedObjectOne_Two_Scopes()
        {
            var myScopedObjectOne_1_scope1 = ServiceScopeOne.GetService<MyScopedObjectOne>();
            var myScopedObjectOne_2_scope1 = ServiceScopeOne.GetService<MyScopedObjectOne>();

            myScopedObjectOne_1_scope1.Name = Guid.NewGuid().ToString();
            myScopedObjectOne_1_scope1.Name.ShouldBe(myScopedObjectOne_2_scope1.Name);

            var myScopedObjectOne_1_scope2 = ServiceScopeTwo.GetService<MyScopedObjectOne>();
            var myScopedObjectOne_2_scope2 = ServiceScopeTwo.GetService<MyScopedObjectOne>();

            myScopedObjectOne_1_scope2.Name = Guid.NewGuid().ToString();
            myScopedObjectOne_1_scope2.Name.ShouldBe(myScopedObjectOne_2_scope2.Name);


            myScopedObjectOne_1_scope1.Name.ShouldNotBe(myScopedObjectOne_1_scope2.Name);
        }

        /// <summary>
        /// This tests that resolving the same service twice in the same scope returns the same service
        /// </summary>
        [TestMethod]
        public void Test_Simple_MyScopedObjectTwo_Same_Scope()
        {
            var myScopedObjectTwo_1_scope1 = ServiceScopeOne.GetService<MyScopedObjectTwo>();
            var myScopedObjectTwo_2_scope1 = ServiceScopeOne.GetService<MyScopedObjectTwo>();

            myScopedObjectTwo_1_scope1.Name = Guid.NewGuid().ToString();
            myScopedObjectTwo_1_scope1.Name.ShouldBe(myScopedObjectTwo_2_scope1.Name);

        }

        /// <summary>
        /// This tests that resolving 2 different service are truly different, but internally these 2 service will share a common scoped object
        /// </summary>
        [TestMethod]
        public void Test_Simple_MyScopedObjectOne_MyScopedObjectTwo_Same_Scope()
        {
            var myScopedObjectOne_scope1 = ServiceScopeOne.GetService<MyScopedObjectOne>();
            var myScopedObjectTwo_scope1 = ServiceScopeOne.GetService<MyScopedObjectTwo>();

            myScopedObjectOne_scope1.Name = Guid.NewGuid().ToString();
            myScopedObjectOne_scope1.Name.ShouldNotBe(myScopedObjectTwo_scope1.Name);
        }

        /// <summary>
        /// This tests that resolving 2 different service are truly different, but internally these 2 service will share a common scoped object
        /// </summary>
        [TestMethod]
        public void Test_Simple_MyScopedObjectOne_MyScopedObjectTwo_SameContained_Same_Scope()
        {
            var myScopedObjectOne_scope1 = ServiceScopeOne.GetService<MyScopedObjectOne>();
            var myScopedObjectTwo_scope1 = ServiceScopeOne.GetService<MyScopedObjectTwo>();

            myScopedObjectOne_scope1.ScopedName = Guid.NewGuid().ToString();
            myScopedObjectOne_scope1.ScopedName.ShouldBe(myScopedObjectTwo_scope1.ScopedName);
        }

        /// <summary>
        /// This tests that resolving 2 different service are truly different, but internally these 2 service will share a common singleton object
        /// </summary>
        [TestMethod]
        public void Test_AutoPerson_MyScopedObjectOne_MyScopedObjectTwo_SameContained_Scope()
        {
            var myScopedObjectOne_scope1 = ServiceScopeOne.GetService<MyScopedObjectOne>();
            var myScopedObjectTwo_scope1 = ServiceScopeOne.GetService<MyScopedObjectTwo>();

            myScopedObjectOne_scope1.ScopedPerson.ShouldNotBeNull();
            myScopedObjectTwo_scope1.ScopedPerson.ShouldNotBeNull();

            myScopedObjectOne_scope1.ScopedPerson.Name.ShouldBe(myScopedObjectTwo_scope1.ScopedPerson.Name);
        }

        /// <summary>
        /// This tests that resolving 2 different service are truly different, but internally these 2 service will share a common singleton object
        /// </summary>
        [TestMethod]
        public void Test_New_AutoPerson_MyScopedObjectOne_MyScopedObjectTwo_SameContained_Scope()
        {
            var myScopedObjectOne_scope1 = ServiceScopeOne.GetService<MyScopedObjectOne>();
            var myScopedObjectTwo_scope1 = ServiceScopeOne.GetService<MyScopedObjectTwo>();

            myScopedObjectOne_scope1.ScopedPerson.ShouldNotBeNull();
            myScopedObjectTwo_scope1.ScopedPerson.ShouldNotBeNull();

            myScopedObjectOne_scope1.ScopedPerson.ShouldBe(myScopedObjectTwo_scope1.ScopedPerson);

            myScopedObjectOne_scope1.ScopedPerson = new Person() {Name = Guid.NewGuid().ToString()};
            myScopedObjectOne_scope1.ScopedPerson.ShouldBe(myScopedObjectTwo_scope1.ScopedPerson);

        }

        /// <summary>
        /// This tests that resolving the same service twice in the same scope returns the same service
        /// </summary>
        [TestMethod]
        public void Test_AutoPerson_MyScopedObjectOne_Two_Scopes()
        {
            var myScopedObjectOne_1_scope1 = ServiceScopeOne.GetService<MyScopedObjectOne>();
            var myScopedObjectOne_2_scope1 = ServiceScopeOne.GetService<MyScopedObjectOne>();

            myScopedObjectOne_1_scope1.ScopedPerson.ShouldNotBeNull();
            myScopedObjectOne_2_scope1.ScopedPerson.ShouldNotBeNull();

            var myScopedObjectOne_1_scope2 = ServiceScopeTwo.GetService<MyScopedObjectOne>();
            var myScopedObjectOne_2_scope2 = ServiceScopeTwo.GetService<MyScopedObjectOne>();

            myScopedObjectOne_1_scope2.ScopedPerson.ShouldNotBeNull();
            myScopedObjectOne_2_scope2.ScopedPerson.ShouldNotBeNull();


            myScopedObjectOne_1_scope1.ScopedPerson.ShouldNotBe(myScopedObjectOne_1_scope2.ScopedPerson);
        }
    }
}
