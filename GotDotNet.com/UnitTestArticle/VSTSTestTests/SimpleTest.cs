using System;
using Microsoft.VisualStudio.QualityTools.UnitTesting.Framework;

namespace VSTSTestTests
{

    [TestClass]
    public class SimpleTest
    {

        VSTSTest.Simple objSimple;

        [TestInitialize()]
        public void Initialize()
        {
            objSimple = new VSTSTest.Simple();
        }
   
        [TestMethod]
        public void TestAdd()
        {
            Assert.AreEqual(2, objSimple.Add(1, 1));      
        }

        [TestMethod]
        public void TestSubtract()
        {
            Assert.AreEqual(2, objSimple.Subtract(3,1));
        }
                
    }
}
