using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Statistics.Implementations;
using StatisticsTest.BaseClasses;

namespace StatisticsTest
{
    [TestClass]
    public class StandardDeviationTest : StatisticData
    {
        [TestInitialize]
        public void Initialize()
        {
            TestInitialize();
        }

        [TestMethod]
        public void ShouldReturnCorrectValueOfStandardDeviationDouble()
        {
            double testSD = (double)sdDouble.GetResult();
            Assert.AreEqual(4.464, Math.Round(testSD, 3));
        }

        [TestMethod]
        public void ShouldReturnCorrectValueOfSampleVarianceDouble()
        {
            double testSV = (double)sdDouble.GetSampleVariance();
            Assert.AreEqual(19.928, Math.Round(testSV, 3));
        }

        [TestMethod]
        public void ShouldReturnCorrectValueOfStandardDeviationInt()
        {
            double testSD = (double)sdInt.GetResult();
            Assert.AreEqual(4.393, Math.Round(testSD, 3));
        }

        [TestMethod]
        public void ShouldReturnCorrectValueOfSampleVarianceInt()
        {
            double testSV = (double)sdInt.GetSampleVariance();
            Assert.AreEqual(19.300, Math.Round(testSV, 3));
        }

        [TestMethod]
        public void ShouldReturnCorrectValueOfStandardDeviationFloat()
        {
            float testSD = (float)sdFloat.GetResult();
            Assert.AreEqual(4.464, Math.Round(testSD, 3));
        }

        [TestMethod]
        public void ShouldReturnCorrectValueOfSampleVarianceFloat()
        {
            float testSV = (float)sdFloat.GetSampleVariance();
            Assert.AreEqual(19.928, Math.Round(testSV, 3));
        }

        [TestMethod]
        public void ShouldReturnCorrectValueOfStandardDeviationDecimal()
        {
            decimal testSD = (decimal)sdDecimal.GetResult();
            Assert.AreEqual(4.464, (double)Math.Round(testSD, 3));
        }

        [TestMethod]
        public void ShouldReturnCorrectValueOfSampleVarianceDecimal()
        {
            decimal testSV = (decimal)sdDecimal.GetSampleVariance();
            Assert.AreEqual(19.928, (double)Math.Round(testSV, 3));
        }        
    }
}
