using System;
using Statistics.IntegralCalculus;
using System.Linq;
using System.Text;

namespace Statistics.Implementations
{
    class StudentTDistributionDecimal: CalculationStudentTDistributionBase
    {
        decimal t;

        public StudentTDistributionDecimal(int n, decimal t)
        {
            if (n < 1M || n > 30M)
                throw new Exception(N_NUMBER_ERROR);
            this.n = n;
            this.t = t;
        }

        public override object GetMean()
        {
            if (n > 1)
                return 0;
            throw new Exception(N_GREATER_THAN_1);
        }

        public override object GetStandardDeviation()
        {
            if (n > 2)
                return Math.Sqrt(n / ((double)n - 2));
            throw new Exception(N_GREATER_THAN_2_SD);
        }

        public override object GetVariance()
        {
            if (n > 2)
                return n / ((double)n - 2);
            throw new Exception(N_GREATER_THAN_2_V);
        }

        public override object GetProbabilityDensity()
        {
            decimal component1 = (decimal)(1 / (Math.Sqrt(n) * Beta(0.5, n / 2)));
            decimal component2 = (decimal)Math.Pow((double)(1 + t * t / n), -Convert.ToDouble(n + 1) / 2);
            return component1 * component2;
        }

        public override object GetProbability()
        {
            decimal xt = n / (t * t + n);
            decimal notFullBeta = (decimal)Beta(0, (double)xt, n / 2, 0.5);
            decimal fullBeta = (decimal) Beta(n / 2, 0.5);
            decimal I = notFullBeta / fullBeta;
            return 1 - (1 - 0.5M * I);
        }

        public override object GetTParameter(double cl)
        {
            if (cl < 80 || cl > 99)
                throw new Exception(CONFIDENCE_LEVEL);

            double t = 1.27;
            double probability = (100 - cl) / 2 / 100;
            double full = Beta(n / 2, 0.5);
            double notFull = 2 * full * probability;
            double xt = n / (t * t + n);
            double test = Beta(0, xt, n / 2, 0.5);
            double notFullToCompare;            

            while (t <= 636.26)
            {
                xt = n / (t * t + n);
                notFullToCompare = Beta(0, xt, n / 2, 0.5);
                if (Math.Round(notFullToCompare, 4) - Math.Round(notFull, 4) < 0.00025)
                {
                    return t;
                }
                t += 0.01;
            }
            t = -1;
            return t;
        }

        public override object GetConfidenceInterval(double cl, double s)
        {
            double tParameter = (double)GetTParameter(cl);
            return tParameter * s / Math.Sqrt(n);
        }

        public override object GetTParameter(double cl, int n)
        {
            StudentTDistributionDouble tdistribution = new StudentTDistributionDouble(n, 1.27);
            return tdistribution.GetTParameter(cl);
        }

        public override object GetConfidenceInterval(double cl, double s, int n)
        {
            StudentTDistributionDouble tdistribution = new StudentTDistributionDouble(n, 1.27);
            return tdistribution.GetConfidenceInterval(cl, s);
        }

        public override object GetTTestValue(object array1, object array2)
        {
            StandardDeviation sd1 = new StandardDeviation(array1);
            StandardDeviation sd2 = new StandardDeviation(array2);

            decimal array1Mean = (decimal)sd1.GetMean();
            decimal array1SD = (decimal)sd1.GetResult();

            decimal array2Mean = (decimal)sd2.GetMean();
            decimal array2SD = (decimal)sd2.GetResult();

            int length1 = (array1 as Array).Length;
            int length2 = (array2 as Array).Length;

            return (double)Math.Abs(array1Mean - array2Mean) / (Math.Sqrt(Math.Pow(Convert.ToDouble(array1SD), 2) / length1 + Math.Pow(Convert.ToDouble(array2SD), 2) / length2));
        }

        public override object GetHypothesisTestingForMean(object array, object m, object sigma, out object lessThan, out object greaterThan)
        {
            StandardDeviation sd = new StandardDeviation(array);

            if (!IsDecimal(m) || !IsDecimal(sigma))
                throw new ArgumentException(ERROR_ARGUMENT_DECIMAL);

            var strongTypeDataDecimal = array as decimal[];
            decimal[] arrayDecimal;

            if (strongTypeDataDecimal != null)
            {
                arrayDecimal = strongTypeDataDecimal;
            }
            else
            {
                throw new ArgumentException(ERROR_ARGUMENT_DECIMAL_ARRAY);
            }

            decimal t = ((decimal)sd.GetMean() - (decimal)m) / ((decimal)sigma / Convert.ToDecimal(Math.Sqrt(arrayDecimal.Length)));

            StudentTDistributionDecimal tDistribution = new StudentTDistributionDecimal(arrayDecimal.Length - 1, t);
            lessThan = Convert.ToDecimal(tDistribution.GetProbability());
            greaterThan = Convert.ToDecimal(1 - (decimal)lessThan);

            return t;
        }

        double Beta(double x, double y)
        {
            SimpsonMethod sm = new SimpsonMethod(0, 1, 100000, x, y, BetaFunction);
            return sm.GetResultParameterizedMethod2Arguments();
        }

        double Beta(double a, double b, double x, double y)
        {
            SimpsonMethod sm = new SimpsonMethod(a, b, 100000, x, y, BetaFunction);
            return sm.GetResultParameterizedMethod2Arguments();
        }

        private double BetaFunction(double t, double x, double y)
        {
            if (t == 0 || t - 1 == 0)
                return 0;
            return Math.Pow(t, x - 1) * Math.Pow(1 - t, y - 1);
        }        
    }
}
