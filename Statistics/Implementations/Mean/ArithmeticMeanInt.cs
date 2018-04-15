using System;
using System.Linq;

namespace Statistics.Implementations
{
    class ArithmeticMeanInt : CalculationArithmeticMean
    {
        public ArithmeticMeanInt(int[] array)
        {
            dataArray = array;
        }

        int[] dataArray;

        public override object GetResult()
        {
            return Convert.ToDouble(GetSum(dataArray)) / Convert.ToDouble(dataArray.Length);
        }

        public override object GetMeanCondition()
        {
            int[] newArray = (int[])GetArrayCondition();
            return Convert.ToDouble(GetSum(newArray)) / Convert.ToDouble(newArray.Length);
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

            int[] result = dataArray;

            foreach (Func<object, bool> method in methodArray)
            {
                result = result.Where(n => method(n)).ToArray();
            }

            return result;
        }

        public override object GetMeanConditions()
        {
            int[] newArray = (int[])GetArrayConditions();
            return Convert.ToDouble(GetSum(newArray)) / Convert.ToDouble(newArray.Length);
        }
    }
}
