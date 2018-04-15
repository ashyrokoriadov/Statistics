using System;
using System.Linq;
using Statistics.IntegralCalculus;

namespace Statistics.Implementations
{
    class BinominalDistributionFloat : CalculationBinominalDistributionBase
    {        
        float p;

        public BinominalDistributionFloat(int n, int x, float p)
        {
            this.n = n;
            this.x = x;
            this.p = p;
        }       
        
        public override object GetStandardDeviation()
        {
            return (float)Math.Sqrt(n * p * (1 - p));
        }

        public override object GetVariance()
        {
            return (float)(n * p * (1 - p));
        }

        public override object GetProbability()
        {
            float result = GetCombinationNumber(n, x) * (float)Math.Pow(p, x) * (float)Math.Pow((1 - p), (n - x));
            return (float)Math.Round(result, 3);
        }

        public override object GetProbabilityRange(object range)
        {
            if (!IsFloatArray(range))
                throw new ArgumentException(ERROR_ARGUMENT_FLOAT_ARRAY);

            float[] array = (float[])range;
            float result = array.Select(item =>
            {
                BinominalDistributionFloat bdf = new BinominalDistributionFloat(n, Convert.ToInt32(item), p);
                return Convert.ToSingle(bdf.GetProbability());
            }).ToArray().Sum();

            return result;
        }

        public override object GetProbabilityReverse(double criterion)
        {
            double calculatedCriterion = 1;
            int startPosition = n;
            BinominalDistribution bd;

            while (calculatedCriterion > criterion)
            {
                bd = new BinominalDistribution(n, n, p);
                calculatedCriterion = Math.Round(Convert.ToDouble(bd.GetCumulativeDistribution(startPosition)), 2);
                startPosition--;
            }

            return Convert.ToSingle(startPosition += 2);
        }

        public override object GetCumulativeDistribution(int criterion)
        {
            float sum = 0;
            for (int i = 0; i <= criterion; i++)
            {
                BinominalDistribution bd = new BinominalDistribution(n, i, p);
                sum += Convert.ToSingle(bd.GetProbability());
            }
            return sum;
        }

        public override object GetCombinationNumber()
        {
            return GetFactorial(n) / (GetFactorial(x) * GetFactorial(n - x));
        }

        public override object GetMean()
        {
            return n * p;
        }

        private float GetFactorial(float y)
        {
            float f = 1;
            for (int i = 1; i <= y; i++)
            {
                f *= i;
            }
            return f;
        }

        private float GetCombinationNumber(float n, float x)
        {
            return GetFactorial(n) / (GetFactorial(x) * GetFactorial(n - x));
        }

        public override object GetHypothesisTestingForPercentage(object p0, out object lessThan, out object greaterThan)
        {
            if (!IsFloat(p0))
                throw new ArgumentException(ERROR_ARGUMENT_FLOAT);

            float z = ((float)p0 - p) / Convert.ToSingle(Math.Sqrt(p * (1 - p) / n));

            SimpsonMethod sm1 = new SimpsonMethod(-3.6, Convert.ToDouble(z), 30000, zFunction);
            lessThan = (1 / Math.Sqrt(2 * Math.PI)) * sm1.GetResult();

            SimpsonMethod sm2 = new SimpsonMethod(Convert.ToDouble(z), 3.6, 30000, zFunction);
            greaterThan = (1 / Math.Sqrt(2 * Math.PI)) * sm2.GetResult();

            return z;
        }

        double zFunction(double x)
        {
            return Math.Pow(Math.E, -(Math.Pow(x, 2) / 2));
        }
              
    }
}
