using System;
using System.Linq;

namespace Statistics.Implementations
{
    class ArithmeticMeanDecimal : CalculationArithmeticMean
    {
        public ArithmeticMeanDecimal(decimal[] array)
        {
            dataArray = array;
        }

        decimal[] dataArray;

        public override object GetResult()
        {
            return GetSum(dataArray) / dataArray.Length;
        }

        public override object GetMeanCondition()
        {
            decimal[] newArray = (decimal[])GetArrayCondition();
            return GetSum(newArray) / newArray.Length;
        }

        public override object GetArrayCondition()
        {
            if (method == null)
                throw new NullReferenceException("Filtering method is not set.");

            return dataArray.Where(n => method(n)).ToArray();
        }

        public override object GetArrayConditions()
        {
            if (methodArray == null)
                throw new NullReferenceException("Filtering method's colletion is null.");

            decimal[] result = dataArray;

            foreach (Func<object, bool> method in methodArray)
            {
                result = result.Where(n => method(n)).ToArray();
            }

            return result;
        }

        public override object GetMeanConditions()
        {
            decimal[] newArray = (decimal[])GetArrayConditions();
            return GetSum(newArray) / newArray.Length;
        }
    }
}
