using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using P7Core.Reflection;
using P7CoreTests.Models;
using Shouldly;

namespace P7CoreTests
{
    [TestClass]
    public class TypeHelperUnitTests
    {
        [TestMethod]
        public void Test_IsPublicClass_Public()
        {
            TypeHelper<MyPublicEmptyClass>.IsPublicClassType().ShouldBe(true);
        }
        [TestMethod]
        public void Test_IsPublicClass_Private()
        {
            TypeHelper<MyPrivateClass>.IsPublicClassType().ShouldBe(false);
        }
        [TestMethod]
        public void Test_IsPublicClass_Abstract()
        {
            TypeHelper<MyAbstractClass>.IsPublicClassType().ShouldBe(false);
        }
        [TestMethod]
        public void Test_IsType_pass()
        {
            TypeHelper<TypeHelperUnitTests>.IsType(typeof(TypeHelperUnitTests)).ShouldBe(true);
        }
        [TestMethod]
        public void Test_IsType_fail()
        {
            TypeHelper<TypeHelperUnitTests>.IsType(typeof(MyPublicEmptyClass)).ShouldBe(false);
        }
        [TestMethod]
        public void Test_FindDerivedTypes_pass()
        {
            var derivedTypes = TypeHelper<MyPublicEmptyClass>.FindDerivedTypes(GetType().Assembly);
            derivedTypes.Any().ShouldBe(true);
        }
        [TestMethod]
        public void Test_FindDerivedTypes_fail()
        {
            var derivedTypes = TypeHelper<MyPublicSealedClass>.FindDerivedTypes(GetType().Assembly);
            derivedTypes.Any().ShouldBe(false);
        }
    }
    
}
 