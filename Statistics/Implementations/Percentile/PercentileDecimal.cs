using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Statistics.Implementations
{
    class PercentileDecimal : CalculationBase
    {
        int KthPercentile;
        decimal[] dataArray;

        public PercentileDecimal(decimal[] array, int percentile)
        {
            dataArray = array;
            KthPercentile = percentile;
        }       
        
        private decimal GetPercentile()
        {
            Array.Sort(dataArray);

            double kMultipleQuantity = 1.0 * KthPercentile * dataArray.Length / 100;

            int percentileIndex;

            percentileIndex = Convert.ToInt32(Math.Ceiling(kMultipleQuantity));
            return GetValueDependOnElementsQuantity(dataArray, percentileIndex);
          
        }

        private decimal GetValueDependOnElementsQuantity(decimal[] array, int percentileIndex)
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
