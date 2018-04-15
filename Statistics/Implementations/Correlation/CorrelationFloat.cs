using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Statistics.Implementations
{
    class CorrelationFloat : CalculationCorrelation
    {
        float[] array1;
        float[] array2;

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

        public CorrelationFloat(float[] array1, float[] array2)
        {
            this.array1 = array1;
            this.array2 = array2;
            length = SetLength();
        }

        public override object GetCorrelationRatio()
        {          
            StandardDeviation sd1 = new StandardDeviation(array1);
            StandardDeviation sd2 = new StandardDeviation(array2);

            float mean1 = (float)sd1.GetMean();
            float mean2 = (float)sd2.GetMean();

            float sum = 0;

            for (int i=0; i<length; i++)
            {
                sum += (array1[i] - mean1) * (array2[i] - mean2);
            }

            return (sum / ((float)sd1.GetResult() * (float)sd2.GetResult())) / (length - 1);
        }

        public override void GetGreatFive(out object mean1, out object mean2, out object sigma1, out object sigma2, out object r)
        {
            StandardDeviation sd1 = new StandardDeviation(array1);
            StandardDeviation sd2 = new StandardDeviation(array2);

            mean1 = (float)sd1.GetMean();
            mean2 = (float)sd2.GetMean();

            sigma1 = (float)sd1.GetResult();
            sigma2 = (float)sd2.GetResult();

            float sum = 0;

            for (int i = 0; i < length; i++)
            {
                sum += (array1[i] - (float)mean1) * (array2[i] - (float)mean2);
            }

            r = (sum / ((float)sigma1 * (float)sigma2) )/ (length - 1);
        }

        public override void GetLinearEquationCoefficient(out object m, out object b)
        {
            object mean1; object mean2;
            object sigma1; object sigma2;
            object r;

            GetGreatFive(out mean1, out mean2, out sigma1, out sigma2, out r);

            m = (float)r * (float)sigma2 / (float)sigma1;
            b = (float)mean2 - (float)m * (float)mean1;
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
