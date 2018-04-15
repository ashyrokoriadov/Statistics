using System;

namespace Statistics.Implementations
{
    class StandardDeviationDecimal : CalculationStandardDeviationBase
    {
        decimal[] dataArray;

        public StandardDeviationDecimal(decimal[] array)
        {
            dataArray = array;
        }       
        
        private decimal GetStandardDeviation()
        {
            decimal sampleVariance =  (decimal) GetSampleVariance();
            return (decimal) Math.Sqrt(Convert.ToDouble(sampleVariance));
        }

        public override object GetMean()
        {
            ArithmeticMean ArithmeticMean = new ArithmeticMean(dataArray);
            return ArithmeticMean.GetResult();
        }

        public override object GetSampleVariance()
        {
            decimal mean = (decimal)GetMean();

            decimal[] intermediateResult = new decimal[dataArray.Length];
            decimal intermediateSum = 0;
            for (int i = 0; i < dataArray.Length; i++)
            {
                intermediateResult[i] = dataArray[i] - mean;
                intermediateResult[i] = (decimal) Math.Pow(Convert.ToDouble(intermediateResult[i]), 2);
                intermediateSum += intermediateResult[i];
            }
            return intermediateSum / (intermediateResult.Length - 1);
        }

        public override object GetResult()
        {
            return GetStandardDeviation();
        }


    }
}
