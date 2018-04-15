using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Statistics.Implementations;
using StatisticsTest.BaseClasses;

namespace StatisticsTest.CalculationBaseTesting
{
    [TestClass]
    public class CalcualtionArithmeticMeanTest : StatisticDataCalcualtionTesting
    {
        [TestInitialize]
        public void Initialize()
        {
            TestInitialize();
        }

        [TestMethod]
        public void FilteredDecimalArrayShouldBeEqualToCertainValue_OneFilter()
        {
            object result = amDecimal.GetArrayCondition(FilterValues1);
            object expectedResult = new[] { 3.75M, 4M, 5.25M, 6M, 7.25M, 8M };
            CollectionAssert.AreEqual((decimal[])expectedResult, (decimal[])result);
        }

        [TestMethod]
        public void FilteredDecimalArrayShouldBeEqualToCertainValue_TwoFilters()
        {
            object result = amDecimal.GetArrayConditions(filteringMethods);
            object expectedResult = new[] { 3.75M, 4M, 5.25M, 6M };
            CollectionAssert.AreEqual((decimal[])expectedResult, (decimal[])result);
        }

        [TestMethod]
        public void FilteredIntArrayShouldBeEqualToCertainValue_OneFilter()
        {
            object result = amInt.GetArrayCondition(FilterValues1);
            object expectedResult = new[] { 4, 5, 6, 7, 8 };
            CollectionAssert.AreEqual((int[])expectedResult, (int[])result);
        }

        [TestMethod]
        public void FilteredIntArrayShouldBeEqualToCertainValue_TwoFilters()
        {
            object result = amInt.GetArrayConditions(filteringMethods);
            object expectedResult = new[] { 4, 5, 6 };
            CollectionAssert.AreEqual((int[])expectedResult, (int[])result);
        }

        [TestMethod]
        public void FilteredDoubleArrayShouldBeEqualToCertainValue_OneFilter()
        {
            object result = amDouble.GetArrayCondition(FilterValues1);
            object expectedResult = new[] { 3.75, 4, 5.25, 6, 7.25, 8 };
            CollectionAssert.AreEqual((double[])expectedResult, (double[])result);
        }

        [TestMethod]
        public void FilteredDoubleArrayShouldBeEqualToCertainValue_TwoFilters()
        {
            object result = amDouble.GetArrayConditions(filteringMethods);
            object expectedResult = new[] { 3.75, 4, 5.25, 6 };
            CollectionAssert.AreEqual((double[])expectedResult, (double[])result);
        }

        [TestMethod]
        public void FilteredFloatArrayShouldBeEqualToCertainValue_OneFilter()
        {
            object result = amFloat.GetArrayCondition(FilterValues1);
            object expectedResult = new[] { 3.75F, 4F, 5.25F, 6F, 7.25F, 8F };
            CollectionAssert.AreEqual((float[])expectedResult, (float[])result);
        }

        [TestMethod]
        public void FilteredFloatArrayShouldBeEqualToCertainValue_TwoFilters()
        {
            object result = amFloat.GetArrayConditions(filteringMethods);
            object expectedResult = new[] { 3.75F, 4F, 5.25F, 6F };
            CollectionAssert.AreEqual((float[])expectedResult, (float[])result);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void ShouldThrowAnException_Float_FilteringPredicateIsNull()
        {
            Func<object, bool> predicate = null;
            object result = amFloat.GetArrayCondition(predicate);            
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void ShouldThrowAnException_Double_FilteringPredicateIsNull()
        {
            Func<object, bool> predicate = null;
            object result = amDouble.GetArrayCondition(predicate);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void ShouldThrowAnException_Decimal_FilteringPredicateIsNull()
        {
            Func<object, bool> predicate = null;
            object result = amDecimal.GetArrayCondition(predicate);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void ShouldThrowAnException_Int_FilteringPredicateIsNull()
        {
            Func<object, bool> predicate = null;
            object result = amInt.GetArrayCondition(predicate);
        }

        public void ShouldThrowAnException_Float_FilteringPredicateCollectionIsNull()
        {
            Func<object, bool>[] predicate = null;
            object result = amFloat.GetArrayConditions(predicate);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void ShouldThrowAnException_Double_FilteringPredicateCollectionIsNull()
        {
            Func<object, bool>[] predicate = null;
            object result = amDouble.GetArrayConditions(predicate);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void ShouldThrowAnException_Decimal_FilteringPredicateCollectionIsNull()
        {
            Func<object, bool>[] predicate = null;
            object result = amDecimal.GetArrayConditions(predicate);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void ShouldThrowAnException_Int_FilteringPredicateCollectionIsNull()
        {
            Func<object, bool>[] predicate = null;
            object result = amInt.GetArrayConditions(predicate);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void ShouldThrowAnException_DataTypeNotSupported()
        {
            ArithmeticMean am = new ArithmeticMean(incorrectDataFormat);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void ShouldThrowAnException_NullArgument()
        {            
            ArithmeticMean am = new ArithmeticMean(nullData);
        }
    }
}
