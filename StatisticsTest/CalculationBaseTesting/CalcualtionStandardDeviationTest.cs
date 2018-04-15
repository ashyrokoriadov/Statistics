using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Statistics.Implementations;
using StatisticsTest.BaseClasses;

namespace StatisticsTest.CalculationBaseTesting 
{
    [TestClass]
    public class CalcualtionStandardDeviationTest : StatisticDataCalcualtionTesting
    {
        [TestInitialize]
        public void Initialize()
        {
            TestInitialize();
        }

        [TestMethod]
        public void ShouldReturnCorrectValueForMean_Double()
        {
            double mean = (double)sdDouble.GetMean();
            Assert.AreEqual(4.19, Math.Round(mean, 2));
        }

        [TestMethod]
        public void ShouldReturnCorrectValueForMean_Float()
        {
            float mean = (float)sdFloat.GetMean();
            Assert.AreEqual(4.19, Math.Round(mean, 2));
        }

        [TestMethod]
        public void ShouldReturnCorrectValueForMean_Decimal()
        {
            decimal mean = (decimal)sdDecimal.GetMean();
            Assert.AreEqual(4.19M, Math.Round(mean, 2));
        }

        [TestMethod]
        public void ShouldReturnCorrectValueForMean_Int()
        {
            double mean = (double)sdInt.GetMean();
            Assert.AreEqual(4, mean);
        }
    }
}
