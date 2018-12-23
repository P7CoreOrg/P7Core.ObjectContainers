using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using P7Core.Reflection;
using P7CoreTests.Models;
using Shouldly;

namespace P7CoreTests
{
    [TestClass]
    public class ReflectionUnitTests
    {
        [TestMethod]
        public void Test_IsPublicClass_Public()
        {
            typeof(MyPublicEmptyClass).IsPublicClass().ShouldBe(true);
        }
        [TestMethod]
        public void Test_IsPublicClass_Private()
        {
            typeof(MyPrivateClass).IsPublicClass().ShouldBe(false);
        }
        [TestMethod]
        public void Test_IsPublicClass_Abstract()
        {
            typeof(MyAbstractClass).IsPublicClass().ShouldBe(false);
        }
        [TestMethod]
        public void Test_IsGenericList_True()
        {
            List<string> someList = new List<string>();
            someList.IsGenericList().ShouldBe(true);
        }
        [TestMethod]
        public void Test_IsGenericList_False()
        {
            Stack<string> someList = new Stack<string>();
            someList.IsGenericList().ShouldBe(false);
        }
        [TestMethod]
        public void Test_GetConstants_Pass()
        {
            var constants = typeof(MyPublicClassJustStrings).GetConstants();
            constants.Any().ShouldBe(true);
        }
        [TestMethod]
        public void Test_GetConstants_Fail()
        {
            var constants = typeof(MyPublicEmptyClass).GetConstants();
            constants.Any().ShouldBe(false);
        }
        [TestMethod]
        public void Test_GetConstants_JustStrings_pass()
        {
            var constants = typeof(MyPublicClassJustStrings).GetConstants<string>();
            constants.Any().ShouldBe(true);
        }
        [TestMethod]
        public void Test_GetConstants_JustStrings_fail()
        {
            var constants = typeof(MyPublicClassJustInts).GetConstants<string>();
            constants.Any().ShouldBe(false);
        }
        [TestMethod]
        public void Test_GetConstantsValues_JustStrings_pass()
        {
            var constants = typeof(MyPublicClassJustStrings).GetConstantsValues<string>();
            constants.Any().ShouldBe(true);
        }
        [TestMethod]
        public void Test_AssemblyQualifiedNameWithoutVersion_pass()
        {
            var name = typeof(MyPublicClassJustStrings).AssemblyQualifiedNameWithoutVersion();
            string.IsNullOrEmpty(name).ShouldBe(false);
        }

    }
}