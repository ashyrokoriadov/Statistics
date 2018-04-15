using Microsoft.VisualStudio.TestTools.UnitTesting;
using Statistics.Implementations;

namespace StatisticsTest
{
    [TestClass]
    public class PercentileTest
    {
        private double[] arrayDoubleEven = { -6.1, 10.2, 6.3, -5.4, 6.5, 9.6, -5.4, -4.5, -3.7, -7.3 };
        private decimal[] arrayDecimalEven = { -6.1M, 10.2M, 6.3M, -5.4M, 6.5M, 9.6M, -5.4M, -4.5M, -3.7M, -7.3M };
        private float[] arrayFloatEven = { -6.1F, 10.2F, 6.3F, -5.4F, 6.5F, 9.6F, -5.4F, -4.5F, -3.7F, -7.3F };
        private int[] arrayIntEven = { -6, 10, 6, -5, 6, 9, -5, -4, -3, -7 };

        private double[] arrayDoubleOdd = { -6.1, 10.2, 6.3, -5.4, 6.5, 9.6, -5.4, -4.5, -3.7, -7.3, 5.8 };
        private decimal[] arrayDecimalOdd = { -6.1M, 10.2M, 6.3M, -5.4M, 6.5M, 9.6M, -5.4M, -4.5M, -3.7M, -7.3M, 5.8M };
        private float[] arrayFloatOdd = { -6.1F, 10.2F, 6.3F, -5.4F, 6.5F, 9.6F, -5.4F, -4.5F, -3.7F, -7.3F, 5.8F };
        private int[] arrayIntOdd = { -6, 10, 6, -5, 6, 9, -5, -4, -3, -7, 11 };

        Percentile percentileDoubleEven;
        Percentile percentileDecimalEven;
        Percentile percentileFloatEven;
        Percentile percentileIntEven;

        Percentile percentileDoubleOdd;
        Percentile percentileDecimalOdd;
        Percentile percentileFloatOdd;
        Percentile percentileIntOdd;

        Percentile percentileDoubleOddLess;
        Percentile percentileDecimalOddLess;
        Percentile percentileFloatOddLess;
        Percentile percentileIntOddLess;

        Percentile percentileDoubleOddGreater;
        Percentile percentileDecimalOddGreater;
        Percentile percentileFloatOddGreater;
        Percentile percentileIntOddGreater;

        private int KthPercentile;
        private int KthPercentileLess;
        private int KthPercentileGreater;

        [TestInitialize]
        public void TestInitialize()
        {
            KthPercentile = 50;
            KthPercentileLess = 45;
            KthPercentileGreater = 68;

            percentileDoubleEven = new Percentile(arrayDoubleEven, KthPercentile);
            percentileDecimalEven = new Percentile(arrayDecimalEven, KthPercentile);
            percentileFloatEven = new Percentile(arrayFloatEven, KthPercentile);
            percentileIntEven = new Percentile(arrayIntEven, KthPercentile);

            percentileDoubleOdd = new Percentile(arrayDoubleOdd, KthPercentile);
            percentileDecimalOdd = new Percentile(arrayDecimalOdd, KthPercentile);
            percentileFloatOdd = new Percentile(arrayFloatOdd, KthPercentile);
            percentileIntOdd = new Percentile(arrayIntOdd, KthPercentile);

            percentileDoubleOddLess = new Percentile(arrayDoubleOdd, KthPercentileLess);
            percentileDecimalOddLess = new Percentile(arrayDecimalOdd, KthPercentileLess);
            percentileFloatOddLess = new Percentile(arrayFloatOdd, KthPercentileLess);
            percentileIntOddLess = new Percentile(arrayIntOdd, KthPercentileLess);

            percentileDoubleOddGreater = new Percentile(arrayDoubleOdd, KthPercentileGreater);
            percentileDecimalOddGreater = new Percentile(arrayDecimalOdd, KthPercentileGreater);
            percentileFloatOddGreater = new Percentile(arrayFloatOdd, KthPercentileGreater);
            percentileIntOddGreater = new Percentile(arrayIntOdd, KthPercentileGreater);
        }

        [TestMethod]
        public void ShouldReturnCorrectResultForEvenQuantity_Double()
        {
            double result = (double)percentileDoubleEven.GetResult();
            Assert.AreEqual(-4.1, result);
        }

        [TestMethod]
        public void ShouldReturnCorrectResultForOddQuantity_Double()
        {
            double result = (double)percentileDoubleOdd.GetResult();
            Assert.AreEqual(5.8, result);
        }

        [TestMethod]
        public void ShouldReturnCorrectResultForOddQuantityLess_Double()
        {
            double result = (double)percentileDoubleOddLess.GetResult();
            Assert.AreEqual(-3.7, result);
        }

        [TestMethod]
        public void ShouldReturnCorrectResultForOddQuantityGreater_Double()
        {
            double result = (double)percentileDoubleOddGreater.GetResult();
            Assert.AreEqual(6.5, result);
        }

        [TestMethod]
        public void ShouldReturnCorrectResultForEvenQuantity_Decimal()
        {
            decimal result = (decimal)percentileDecimalEven.GetResult();
            Assert.AreEqual(-4.1M, result);
        }

        [TestMethod]
        public void ShouldReturnCorrectResultForOddQuantity_Decimal()
        {
            decimal result = (decimal)percentileDecimalOdd.GetResult();
            Assert.AreEqual(5.8M, result);
        }

        [TestMethod]
        public void ShouldReturnCorrectResultForOddQuantityLess_Decimal()
        {
            decimal result = (decimal)percentileDecimalOddLess.GetResult();
            Assert.AreEqual(-3.7M, result);
        }

        [TestMethod]
        public void ShouldReturnCorrectResultForOddQuantityGreater_Decimal()
        {
            decimal result = (decimal)percentileDecimalOddGreater.GetResult();
            Assert.AreEqual(6.5M, result);
        }

        [TestMethod]
        public void ShouldReturnCorrectResultForEvenQuantity_Float()
        {
            float result = (float)percentileFloatEven.GetResult();
            Assert.AreEqual(-4.1F, result);
        }

        [TestMethod]
        public void ShouldReturnCorrectResultForOddQuantity_Float()
        {
            float result = (float)percentileFloatOdd.GetResult();
            Assert.AreEqual(5.8F, result);
        }

        [TestMethod]
        public void ShouldReturnCorrectResultForOddQuantityLess_Float()
        {
            float result = (float)percentileFloatOddLess.GetResult();
            Assert.AreEqual(-3.7F, result);
        }

        [TestMethod]
        public void ShouldReturnCorrectResultForOddQuantityGreater_Float()
        {
            float result = (float)percentileFloatOddGreater.GetResult();
            Assert.AreEqual(6.5F, result);
        }

        [TestMethod]
        public void ShouldReturnCorrectResultForEvenQuantity_Int()
        {
            double result = (double)percentileIntEven.GetResult();
            Assert.AreEqual(-3.5, result);
        }

        [TestMethod]
        public void ShouldReturnCorrectResultForOddQuantity_Int()
        {
            int result = (int)percentileIntOdd.GetResult();
            Assert.AreEqual(-3, result);
        }

        [TestMethod]
        public void ShouldReturnCorrectResultForOddQuantityLess_Int()
        {
            int result = (int)percentileIntOddLess.GetResult();
            Assert.AreEqual(-4, result);
        }

        [TestMethod]
        public void ShouldReturnCorrectResultForOddQuantityGreater_Int()
        {
            int result = (int)percentileIntOddGreater.GetResult();
            Assert.AreEqual(6, result);
        }

        [TestMethod]
        public void ShouldRecreateCalcualtionObjectWhenKNumberChanges_Double()
        {
            Percentile percentile = new Percentile(arrayDoubleEven, KthPercentile);
            percentile.KthPercentile = KthPercentileGreater;
            double result = (double)percentile.GetResult();
            Assert.AreEqual(6.4, result);
        }

        [TestMethod]
        public void ShouldRecreateCalcualtionObjectWhenKNumberChanges_Decimal()
        {
            Percentile percentile = new Percentile(arrayDecimalEven, KthPercentile);
            percentile.KthPercentile = KthPercentileGreater;
            decimal result = (decimal)percentile.GetResult();
            Assert.AreEqual(6.4M, result);
        }

        [TestMethod]
        public void ShouldRecreateCalcualtionObjectWhenKNumberChanges_Float()
        {
            Percentile percentile = new Percentile(arrayFloatEven, KthPercentile);
            percentile.KthPercentile = KthPercentileGreater;
            float result = (float)percentile.GetResult();
            Assert.AreEqual(6.4F, result);
        }

        [TestMethod]
        public void ShouldRecreateCalcualtionObjectWhenKNumberChanges_Int()
        {
            Percentile percentile = new Percentile(arrayIntEven, KthPercentile);
            percentile.KthPercentile = KthPercentileGreater;
            double result = (double)percentile.GetResult();
            Assert.AreEqual(6.0, result);
        }

    }
}
