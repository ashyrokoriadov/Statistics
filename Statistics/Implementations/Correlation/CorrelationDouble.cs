using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Statistics.Implementations
{
    class CorrelationDouble : CalculationCorrelation
    {
        double[] array1;
        double[] array2;

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

        public CorrelationDouble(double[] array1, double[] array2)
        {
            this.array1 = array1;
            this.array2 = array2;
            length = SetLength();
        }

        public override object GetCorrelationRatio()
        {          
            StandardDeviation sd1 = new StandardDeviation(array1);
            StandardDeviation sd2 = new StandardDeviation(array2);

            double mean1 = (double)sd1.GetMean();
            double mean2 = (double)sd2.GetMean();

            double sum = 0;

            for (int i=0; i<length; i++)
            {
                sum += (array1[i] - mean1) * (array2[i] - mean2);
            }

            return (sum / ((double)sd1.GetResult() * (double)sd2.GetResult())) / (length - 1);
        }

        public override void GetGreatFive(out object mean1, out object mean2, out object sigma1, out object sigma2, out object r)
        {
            StandardDeviation sd1 = new StandardDeviation(array1);
            StandardDeviation sd2 = new StandardDeviation(array2);

            mean1 = (double)sd1.GetMean();
            mean2 = (double)sd2.GetMean();

            sigma1 = (double)sd1.GetResult();
            sigma2 = (double)sd2.GetResult();

            double sum = 0;

            for (int i = 0; i < length; i++)
            {
                sum += (array1[i] - (double)mean1) * (array2[i] - (double)mean2);
            }

            r = (sum / ((double)sigma1 * (double)sigma2) )/ (length - 1);
        }

        public override void GetLinearEquationCoefficient(out object m, out object b)
        {
            object mean1; object mean2;
            object sigma1; object sigma2;
            object r;

            GetGreatFive(out mean1, out mean2, out sigma1, out sigma2, out r);

            m = (double)r * (double)sigma2 / (double)sigma1;
            b = (double)mean2 - (double)m * (double)mean1;
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
