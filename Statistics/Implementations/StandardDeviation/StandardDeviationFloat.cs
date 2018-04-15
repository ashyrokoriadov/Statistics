using System;

namespace Statistics.Implementations
{
    class StandardDeviationFloat : CalculationStandardDeviationBase
    {
        float[] dataArray;

        public StandardDeviationFloat(float[] array)
        {
            dataArray = array;
        }       
        
        private float GetStandardDeviation()
        {
            float sampleVariance =  (float) GetSampleVariance();
            return (float) Math.Sqrt(Convert.ToSingle(sampleVariance));
        }

        public override object GetMean()
        {
            ArithmeticMean ArithmeticMean = new ArithmeticMean(dataArray);
            return ArithmeticMean.GetResult();
        }

        public override object GetSampleVariance()
        {
             float mean = (float)GetMean();

            float[] intermediateResult = new float[dataArray.Length];
            float intermediateSum = 0;
            for (int i = 0; i < dataArray.Length; i++)
            {
                intermediateResult[i] = dataArray[i] - mean;
                intermediateResult[i] = (float) Math.Pow(Convert.ToSingle(intermediateResult[i]), 2);
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
