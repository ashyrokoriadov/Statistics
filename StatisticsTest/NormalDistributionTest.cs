using Microsoft.VisualStudio.TestTools.UnitTesting;
using Statistics.Implementations;

namespace StatisticsTest
{
    [TestClass]
    public class NormalDistributionTest
    {
        double[] arrayDouble = { -2.5, -2, -1.5, -1, -0.5, 0, 0.5, 1, 1.5, 2, 2.5 };
        double[] zArrayDouble = { -1.50755672288881, -1.20604537831105, -0.90453403373329, -0.603022689155527, -0.301511344577763, 0, 0.301511344577763, 0.603022689155527, 0.90453403373329, 1.20604537831105, 1.50755672288881 };
        decimal[] arrayDecimal = { -2.5M, -2M, -1.5M, -1M, -0.5M, 0M, 0.5M, 1M, 1.5M, 2M, 2.5M };
        decimal[] zArrayDecimal = { -1.5075567228888180446499388515M, -1.2060453783110544357199510812M, -0.9045340337332908267899633109M, -0.6030226891555272178599755406M, -0.3015113445777636089299877703M, 0, 0.3015113445777636089299877703M, 0.6030226891555272178599755406M, 0.9045340337332908267899633109M, 1.2060453783110544357199510812M, 1.5075567228888180446499388515M };
        float[] arrayFloat = { -2.5F, -2F, -1.5F, -1F, -0.5F, 0F, 0.5F, 1F, 1.5F, 2F, 2.5F };
        float[] zArrayFloat = { -1.50755672288881F, -1.20604537831105F, -0.90453403373329F, -0.603022689155527F, -0.301511344577763F, 0, 0.301511344577763F, 0.603022689155527F, 0.90453403373329F, 1.20604537831105F, 1.50755672288881F };

        NormalDistribution ndDouble;
        NormalDistribution ndDecimal;
        NormalDistribution ndFloat;

        [TestInitialize]
        public void TestInitialize()
        {
            ndDouble = new NormalDistribution(arrayDouble);
            ndDecimal = new NormalDistribution(arrayDecimal);
            ndFloat = new NormalDistribution(arrayFloat);
        }

        [TestMethod]
        public void ShoudlReturnCorrectMean_NormalDistribution_Double()
        {
            Assert.AreEqual(0, (double)ndDouble.GetMean());
        }

        [TestMethod]
        public void ShoudlReturnCorrectProbabiltiyForGetProbabilityLessThan_NormalDistribution_Double()
        {
            Assert.AreEqual(0.7257, (double)ndDouble.GetProbabilityLessThan(1), 0.001);
        }

        [TestMethod]
        public void ShoudlReturnCorrectProbabiltiyForGetProbabilityGreaterThan_NormalDistribution_Double()
        {
            Assert.AreEqual(0.2743, (double)ndDouble.GetProbabilityGreaterThan(1), 0.003);
        }

        [TestMethod]
        public void ShoudlReturnCorrectProbabiltiyForGetProbabilityBetween_NormalDistribution_Double()
        {
            Assert.AreEqual(0.2257, (double)ndDouble.GetProbabilityBetween(0, 1), 0.003);
        }

        [TestMethod]
        public void ShoudlReturnCorrectZArray_NormalDistribution_Double()
        {
            double[] array = (double[])ndDouble.GetZArray();

            Assert.IsTrue(array.Length == zArrayDouble.Length);               

            for (int i=0; i < array.Length; i++)
            {
                Assert.AreEqual(zArrayDouble[i], array[i], 0.000001);
            }
        }

        [TestMethod]
        public void ShoudlReturnCorrectValueFromProbability_NormalDistribution_Double()
        {
            double testValue1 = (double)ndDouble.GetValueFromProbability(3);
            Assert.AreEqual(-3.1176273, testValue1, 0.000001);

            double testValue2 = (double)ndDouble.GetValueFromProbability(52);
            Assert.AreEqual(0.0829156, testValue2, 0.000001);

            double testValue3 = (double)ndDouble.GetValueFromProbability(97);
            Assert.AreEqual(3.1176273, testValue3, 0.000001);
        }

        [TestMethod]
        public void ShoudlReturnCorrectConfidenceLevel_NormalDistribution_Double()
        {
            double testValue1 = (double)ndDouble.GetConfidenceInterval(1.0);
            Assert.AreEqual(0.00999, testValue1, 0.00001);

            double testValue2 = (double)ndDouble.GetConfidenceInterval(2.0);
            Assert.AreEqual(0.01499, testValue2, 0.00001);

            double testValue3 = (double)ndDouble.GetConfidenceInterval(3.0);
            Assert.AreEqual(0.01999, testValue3, 0.00001);
        }

        [TestMethod]
        public void ShoudlReturnCorrectZForConfidenceLevel_NormalDistribution_Double()
        {
            double testValue1 = (double)ndDouble.GetZForConfidenceLevel(1.0);
            Assert.AreEqual(0.01999, testValue1, 0.0001);

            double testValue2 = (double)ndDouble.GetZForConfidenceLevel(2.0);
            Assert.AreEqual(0.02999, testValue2, 0.00001);

            double testValue3 = (double)ndDouble.GetZForConfidenceLevel(3.0);
            Assert.AreEqual(0.03999, testValue3, 0.00001);
        }

        [TestMethod]
        public void ShoudlReturnCorrectMean_NormalDistribution_Decimal()
        {
            Assert.AreEqual(0, (decimal)ndDecimal.GetMean());
        }

        [TestMethod]
        public void ShoudlReturnCorrectProbabiltiyForGetProbabilityLessThan_NormalDistribution_Decimal()
        {
            Assert.AreEqual(0.726620534050171M, (decimal)ndDecimal.GetProbabilityLessThan(1M));
        }

        [TestMethod]
        public void ShoudlReturnCorrectProbabiltiyForGetProbabilityGreaterThan_NormalDistribution_Decimal()
        {
            Assert.AreEqual(0.273117594848389M, (decimal)ndDecimal.GetProbabilityGreaterThan(1M));
        }

        [TestMethod]
        public void ShoudlReturnCorrectProbabiltiyForGetProbabilityBetween_NormalDistribution_Decimal()
        {
            Assert.AreEqual(0.226760999147863M, (decimal)ndDecimal.GetProbabilityBetween(0M, 1M));
        }

        [TestMethod]
        public void ShoudlReturnCorrectZArray_NormalDistribution_Decimal()
        {
            decimal[] array = (decimal[])ndDecimal.GetZArray();
            Assert.IsTrue(array.Length == zArrayDecimal.Length);
            CollectionAssert.AreEqual(zArrayDecimal, array);
        }

        [TestMethod]
        public void ShoudlReturnCorrectValueFromProbability_NormalDistribution_Decimal()
        {
            decimal testValue1 = (decimal)ndDecimal.GetValueFromProbability(3);
            Assert.AreEqual(-3.117627302934076M, testValue1);

            decimal testValue2 = (decimal)ndDecimal.GetValueFromProbability(52);
            Assert.AreEqual(0.082915619758885M, testValue2);

            decimal testValue3 = (decimal)ndDecimal.GetValueFromProbability(97);
            Assert.AreEqual(3.117627302934076M, testValue3);
        }

        [TestMethod]
        public void ShoudlReturnCorrectConfidenceLevel_NormalDistribution_Decimal()
        {
            decimal testValue1 = (decimal)ndDecimal.GetConfidenceInterval(1.0);
            Assert.AreEqual(0.01M, testValue1);

            decimal testValue2 = (decimal)ndDecimal.GetConfidenceInterval(2.0);
            Assert.AreEqual(0.015M, testValue2);

            decimal testValue3 = (decimal)ndDecimal.GetConfidenceInterval(3.0);
            Assert.AreEqual(0.02M, testValue3);
        }

        [TestMethod]
        public void ShoudlReturnCorrectZForConfidenceLevel_NormalDistribution_Decimal()
        {
            decimal testValue1 = (decimal)ndDecimal.GetZForConfidenceLevel(1.0M);
            Assert.AreEqual(0.02M, testValue1);

            decimal testValue2 = (decimal)ndDecimal.GetZForConfidenceLevel(2.0M);
            Assert.AreEqual(0.03M, testValue2);

            decimal testValue3 = (decimal)ndDecimal.GetZForConfidenceLevel(3.0M);
            Assert.AreEqual(0.04M, testValue3);
        }

        [TestMethod]
        public void ShoudlReturnCorrectMean_NormalDistribution_Float()
        {
            Assert.AreEqual(0F, (float)ndFloat.GetMean());
        }

        [TestMethod]
        public void ShoudlReturnCorrectProbabiltiyForGetProbabilityLessThan_NormalDistribution_Float()
        {
            Assert.AreEqual(0.7257F, (float)ndFloat.GetProbabilityLessThan(1F), 0.001);
        }

        [TestMethod]
        public void ShoudlReturnCorrectProbabiltiyForGetProbabilityGreaterThan_NormalDistribution_Float()
        {
            Assert.AreEqual(0.2743F, (float)ndFloat.GetProbabilityGreaterThan(1F), 0.003);
        }

        [TestMethod]
        public void ShoudlReturnCorrectProbabiltiyForGetProbabilityBetween_NormalDistribution_Float()
        {
            Assert.AreEqual(0.2257F, (float)ndFloat.GetProbabilityBetween(0F, 1F), 0.003);
        }

        [TestMethod]
        public void ShoudlReturnCorrectZArray_NormalDistribution_Float()
        {
            float[] array = (float[])ndFloat.GetZArray();

            Assert.IsTrue(array.Length == zArrayFloat.Length);

            for (int i = 0; i < array.Length; i++)
            {
                Assert.AreEqual(zArrayFloat[i], array[i], 0.000001);
            }
        }

        [TestMethod]
        public void ShoudlReturnCorrectValueFromProbability_NormalDistribution_Float()
        {
            float testValue1 = (float)ndFloat.GetValueFromProbability(3);
            Assert.AreEqual(-3.11763000488281, testValue1, 0.0001);

            float testValue2 = (float)ndFloat.GetValueFromProbability(52);
            Assert.AreEqual(0.0829156, testValue2, 0.0001);

            float testValue3 = (float)ndFloat.GetValueFromProbability(97);
            Assert.AreEqual(3.1176273, testValue3, 0.0001);
        }

        [TestMethod]
        public void ShoudlReturnCorrectConfidenceLevel_NormalDistribution_Float()
        {
            float testValue1 = (float)ndFloat.GetConfidenceInterval(1.0F);
            Assert.AreEqual(0.00999F, testValue1, 0.00001);

            float testValue2 = (float)ndFloat.GetConfidenceInterval(2.0F);
            Assert.AreEqual(0.01499F, testValue2, 0.00001);

            float testValue3 = (float)ndFloat.GetConfidenceInterval(3.0F);
            Assert.AreEqual(0.01999F, testValue3, 0.00001);
        }

        [TestMethod]
        public void ShoudlReturnCorrectZForConfidenceLevel_NormalDistribution_Float()
        {
            float testValue1 = (float)ndFloat.GetZForConfidenceLevel(1.0F);
            Assert.AreEqual(0.01999F, testValue1, 0.0001);

            float testValue2 = (float)ndFloat.GetZForConfidenceLevel(2.0F);
            Assert.AreEqual(0.02999F, testValue2, 0.00001);

            float testValue3 = (float)ndFloat.GetZForConfidenceLevel(3.0F);
            Assert.AreEqual(0.03999F, testValue3, 0.00001);
        }   
    }
}
