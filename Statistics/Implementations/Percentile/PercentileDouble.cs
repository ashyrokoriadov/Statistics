using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Statistics.Implementations
{
    class PercentileDouble : CalculationBase
    {
        int KthPercentile;
        double[] dataArray;

        public PercentileDouble(double[] array, int percentile)
        {
            dataArray = array;
            KthPercentile = percentile;
        }       
        
        private double GetPercentile()
        {
            Array.Sort(dataArray);

            double kMultipleQuantity = 1.0 * KthPercentile * dataArray.Length / 100;

            int percentileIndex;

            percentileIndex = Convert.ToInt32(Math.Ceiling(kMultipleQuantity));
            return GetValueDependOnElementsQuantity(dataArray, percentileIndex);

        }

        private double GetValueDependOnElementsQuantity(double[] array, int percentileIndex)
        {
            int index = percentileIndex - 1;
            if (array.Length % 2 == 0)
            {
                return (array[index] + array[index + 1]) / 2;
            }
            else
            {
                return array[percentileIndex];
            }
        }

        public override object GetResult()
        {
            return GetPercentile();
        }
    }
}
