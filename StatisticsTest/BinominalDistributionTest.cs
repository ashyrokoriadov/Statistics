using System;
using Statistics.Implementations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StatisticsTest
{
    [TestClass]
    public class BinominalDistributionTest
    {
        int n;
        int x;
        decimal pDecimal;
        float pFloat;
        double pDouble;

        BinominalDistribution bdDouble;
        BinominalDistribution bdFloat;
        BinominalDistribution bdDecimal;

        [TestInitialize]
        public void TestInitialize()
        {
            n = 3;
            x = 1;
            pDecimal = 0.3M;
            pFloat = 0.3F;
            pDouble = 0.3;

            bdDouble = new BinominalDistribution(n, x, pDouble);
            bdFloat = new BinominalDistribution(n, x, pFloat);
            bdDecimal = new BinominalDistribution(n, x, pDecimal);
        }

        [TestMethod]
        public void ShouldReturnCorrectCombinationNumber_Binominal_Double()
        {
            Assert.AreEqual(3, (double)bdDouble.GetCombinationNumber());            
        }

        public void ShouldReturnCorrectProbability_Binominal_Double()
        {
            Assert.AreEqual(0.441, (double)bdDouble.GetProbability());
        }

        public void ShouldReturnCorrectMean_Binominal_Double()
        {
            Assert.AreEqual(0.9, Math.Round((double)bdDouble.GetMean(), 1));
        }

        public void ShouldReturnCorrectStandardDeviation_Binominal_Double()
        {
            Assert.AreEqual(0.79, Math.Round((double)bdDouble.GetStandardDeviation(), 2));
        }

        public void ShouldReturnCorrectSampleVariance_Binominal_Double()
        {
            Assert.AreEqual(0.63, Math.Round((double)bdDouble.GetVariance(), 2));
        }

        [TestMethod]
        public void ShouldReturnCorrectCombinationNumber_Binominal_Float()
        {
            Assert.AreEqual(3F, (float)bdFloat.GetCombinationNumber());
        }

        public void ShouldReturnCorrectProbability_Binominal_Float()
        {
            Assert.AreEqual(0.441F, (float)bdFloat.GetProbability());
        }

        public void ShouldReturnCorrectMean_Binominal_Float()
        {
            Assert.AreEqual(0.9F, Math.Round((float)bdFloat.GetMean(), 1));
        }

        public void ShouldReturnCorrectStandardDeviation_Binominal_Float()
        {
            Assert.AreEqual(0.79F, Math.Round((float)bdFloat.GetStandardDeviation(), 2));
        }

        public void ShouldReturnCorrectSampleVariance_Binominal_Float()
        {
            Assert.AreEqual(0.63F, Math.Round((float)bdFloat.GetVariance(), 2));
        }

        [TestMethod]
        public void ShouldReturnCorrectCombinationNumber_Binominal_Decimal()
        {
            Assert.AreEqual(3M, (decimal)bdDecimal.GetCombinationNumber());
        }

        public void ShouldReturnCorrectProbability_Binominal_Decimal()
        {
            Assert.AreEqual(0.441M, (decimal)bdDecimal.GetProbability());
        }

        public void ShouldReturnCorrectMean_Binominal_Decimal()
        {
            Assert.AreEqual(0.9M, Math.Round((decimal)bdDecimal.GetMean(), 1));
        }

        public void ShouldReturnCorrectStandardDeviation_Binominal_Decimal()
        {
            Assert.AreEqual(0.79M, Math.Round((decimal)bdDecimal.GetStandardDeviation(), 2));
        }

        public void ShouldReturnCorrectSampleVariance_Binominal_Decimal()
        {
            Assert.AreEqual(0.63M, Math.Round((decimal)bdDecimal.GetVariance(), 2));
        }        
    }
}
