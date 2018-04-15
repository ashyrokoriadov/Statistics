using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Statistics.Implementations;

namespace StatisticsTest.BaseClasses
{
    public abstract class StatisticDataCalcualtionTesting
    {
        protected decimal[] decimalArray = new[] { 0M, 1.5M, 2M, 3.75M, 4M, 5.25M, 6M, 7.25M, 8M };
        protected int[] intArray = new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8 };
        protected double[] doublelArray = new[] { 0, 1.5, 2, 3.75, 4, 5.25, 6, 7.25, 8 };
        protected float[] floatArray = new[] { 0F, 1.5F, 2F, 3.75F, 4F, 5.25F, 6F, 7.25F, 8F };

        protected ArithmeticMean amDecimal;
        protected ArithmeticMean amInt;
        protected ArithmeticMean amDouble;
        protected ArithmeticMean amFloat;

        protected StandardDeviation sdDecimal;
        protected StandardDeviation sdInt;
        protected StandardDeviation sdDouble;
        protected StandardDeviation sdFloat;

        protected Func<object, bool>[] filteringMethods;

        protected string incorrectDataFormat = "Some string";
        protected object nullData = null;

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

            filteringMethods = new Func<object, bool>[] { FilterValues1, FilterValues2 };
        }


        protected bool FilterValues1(object value)
        {
            if (value is decimal)
                return (decimal)value > 3M ? true : false;

            if (value is int)
                return (int)value > 3 ? true : false;

            if (value is double)
                return (double)value > 3.0 ? true : false;

            if (value is float)
                return (float)value > 3F ? true : false;

            if (value == null)
                throw new NullReferenceException("Value is null.");

            throw new Exception("Data type is not supported.");
        }

        protected bool FilterValues2(object value)
        {
            if (value is decimal)
                return (decimal)value < 7M ? true : false;

            if (value is int)
                return (int)value < 7 ? true : false;

            if (value is double)
                return (double)value < 7.0 ? true : false;

            if (value is float)
                return (float)value < 7F ? true : false;

            if (value == null)
                throw new NullReferenceException("Value is null.");

            throw new Exception("Data type is not supported");
        }
    }
}
