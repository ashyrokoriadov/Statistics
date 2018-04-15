using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Statistics.Implementations;

namespace StatisticsTest.BaseClasses
{
    public abstract class StatisticData
    {
        protected decimal[] decimalArray = new[] { 1.2M, 8.4M, 6.3M, 11.8M, 12M };  
        protected int[] intArray = new[] { 1, 8, 6, 11, 12 };
        protected double[] doublelArray = new[] { 1.2, 8.4, 6.3, 11.8, 12 };
        protected float[] floatArray = new[] { 1.2F, 8.4F, 6.3F, 11.8F, 12F }; 

        protected ArithmeticMean amDecimal;
        protected ArithmeticMean amInt;
        protected ArithmeticMean amDouble;
        protected ArithmeticMean amFloat;

        protected ArithmeticMean amDecimalList;
        protected ArithmeticMean amIntList;
        protected ArithmeticMean amDoubleList;
        protected ArithmeticMean amFloatList;

        protected StandardDeviation sdDecimal;
        protected StandardDeviation sdInt;
        protected StandardDeviation sdDouble;
        protected StandardDeviation sdFloat;

        protected List<decimal> decimalList;
        protected List<int> intList;
        protected List<double> doubleList;
        protected List<float> floatList;

        protected void TestInitialize()
        {
            amDecimal = new ArithmeticMean(decimalArray);
            amInt = new ArithmeticMean(intArray);
            amDouble = new ArithmeticMean(doublelArray);
            amFloat = new ArithmeticMean(floatArray);

            sdDecimal = new StandardDeviation(decimalArray);
            sdInt = new StandardDeviation(intArray);
            sdDouble = new StandardDeviation(doublelArray);
            sdFloat = new StandardDeviation(floatArray);

            InitializeLists();

            amDecimalList = new ArithmeticMean(decimalList.ToArray());
            amIntList = new ArithmeticMean(intList.ToArray());
            amDoubleList = new ArithmeticMean(doubleList.ToArray());
            amFloatList = new ArithmeticMean(floatList.ToArray());
        }

        protected virtual void InitializeLists()
        {
            decimalList = new List<decimal>(new[] { 1.2M, 8.4M, 6.3M, 11.8M, 12M });
            intList = new List<int>(new[] { 1, 8, 6, 11, 12 });
            doubleList = new List<double>(new[] { 1.2, 8.4, 6.3, 11.8, 12 });
            floatList = new List<float>(new[] { 1.2F, 8.4F, 6.3F, 11.8F, 12F });
        }
    }
}
