using System;

namespace Statistics.Implementations
{
    class StandardDeviationDouble : CalculationStandardDeviationBase
    {
        double[] dataArray;

        public StandardDeviationDouble(double[] array)
        {
            dataArray = array;
        }       
        
        private double GetStandardDeviation()
        {
            double sampleVariance =  (double) GetSampleVariance();
            return Math.Sqrt(sampleVariance);
        }

        public override object GetMean()
        {
            ArithmeticMean ArithmeticMean = new ArithmeticMean(dataArray);
            return ArithmeticMean.GetResult();
        }

        public override object GetSampleVariance()
        {
            double mean = (double)GetMean();

            double[] intermediateResult = new double[dataArray.Length];
            double intermediateSum = 0;
            for (int i = 0; i < dataArray.Length; i++)
            {
                intermediateResult[i] = dataArray[i] - mean;
                intermediateResult[i] = Math.Pow(intermediateResult[i], 2);
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
