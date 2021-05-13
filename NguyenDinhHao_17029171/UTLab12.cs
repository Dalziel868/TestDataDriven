using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Text;

namespace NguyenDinhHao_17029171
{
    [TestClass]
    public class UTLab12
    {
        private TestContext testContext;

        public TestContext TestContext { get => testContext; set => testContext = value; }

        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV",
        @"|DataDirectory|\Data\UTLab12.csv", "UTLab12#csv", DataAccessMethod.Sequential),
        DeploymentItem(@"Data\UTLab12.csv"), TestMethod]
        public void TestLargest()
        {
            MethodLibrary.MethodLibrary method = new MethodLibrary.MethodLibrary();
            int[] aNguyen = new int[3];

           
            //
            if (!String.IsNullOrEmpty(TestContext.DataRow[1].ToString()))
            {
                string arrays = TestContext.DataRow[1].ToString();
                string[] separatingStrings = { "12"};
                string[] arrs = arrays.Split(separatingStrings, System.StringSplitOptions.RemoveEmptyEntries);
                
                for (int i = 0; i < arrs.Length; i++)
                {
                    aNguyen[i] = Convert.ToInt32(arrs[i]);
                }
            }
            else
            {
                aNguyen = new int[] { };
            }
            
            int ActualMax = method.Largest(aNguyen);

            int ExpecMax = Convert.ToInt32(TestContext.DataRow[2].ToString());
            

            Assert.AreEqual(ExpecMax, ActualMax);
        }
    }
}
