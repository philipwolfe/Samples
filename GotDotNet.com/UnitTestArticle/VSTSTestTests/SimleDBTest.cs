using System;
using System.Data;
using Microsoft.VisualStudio.QualityTools.UnitTesting.Framework;

namespace VSTSTestTests
{

    [TestClass]
    public class SimpleDBTest
    {
        VSTSTest.Simple objSimple;

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the 
        ///current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }
        
   
        [TestInitialize()]
        public void Initialize()
        {
            objSimple = new VSTSTest.Simple();
        }

        [TestMethod, DataSource("System.Data.SqlClient", "Data Source=DBDEV1;Initial Catalog=Portix;Integrated Security=True", "AndyTest", DataAccessMethod.Sequential)]
        public void TestAddDB()
        {
            Assert.AreEqual((int)TestContext.DataRow["Result"], objSimple.Add((int)TestContext.DataRow["TestVal1"], (int)TestContext.DataRow["TestVal2"]));
        }
   
    }
}
