using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Statistics.Implementations;

namespace StatisticsTest
{
    [TestClass]
    public class CorrelationTest
    {
        double[] arrayDouble1 = new double[] {18, 20, 21, 23, 27, 30, 34, 39};
        double[] arrayDouble2 = new double[] {14.4, 15.6, 16.1, 17.2, 19.4, 21.1, 23.3, 26.1};
        float[] arrayFloat1 = new float[] { 18F, 20F, 21F, 23F, 27F, 30F, 34F, 39F };
        float[] arrayFloat2 = new float[] { 14.4F, 15.6F, 16.1F, 17.2F, 19.4F, 21.1F, 23.3F, 26.1F };
        decimal[] arrayDecimal1 = new decimal[] { 18M, 20M, 21M, 23M, 27M, 30M, 34M, 39M };
        decimal[] arrayDecimal2 = new decimal[] { 14.4M, 15.6M, 16.1M, 17.2M, 19.4M, 21.1M, 23.3M, 26.1M };

        Correlation correlationDouble;
        Correlation correlationFloat;
        Correlation correlationDecimal;

        [TestInitialize]
        public void TestInitialize()
        {
            correlationDouble = new Correlation(arrayDouble1, arrayDouble2);
            correlationFloat = new Correlation(arrayFloat1, arrayFloat2);
            correlationDecimal = new Correlation(arrayDecimal1, arrayDecimal2);
        }

        [TestMethod]
        public void ShouldReturnCorrctValueForCorellationRatio_Double()
        {
            Assert.AreEqual(1, (double)correlationDouble.GetCorrelaionRatio(), 0.0001);
        }

        [TestMethod]
        public void ShouldReturnCorrctValueForStatisticalFive_Double()
        {
            object mean1, mean2, sigma1, sigma2, r;
            correlationDouble.GetGreatFive(out mean1, out mean2, out sigma1, out sigma2, out r);
            Assert.AreEqual(26.5, (double)mean1);
            Assert.AreEqual(19.15, (double)mean2);
            Assert.AreEqual(7.38724769934165, (double)sigma1, 0.0001);
            Assert.AreEqual(4.0998257802706, (double)sigma2, 0.0001);
            Assert.AreEqual(1, (double)r, 0.0001);
        }

        [TestMethod]
        public void ShouldReturnCorrctValueForCorellationRatio_Float()
        {
            Assert.AreEqual(1, (float)correlationFloat.GetCorrelaionRatio(), 0.0001);
        }

        [TestMethod]
        public void ShouldReturnCorrctValueForStatisticalFive_Float()
        {
            object mean1, mean2, sigma1, sigma2, r;
            correlationFloat.GetGreatFive(out mean1, out mean2, out sigma1, out sigma2, out r);
            Assert.AreEqual(26.5F, (float)mean1);
            Assert.AreEqual(19.15F, (float)mean2);
            Assert.AreEqual(7.38724769934165F, (float)sigma1, 0.0001);
            Assert.AreEqual(4.0998257802706F, (float)sigma2, 0.0001);
            Assert.AreEqual(1F, (float)r, 0.0001);
        }

        [TestMethod]
        public void ShouldReturnCorrctValueForCorellationRatio_Decimal()
        {
            Assert.AreEqual(0.999976415928678969759657258M, (decimal)correlationDecimal.GetCorrelaionRatio());
        }

        [TestMethod]
        public void ShouldReturnCorrctValueForStatisticalFive_Decimal()
        {
            object mean1, mean2, sigma1, sigma2, r;
            correlationDecimal.GetGreatFive(out mean1, out mean2, out sigma1, out sigma2, out r);
            Assert.AreEqual(26.5M, (decimal)mean1);
            Assert.AreEqual(19.15M, (decimal)mean2);
            Assert.AreEqual(7.38724769934165M, (decimal)sigma1);
            Assert.AreEqual(4.0998257802706M, (decimal)sigma2);
            Assert.AreEqual(0.999976415928678969759657258M, (decimal)r);
        }
    }
}
