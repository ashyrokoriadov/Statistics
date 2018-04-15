using System;
using System.Linq;
using Statistics.IntegralCalculus;

namespace Statistics.Implementations
{
    class BinominalDistributionDecimal : CalculationBinominalDistributionBase
    {        
        decimal p;

        public BinominalDistributionDecimal(int n, int x, decimal p)
        {
            this.n = n;
            this.x = x;
            this.p = p;
        }       
        
        public override object GetStandardDeviation()
        {
            return (decimal)Math.Sqrt((double)(n * p * (1 - p)));
        }

        public override object GetVariance()
        {
            return n * p * (1 - p);
        }

        public override object GetProbability()
        {
            double result = (double)GetCombinationNumber(n, x) * Math.Pow((double)p, x) * Math.Pow((1 - (double)p), (n - x));
            return (decimal)Math.Round(result, 3);
        }

        public override object GetProbabilityRange(object range)
        {
            if (!IsDecimalArray(range))
                throw new ArgumentException(ERROR_ARGUMENT_DECIMAL_ARRAY);

            decimal[] array = (decimal[])range;
            decimal result = array.Select(item =>
            {
                BinominalDistributionDecimal bdd = new BinominalDistributionDecimal(n, Convert.ToInt32(item), p);
                return Convert.ToDecimal(bdd.GetProbability());
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

            return Convert.ToDecimal(startPosition += 2);
        }

        public override object GetCumulativeDistribution(int criterion)
        {
            decimal sum = 0;
            for (int i = 0; i <= criterion; i++)
            {
                BinominalDistribution bd = new BinominalDistribution(n, i, p);
                sum += Convert.ToDecimal(bd.GetProbability());
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

        private decimal GetFactorial(decimal y)
        {
            decimal f = 1;
            for (int i = 1; i <= y; i++)
            {
                f *= i;
            }
            return f;
        }

        private decimal GetCombinationNumber(decimal n, decimal x)
        {
            return GetFactorial(n) / (GetFactorial(x) * GetFactorial(n - x));
        }

        public override object GetHypothesisTestingForPercentage(object p0, out object lessThan, out object greaterThan)
        {
            if (!IsDecimal(p0))
                throw new ArgumentException(ERROR_ARGUMENT_DECIMAL);

            decimal z = ((decimal)p0 - p) / Convert.ToDecimal(Math.Sqrt(Convert.ToDouble(p * (1 - p) / n)));

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
