using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Statistics.Implementations;
using StatisticsTest.BaseClasses;

namespace StatisticsTests
{
    [TestClass]
    public class ArithmeticMeanTest : StatisticData
    {
        [TestInitialize]
        public void Initialize()
        {
           TestInitialize();
        }

        [TestMethod]
        public void ShouldReturnCorrectResultForDoubleArray_Mean()
        {
            double testMean = (double)amDouble.GetResult();
            Assert.AreEqual(7.94, Math.Round(testMean,2));
        }

        [TestMethod]
        public void ShouldReturnCorrectResultForFloatArray_Mean()
        {
            float testMean = (float)amFloat.GetResult();
            Assert.AreEqual(7.94, Math.Round(testMean, 2));
        }

        [TestMethod]
        public void ShouldReturnCorrectResultForDecimalArray_Mean()
        {
            decimal testMean = (decimal)amDecimal.GetResult();
            Assert.AreEqual(7.94M, Math.Round(testMean, 2));
        }

        [TestMethod]
        public void ShouldReturnCorrectResultForIntArray_Mean()
        {
            double testMean = (double)amInt.GetResult();
            Assert.AreEqual(7.6, testMean);
        }

        [TestMethod]
        public void ShouldReturnCorrectResultofDoubleTypeForIntArray_Mean()
        {
            double testMean = (double)amInt.GetResult();
            Assert.AreEqual(7.6, Math.Round(testMean,2));
        }

        [TestMethod]
        public void ShouldReturnCorrectResultForDoubleList_Mean()
        {
            double testMean = (double)amDoubleList.GetResult();
            Assert.AreEqual(7.94, Math.Round(testMean, 2));
        }

        [TestMethod]
        public void ShouldReturnCorrectResultForFloatList_Mean()
        {
            float testMean = (float)amFloatList.GetResult();
            Assert.AreEqual(7.94, Math.Round(testMean, 2));
        }

        [TestMethod]
        public void ShouldReturnCorrectResultForDecimalList_Mean()
        {
            decimal testMean = (decimal)amDecimalList.GetResult();
            Assert.AreEqual(7.94M, Math.Round(testMean, 2));
        }

        [TestMethod]
        public void ShouldReturnCorrectResultForIntList_Mean()
        {
            double testMean = (double)amIntList.GetResult();
            Assert.AreEqual(7.6, testMean);
        }

        [TestMethod]
        public void ShouldReturnCorrectResultofDoubleTypeForIntList_Mean()
        {
            double testMean = (double)amIntList.GetResult();
            Assert.AreEqual(7.6, Math.Round(testMean, 2));
        }
    }
}
