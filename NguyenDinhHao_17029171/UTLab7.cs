using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using MethodLibrary;
using System.Text;

namespace NguyenDinhHao_17029171
{
    [TestClass]
    public class UTLab7
    {
        private static readonly string[] VietnameseSigns = new string[]
        {

            "aAeEoOuUiIdDyY",

            "áàạảãâấầậẩẫăắằặẳẵ",

            "ÁÀẠẢÃÂẤẦẬẨẪĂẮẰẶẲẴ",

            "éèẹẻẽêếềệểễ",

            "ÉÈẸẺẼÊẾỀỆỂỄ",

            "óòọỏõôốồộổỗơớờợởỡ",

            "ÓÒỌỎÕÔỐỒỘỔỖƠỚỜỢỞỠ",

            "úùụủũưứừựửữ",

            "ÚÙỤỦŨƯỨỪỰỬỮ",

            "íìịỉĩ",

            "ÍÌỊỈĨ",

            "đ",

            "Đ",

            "ýỳỵỷỹ",

            "ÝỲỴỶỸ"
        };
        private TestContext testContext;

        public TestContext TestContext { get => testContext; set => testContext = value; }

        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV",
        @"|DataDirectory|\Data\UTLab7.csv", "UTLab7#csv", DataAccessMethod.Sequential),
        DeploymentItem(@"Data\UTLab7.csv"), TestMethod]
        public void TestSolveQuadratic()
        {

            MethodLibrary.MethodLibrary method = new MethodLibrary.MethodLibrary();
            //Actually
            int AcA = Convert.ToInt32(TestContext.DataRow[1].ToString());
            int AcB = Convert.ToInt32(TestContext.DataRow[2].ToString());
            int AcC = Convert.ToInt32(TestContext.DataRow[3].ToString());
            float AcX1;
            float AcX2;
            String AcReturn = method.SolveQuadratic(AcA, AcB, AcC, out AcX1, out AcX2);
            //Mục đích để chuyển về string không dấu cho dễ so sánh, do khi so sánh dấu trong file csv bị mã hóa text
            for (int i = 1; i < VietnameseSigns.Length; i++)
            {
                for (int j = 0; j < VietnameseSigns[i].Length; j++)
                    AcReturn = AcReturn.Replace(VietnameseSigns[i][j], VietnameseSigns[0][i - 1]);
            }

            //Expected
            
            float ExX1;
            //chả hiểu sao NaN trong csv nhưng khi convert toString in c# thi = ""
            if(TestContext.DataRow[4].ToString().Equals("NaN") || TestContext.DataRow[4].ToString().Equals(""))
            {
                ExX1 = Single.NaN;
            }
            else
            {
                ExX1 = float.Parse(TestContext.DataRow[4].ToString());
            }


            float ExX2;
            if (TestContext.DataRow[5].ToString().Equals("NaN")|| TestContext.DataRow[5].ToString().Equals(""))
            {
                ExX2 = Single.NaN;
            }
            else
            {
                ExX2 = float.Parse(TestContext.DataRow[5].ToString());
            }


            String ExReturn = TestContext.DataRow[6].ToString();


            Assert.AreEqual(ExX1, AcX1);
            Assert.AreEqual(ExX2, AcX2);
            Assert.AreEqual(ExReturn, AcReturn);
        }
    }
    
}
