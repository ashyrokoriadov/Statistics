using System;
using Statistics.Interfaces;
using Statistics.IntegralCalculus;
using Statistics.Implementations;

namespace Statistics
{
    public abstract class CalculationBase : IGetResult
    {
        public abstract object GetResult();
        
        public virtual object GetTwoMeansEqualTesting(MeanSample sample1, MeanSample sample2, out object lessThan, out object greaterThan)
        {
            double z = (sample1.mean - sample2.mean) - (sample1.meanPopulation - sample2.meanPopulation) / Math.Sqrt(Math.Pow(sample1.sigmaPopulation, 2) / Convert.ToDouble(sample1.sampleQuantity) + Math.Pow(sample2.sigmaPopulation, 2) / Convert.ToDouble(sample2.sampleQuantity));

            SimpsonMethod sm1 = new SimpsonMethod(-3.6, z, 30000, zFunction);
            lessThan = (1 / Math.Sqrt(2 * Math.PI)) * sm1.GetResult();

            SimpsonMethod sm2 = new SimpsonMethod(z, 3.6, 30000, zFunction);
            greaterThan = (1 / Math.Sqrt(2 * Math.PI)) * sm2.GetResult();

            return z;
        }

        public virtual object GetTwoMeansTesting(MeanSample sample1, MeanSample sample2, out object lessThan, out object greaterThan)
        {

            if (sample1.meanPopulation - sample2.meanPopulation == 0)
            {
                double z = (sample1.mean - sample2.mean) / Math.Sqrt(Math.Pow(sample1.sigmaPopulation,2) / Convert.ToDouble(sample1.sampleQuantity) + Math.Pow(sample2.sigmaPopulation,2) / Convert.ToDouble(sample2.sampleQuantity));

                SimpsonMethod sm1 = new SimpsonMethod(-3.6, z, 30000, zFunction);
                lessThan = (1 / Math.Sqrt(2 * Math.PI)) * sm1.GetResult();

                SimpsonMethod sm2 = new SimpsonMethod(z, 3.6, 30000, zFunction);
                greaterThan = (1 / Math.Sqrt(2 * Math.PI)) * sm2.GetResult();

                return z;
            }
            else
            {
                return GetTwoMeansEqualTesting(sample1, sample2, out lessThan, out greaterThan);
            }
        }
        
        #region Protected Methods
        protected int GetSum(int[] array)
        {
            int sum = 0;
            for (int i = 0; i < array.Length; i++)
            {
                sum += array[i];
            }
            return sum;
        }

        protected double GetSum(double[] array)
        {
            double sum = 0;
            for (int i = 0; i < array.Length; i++)
            {
                sum += array[i];
            }
            return sum;
        }

        protected float GetSum(float[] array)
        {
            float sum = 0;
            for (int i = 0; i < array.Length; i++)
            {
                sum += array[i];
            }
            return sum;
        }

        protected decimal GetSum(decimal[] array)
        {
            decimal sum = 0;
            for (int i = 0; i < array.Length; i++)
            {
                sum += array[i];
            }
            return sum;
        }

        protected bool IsFraction(double number)
        {
            string numberString = number.ToString();
            if (numberString.IndexOf(",") == -1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion

        #region Private Methods
        double zFunction(double x)
        {
            return Math.Pow(Math.E, -(Math.Pow(x, 2) / 2));
        }
        #endregion
    }
}
