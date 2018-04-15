using System;
using Statistics.IntegralCalculus;

namespace Statistics.Implementations
{
    class StudentTDistributionFloat : CalculationStudentTDistributionBase
    {
        float t;

        public StudentTDistributionFloat(int n, float t)
        {
            if (n < 1F || n > 30F)
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
                return Math.Sqrt(n / ((float)n - 2));
            throw new Exception(N_GREATER_THAN_2_SD);
        }

        public override object GetVariance()
        {
            if (n > 2)
                return n / ((float)n - 2);
            throw new Exception(N_GREATER_THAN_2_V);
        }

        public override object GetProbabilityDensity()
        {
            float component1 = (float) (1 / (Math.Sqrt(n) * Beta(0.5, n / 2)));
            float component2 = (float) (Math.Pow(1 + t * t / n, -Convert.ToDouble(n + 1) / 2));
            return component1 * component2;
        }

        public override object GetProbability()
        {
            float xt = n / (t * t + n);
            float notFullBeta = Beta(0, xt, n / 2, 0.5);
            float fullBeta = Beta(n / 2, 0.5);
            float I = notFullBeta / fullBeta;
            return 1 - (1 - 0.5 * I);
        }

        public override object GetTParameter(double cl)
        {
            if (cl < 80 || cl > 99)
                throw new Exception(CONFIDENCE_LEVEL);

            float probability = (100 - (float)cl) / 2 / 100;
            float full = Beta(n / 2, 0.5);
            float notFull = 2 * full * probability;
            float xt = n / (t * t + n);
            float test = Beta(0, xt, n / 2, 0.5);
            float notFullToCompare;

            t = 1.27F;
            while (t <= 636.26)
            {
                xt = n / (t * t + n);
                notFullToCompare = Beta(0, xt, n / 2, 0.5);
                if (Math.Round(notFullToCompare, 4) - Math.Round(notFull, 4) < 0.00025)
                {
                    return t;
                }
                t += 0.01F;
            }
            t = -1;
            return t;
        }

        public override object GetConfidenceInterval(double cl, double s)
        {
            float tParameter = (float)GetTParameter(cl);
            return tParameter * s / Math.Sqrt(n);
        }

        public override object GetTParameter(double cl, int n)
        {
            StudentTDistributionFloat tdistribution = new StudentTDistributionFloat(n, 1.27F);
            return tdistribution.GetTParameter(cl);           
        }

        public override object GetConfidenceInterval(double cl, double s, int n)
        {
            StudentTDistributionFloat tdistribution = new StudentTDistributionFloat(n, 1.27F);
            return tdistribution.GetConfidenceInterval(cl, s);
        }

        public override object GetTTestValue(object array1, object array2)
        {
            StandardDeviation sd1 = new StandardDeviation(array1);
            StandardDeviation sd2 = new StandardDeviation(array2);

            float array1Mean = (float)sd1.GetMean();
            float array1SD = (float)sd1.GetResult();

            float array2Mean = (float)sd2.GetMean();
            float array2SD = (float)sd2.GetResult();

            int length1 = (array1 as Array).Length;
            int length2 = (array2 as Array).Length;

            return Math.Abs(array1Mean - array2Mean) / (Math.Sqrt(Math.Pow(array1SD, 2) / length1 + Math.Pow(array2SD, 2) / length2));
        }

        public override object GetHypothesisTestingForMean(object array, object m, object sigma, out object lessThan, out object greaterThan)
        {
            StandardDeviation sd = new StandardDeviation(array);

            if (!IsFloat(m) || !IsFloat(sigma))
                throw new ArgumentException(ERROR_ARGUMENT_FLOAT);

            var strongTypeDataFloat = array as float[];
            float[] arrayFloat;

            if (strongTypeDataFloat != null)
            {
                arrayFloat = strongTypeDataFloat;
            }
            else
            {
                throw new ArgumentException(ERROR_ARGUMENT_FLOAT_ARRAY);
            }

            float t = ((float)sd.GetMean() - (float)m) / ((float)sigma / Convert.ToSingle(Math.Sqrt(arrayFloat.Length)));

            StudentTDistributionFloat tDistribution = new StudentTDistributionFloat(arrayFloat.Length - 1, t);
            lessThan = Convert.ToSingle(tDistribution.GetProbability());
            greaterThan = Convert.ToSingle(1 - (float)lessThan);

            return t;
        }

        float Beta(double x, double y)
        {
            SimpsonMethod sm = new SimpsonMethod(0, 1, 100000, x, y, BetaFunction);
            return (float)sm.GetResultParameterizedMethod2Arguments();
        }

        float Beta(double a, double b, double x, double y)
        {
            SimpsonMethod sm = new SimpsonMethod(a, b, 100000, x, y, BetaFunction);
            return (float)sm.GetResultParameterizedMethod2Arguments();
        }

        double BetaFunction(double t, double x, double y)
        {
            if (t == 0 || t - 1 == 0)
                return 0;
            return Math.Pow(t, x - 1) * Math.Pow(1 - t, y - 1);
        }       
    }
}
