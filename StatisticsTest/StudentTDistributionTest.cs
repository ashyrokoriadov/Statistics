using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Statistics.Implementations;

namespace StatisticsTest
{
    [TestClass]
    public class StudentTDistributionTest
    {
        double tDouble = 1.745884;
        double[] arrayDouble1 = new double[] {30, 45, 41, 38, 34, 36, 31, 30, 49, 50, 51, 46, 41, 37, 36, 34, 33, 49,
            32, 46, 41, 44, 38, 50, 37, 39, 40, 46, 42};
        double[] arrayDouble2 = new double[] {46, 49, 52, 55, 56, 40, 47, 51, 58, 46, 46, 56, 53, 57, 44, 42, 40, 58,
            54, 53, 51, 57, 56, 44, 42, 49, 50, 55, 43};

        float tFloat = 1.745884F;
        decimal tDecimal = 1.745884M;
        int n = 16;

        StudentTDistribution tDistributionDouble;
        StudentTDistribution tDistributionFloat;
        StudentTDistribution tDistributionDecimal;

        [TestInitialize]
        public void TestInitialize()
        {
            tDistributionDouble = new StudentTDistribution(n, tDouble);
            tDistributionFloat = new StudentTDistribution(n, tFloat);
            tDistributionDecimal = new StudentTDistribution(n, tDecimal);
        }

        [TestMethod]
        public void ShouldReturnCorrectValueForMean_Double()
        {
            Assert.AreEqual(0, Convert.ToDouble(tDistributionDouble.GetMean()));
        }

        [TestMethod]
        public void ShouldReturnCorrectValueForVariance_Double()
        {
            Assert.AreEqual(1.143, Math.Round(Convert.ToDouble(tDistributionDouble.GetVariance()), 3));
        }

        [TestMethod]
        public void ShouldReturnCorrectValueForStandardDeviation_Double()
        {
            Assert.AreEqual(1.069, Math.Round(Convert.ToDouble(tDistributionDouble.GetStandardDeviation()), 3));
        }

        [TestMethod]
        public void ShouldReturnCorrectValueForProbability_Double()
        {
            Assert.AreEqual(0.05, Convert.ToDouble(tDistributionDouble.GetProbability()), 0.001);
        }

        [TestMethod]
        public void ShouldReturnCorrectValueForProbabilityDensity_Double()
        {
            Assert.AreEqual(0.08921, Convert.ToDouble(tDistributionDouble.GetProbabilityDensity()), 0.005);
        }

        [TestMethod]
        public void ShouldReturnCorrectValueForConfidenceInterval_Double()
        {
            Assert.AreEqual(4.8125, Convert.ToDouble(tDistributionDouble.GetConfidenceInterval(90, 11)), 0.001);
        }

        [TestMethod]
        public void ShouldReturnCorrectValueForConfidenceInterval_StaticDouble()
        {
            Assert.AreEqual(2.65, Convert.ToDouble(StudentTDistribution.GetConfidenceInterval(95, 5, 16)), 0.001);
        }

        [TestMethod]
        public void ShouldReturnCorrectValueForTParameter_Double()
        {
            Assert.AreEqual(1.34, Convert.ToDouble(tDistributionDouble.GetTParameter(80)), 0.001);
        }

        [TestMethod]
        public void ShouldReturnCorrectValueForTParameter_StaticDouble()
        {
            Assert.AreEqual(2.55, Convert.ToDouble(StudentTDistribution.GetTParameter(98, 18)), 0.001);
        }

        [TestMethod]
        public void ShouldReturnCorrectValueForTTestValue_StaticDouble()
        {
            Assert.AreEqual(6.0972, Convert.ToDouble(StudentTDistribution.GetTTestValue(arrayDouble1, arrayDouble2)), 0.001);
        }

        [TestMethod]
        public void ShouldReturnCorrectValueForMean_Float()
        {
            Assert.AreEqual(0, Convert.ToSingle(tDistributionFloat.GetMean()));
        }

        [TestMethod]
        public void ShouldReturnCorrectValueForVariance_Float()
        {
            Assert.AreEqual(1.143, Math.Round(Convert.ToDouble(tDistributionFloat.GetVariance()), 3));
        }

        [TestMethod]
        public void ShouldReturnCorrectValueForStandardDeviation_Float()
        {
            Assert.AreEqual(1.069, Math.Round(Convert.ToDouble(tDistributionFloat.GetStandardDeviation()), 3));
        }

        [TestMethod]
        public void ShouldReturnCorrectValueForProbability_Float()
        {
            Assert.AreEqual(0.05F, Convert.ToSingle(tDistributionFloat.GetProbability()), 0.001);
        }

        [TestMethod]
        public void ShouldReturnCorrectValueForProbabilityDensity_Float()
        {
            Assert.AreEqual(0.08921F, Convert.ToSingle(tDistributionFloat.GetProbabilityDensity()), 0.005);
        }

        [TestMethod]
        public void ShouldReturnCorrectValueForConfidenceInterval_Float()
        {
            Assert.AreEqual(4.8125F, Convert.ToSingle(tDistributionFloat.GetConfidenceInterval(90, 11)), 0.001);
        }

        [TestMethod]
        public void ShouldReturnCorrectValueForConfidenceInterval_StaticFloat()
        {
            Assert.AreEqual(2.65F, Convert.ToSingle(StudentTDistribution.GetConfidenceInterval(95, 5, 16)), 0.001);
        }

        [TestMethod]
        public void ShouldReturnCorrectValueForTParameter_Float()
        {
            Assert.AreEqual(1.34F, Convert.ToSingle(tDistributionFloat.GetTParameter(80)), 0.001);
        }

        [TestMethod]
        public void ShouldReturnCorrectValueForTParameter_StaticFloat()
        {
            Assert.AreEqual(2.55F, Convert.ToSingle(StudentTDistribution.GetTParameter(98, 18)), 0.001);
        }

        [TestMethod]
        public void ShouldReturnCorrectValueForTTestValue_StaticFloat()
        {
            Assert.AreEqual(6.0972F, Convert.ToSingle(StudentTDistribution.GetTTestValue(arrayDouble1, arrayDouble2)), 0.001);
        }

        [TestMethod]
        public void ShouldReturnCorrectValueForMean_Decimal()
        {
            Assert.AreEqual(0M, Convert.ToDecimal(tDistributionDecimal.GetMean()));
        }

        [TestMethod]
        public void ShouldReturnCorrectValueForVariance_Decimal()
        {
            Assert.AreEqual(1.143, Math.Round(Convert.ToDouble(tDistributionDecimal.GetVariance()), 3));
        }

        [TestMethod]
        public void ShouldReturnCorrectValueForStandardDeviation_Decimal()
        {
            Assert.AreEqual(1.069, Math.Round(Convert.ToDouble(tDistributionDecimal.GetStandardDeviation()), 3));
        }

        [TestMethod]
        public void ShouldReturnCorrectValueForProbability_Decimal()
        {
            Assert.AreEqual(0.0502256189509096136936996667M, Convert.ToDecimal(tDistributionDecimal.GetProbability()));
        }

        [TestMethod]
        public void ShouldReturnCorrectValueForProbabilityDensity_Decimal()
        {
            Assert.AreEqual(0.0896044472857907761278004975M, Convert.ToDecimal(tDistributionDecimal.GetProbabilityDensity()));
        }

        [TestMethod]
        public void ShouldReturnCorrectValueForConfidenceInterval_Decimal()
        {
            Assert.AreEqual(4.8125M, Convert.ToDecimal(tDistributionDecimal.GetConfidenceInterval(90, 11)));
        }

        [TestMethod]
        public void ShouldReturnCorrectValueForConfidenceInterval_StaticDecimal()
        {
            Assert.AreEqual(2.65M, Convert.ToDecimal(StudentTDistribution.GetConfidenceInterval(95, 5, 16)));
        }

        [TestMethod]
        public void ShouldReturnCorrectValueForTParameter_Decimal()
        {
            Assert.AreEqual(1.34M, Convert.ToDecimal(tDistributionDecimal.GetTParameter(80)));
        }

        [TestMethod]
        public void ShouldReturnCorrectValueForTParameter_StaticDecimal()
        {
            Assert.AreEqual(2.54999999999999M, Convert.ToDecimal(StudentTDistribution.GetTParameter(98, 18)));
        }

        [TestMethod]
        public void ShouldReturnCorrectValueForTTestValue_StaticDecimal()
        {
            Assert.AreEqual(6.09721295301628M, Convert.ToDecimal(StudentTDistribution.GetTTestValue(arrayDouble1, arrayDouble2)));
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void ShouldThrowAnEceptioWhenNIsLessThanZero()
        {
            StudentTDistribution testObject = new StudentTDistribution(-1, tDouble);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void ShouldThrowAnEceptioWhenNIsEqualZero()
        {
            StudentTDistribution testObject = new StudentTDistribution(0, tDouble);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void ShouldThrowAnEceptioWhenNIsFreaerThanThirty()
        {
            StudentTDistribution testObject = new StudentTDistribution(31, tDouble);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void ShouldThrowAnEceptioWhenTypeIsNotSupported()
        {
            StudentTDistribution testObject = new StudentTDistribution(31, string.Empty);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void ShouldThrowAnEceptioWhenNIsOneForMeanCalculation()
        {
            StudentTDistribution testObject = new StudentTDistribution(1, tDouble);
            testObject.GetMean();
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void ShouldThrowAnEceptioWhenTypeNIsTwoForStandardDeviationCalculation()
        {
            StudentTDistribution testObject = new StudentTDistribution(2, tDouble);
            testObject.GetStandardDeviation();
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void ShouldThrowAnEceptioWhenTypeNIsTwoForVarianceCalculation()
        {
            StudentTDistribution testObject = new StudentTDistribution(2, tDouble);
            testObject.GetVariance();
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void ShouldThrowAnEceptioWhenWhenConfidenceLevelIsLessThanEigthy()
        {
            StudentTDistribution testObject = new StudentTDistribution(25, tDouble);
            testObject.GetTParameter(79.99);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void ShouldThrowAnEceptioWhenWhenConfidenceLevelIsLessGreaterNightyNine()
        {
            StudentTDistribution testObject = new StudentTDistribution(25, tDouble);
            testObject.GetTParameter(99.01);
        }
    }
}
