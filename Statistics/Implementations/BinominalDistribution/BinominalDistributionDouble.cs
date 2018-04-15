using System;
using System.Linq;
using Statistics.IntegralCalculus;

namespace Statistics.Implementations
{
    class BinominalDistributionDouble : CalculationBinominalDistributionBase
    {        
        double p;

        public BinominalDistributionDouble(int n, int x, double p)
        {
            this.n = n;
            this.x = x;
            this.p = p;
        }       
        
        public override object GetStandardDeviation()
        {
            return Math.Sqrt(n * p * (1 - p));
        }

        public override object GetVariance()
        {
            return n * p * (1 - p);
        }

        public override object GetProbability()
        {
            double result = GetCombinationNumber(n, x) * Math.Pow(p, x) * Math.Pow((1 - p), (n - x));
            return Math.Round(result, 3);
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

            return startPosition += 2;
        }        

        public override object GetProbabilityRange(object range)
        {
            if (!IsDoubleArray(range))
                throw new ArgumentException(ERROR_ARGUMENT_DOUBLE_ARRAY);

            double[] array = (double[])range;
            double result = array.Select(item =>
            {
                BinominalDistributionDouble bdd = new BinominalDistributionDouble(n, Convert.ToInt32(item), p);
                return Convert.ToDouble(bdd.GetProbability());
            }).ToArray().Sum();

            return result;
        }

        public override object GetCumulativeDistribution(int criterion)
        {
            double sum = 0;
            for (int i = 0; i <= criterion; i++)
            {
                BinominalDistribution bd = new BinominalDistribution(n, i, p);
                sum += Convert.ToDouble(bd.GetProbability());
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

        public override object GetHypothesisTestingForPercentage(object p0, out object lessThan, out object greaterThan)
        {
            if (!IsDouble(p0))
                throw new ArgumentException(ERROR_ARGUMENT_DOUBLE);

            double z = ((double)p0 - p) / Math.Sqrt(p * (1 - p) / n);

            SimpsonMethod sm1 = new SimpsonMethod(-3.6, z, 30000, zFunction);
            lessThan = (1 / Math.Sqrt(2 * Math.PI)) * sm1.GetResult();

            SimpsonMethod sm2 = new SimpsonMethod(z, 3.6, 30000, zFunction);
            greaterThan = (1 / Math.Sqrt(2 * Math.PI)) * sm2.GetResult();

            return z;
        }

        private double GetFactorial(double y)
        {
            double f = 1;
            for (int i = 1; i <= y; i++)
            {
                f *= i;
            }
            return f;
        }

        private double GetCombinationNumber(double n, double x)
        {
            return GetFactorial(n) / (GetFactorial(x) * GetFactorial(n - x));
        }

        double zFunction(double x)
        {
            return Math.Pow(Math.E, -(Math.Pow(x, 2) / 2));
        }        
    }
}
