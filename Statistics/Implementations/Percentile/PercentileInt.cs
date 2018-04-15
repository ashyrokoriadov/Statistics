using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Statistics.Implementations
{
    class PercentileInt : CalculationBase
    {
        int KthPercentile;
        int[] dataArray;

        public PercentileInt(int[] array, int percentile)
        {
            dataArray = array;
            KthPercentile = percentile;
        }       
        
        private object GetPercentile()
        {
            Array.Sort(dataArray);

            double kMultipleQuantity = 1.0 * KthPercentile * dataArray.Length / 100;

            int percentileIndex;

            percentileIndex = Convert.ToInt32(Math.Ceiling(kMultipleQuantity));
            return GetValueDependOnElementsQuantity(dataArray, percentileIndex);

        }

        private object GetValueDependOnElementsQuantity(int[] array, int percentileIndex)
        {
            int index = percentileIndex - 1;
            if (array.Length % 2 == 0)
            {
                return 1.0*(array[index] + array[index + 1])/2;
            }
            else
            {
                return array[index];
            }
        }

        public override object GetResult()
        {
            return GetPercentile();
        }
    }
}
