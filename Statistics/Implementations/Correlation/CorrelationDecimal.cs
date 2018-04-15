using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Statistics.Implementations
{
    class CorrelationDecimal : CalculationCorrelation
    {
        decimal[] array1;
        decimal[] array2;

        private int _length;
        public int length
        {
            get
            {
                return _length;
            }
            private set
            {
                _length = value;
            }
        }

        public CorrelationDecimal(decimal[] array1, decimal[] array2)
        {
            this.array1 = array1;
            this.array2 = array2;
            length = SetLength();
        }

        public override object GetCorrelationRatio()
        {          
            StandardDeviation sd1 = new StandardDeviation(array1);
            StandardDeviation sd2 = new StandardDeviation(array2);

            decimal mean1 = (decimal)sd1.GetMean();
            decimal mean2 = (decimal)sd2.GetMean();

            decimal sum = 0;

            for (int i=0; i<length; i++)
            {
                sum += (array1[i] - mean1) * (array2[i] - mean2);
            }

            return (sum / ((decimal)sd1.GetResult() * (decimal)sd2.GetResult())) / (length - 1);
        }

        public override void GetGreatFive(out object mean1, out object mean2, out object sigma1, out object sigma2, out object r)
        {
            StandardDeviation sd1 = new StandardDeviation(array1);
            StandardDeviation sd2 = new StandardDeviation(array2);

            mean1 = (decimal)sd1.GetMean();
            mean2 = (decimal)sd2.GetMean();

            sigma1 = (decimal)sd1.GetResult();
            sigma2 = (decimal)sd2.GetResult();

            decimal sum = 0;

            for (int i = 0; i < length; i++)
            {
                sum += (array1[i] - (decimal)mean1) * (array2[i] - (decimal)mean2);
            }

            r = (sum / ((decimal)sigma1 * (decimal)sigma2) )/ (length - 1);
        }

        public override void GetLinearEquationCoefficient(out object m, out object b)
        {
            object mean1; object mean2;
            object sigma1; object sigma2;
            object r;

            GetGreatFive(out mean1, out mean2, out sigma1, out sigma2, out r);

            m = (decimal)r * (decimal)sigma2 / (decimal)sigma1;
            b = (decimal)mean2 - (decimal)m * (decimal)mean1;
        }

        public override object GetResult()
        {
            throw new NotImplementedException();
        }

        int SetLength()
        {
            if (array1.Length != array2.Length)
            {
                if (array1.Length > array2.Length)
                {
                    return array2.Length;
                }
                else
                {
                    return array1.Length;
                }
            }
            else
            {
                return array1.Length;
            }
        }
    }
}
