using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using MethodLibrary;
namespace NguyenDinhHao_17029171
{
    [TestClass]
    public class UTLab8
    {
        private TestContext testContext;

        public TestContext TestContext { get => testContext; set => testContext = value; }

        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV",
        @"|DataDirectory|\Data\UTLab8.csv", "UTLab8#csv", DataAccessMethod.Sequential),
        DeploymentItem(@"Data\UTLab8.csv"), TestMethod]
        public void TestTinhTienDien()
        {
            MethodLibrary.MethodLibrary method = new MethodLibrary.MethodLibrary();
            int chiSoCu = Convert.ToInt32(TestContext.DataRow[1].ToString());
            int chiSoMoi = Convert.ToInt32(TestContext.DataRow[2].ToString());

            //Actually result
            double AResult = method.TinhTienDien(chiSoCu, chiSoMoi);

            //Expected Result
            double EResult = Convert.ToDouble(TestContext.DataRow[3].ToString());


            Assert.AreEqual(EResult, AResult, 0.01);
            
        }
    }
}
