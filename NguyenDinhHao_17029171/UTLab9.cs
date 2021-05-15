using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace NguyenDinhHao_17029171
{
    [TestClass]
    public class UTLab9
    {
        private TestContext testContextInstance;
        public TestContext TestContext
        {
            get { return testContextInstance; }
            set { testContextInstance = value; }
        }

        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV",
        @"|DataDirectory|\Data\UTLab9.csv", "UTLab9#csv", DataAccessMethod.Sequential),
        DeploymentItem(@"Data\UTLab9.csv"), TestMethod]
        public void TestSum()
        {
            MethodLibrary.MethodLibrary method = new MethodLibrary.MethodLibrary();
            long S0 = long.Parse(TestContext.DataRow[1].ToString());
            long ActualS;
            long ActualK = method.Sum(S0, out ActualS);

            long ExpecS = long.Parse(TestContext.DataRow[3].ToString());
            long ExpecK = long.Parse(TestContext.DataRow[2].ToString());

            Assert.AreEqual(ExpecK, ActualK);
            Assert.AreEqual(ExpecS, ActualS);

        }
    }
}
