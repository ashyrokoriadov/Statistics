using System;
using System.Linq;
using System.Threading;
using Statistics.IntegralCalculus;

namespace Statistics.Implementations
{
    class NormalDistributionDouble : CalculationNormalDistributionBase
    {
        double[] dataArray;
        double mean;
        double standardDeviation;
        StandardDeviation sd;          

        public NormalDistributionDouble(double[] array)
        {
            dataArray = array;
            sd = new StandardDeviation(dataArray);
            standardDeviation = (double)sd.GetResult();
            mean = (double)sd.GetMean();
        }       
        
        public override object GetStandardDeviation()
        {
            return sd.GetResult();
        }

        public override object GetVariance()
        {
            return sd.GetSampleVariance();
        }
        
        public override object GetMean()
        {
            return sd.GetMean();
        }

        public override object GetProbabilityLessThan(object a)
        {
            if (!IsDouble(a))
                throw new ArgumentException(ERROR_ARGUMENT_DOUBLE);

            double za = GetZValue(Convert.ToDouble(a));
            SimpsonMethod sm = new SimpsonMethod(-3.6, za, 30000, zFunction);
            return (1 / Math.Sqrt(2 * Math.PI)) * sm.GetResult();
        }

        public override object GetProbabilityGreaterThan(object a)
        {
            if (!IsDouble(a))
                throw new ArgumentException(ERROR_ARGUMENT_DOUBLE);

            double za = GetZValue(Convert.ToDouble(a));
            SimpsonMethod sm = new SimpsonMethod(za, 3.6, 30000, zFunction);
            return (1 / Math.Sqrt(2 * Math.PI)) * sm.GetResult();
        }

        public override object GetProbabilityBetween(object a, object b)
        {
            if (!IsDouble(a) || !IsDouble(b))
                throw new ArgumentException(ERROR_ARGUMENT_DOUBLE);

            double za = GetZValue(Convert.ToDouble(a));
            double zb = GetZValue(Convert.ToDouble(b));
            SimpsonMethod sm = new SimpsonMethod(za, zb, 30000, zFunction);
            return (1 / Math.Sqrt(2 * Math.PI)) * sm.GetResult();
        }

        public override object GetValueFromProbability(int probability)
        {
            if (probability < 0 || probability > 100)
                throw new ArgumentException(ERROR_ARGUMENT_N_NUMBER);

            double zValue = FindZ((double)probability/100);
            return GetValueFromZ(zValue);
        }

        public override object GetZArray()
        {
            double[] result = new double[dataArray.Length];

            for(int i=0; i<dataArray.Length; i++)
            {
                result[i] = (dataArray[i] - mean) / standardDeviation;
            }

            return result;
        }

        public override object GetRandomNormalDistribution(int n, object mean, object sd)
        {
            if (!IsDouble(mean) || !IsDouble(sd))
                throw new ArgumentException(ERROR_ARGUMENT_DOUBLE);

            double[] result = new double[n];
            for (int i=0; i<n; i++)
            {
                result[i] = GetRandomValue(Convert.ToDouble(mean), Convert.ToDouble(sd));
            }
            return result;
        }

        public override object GetZForConfidenceLevel(object confidenceLevel)
        {
            if (!IsDouble(confidenceLevel))
                throw new ArgumentException(ERROR_ARGUMENT_DOUBLE);

            double confidenceLevelDouble = Convert.ToDouble(confidenceLevel);

            if (confidenceLevelDouble<0 || confidenceLevelDouble>100)
                throw new ArgumentException(ERROR_ARGUMENT_N_NUMBER);

            double baseValue = (confidenceLevelDouble + (100 - confidenceLevelDouble) / 2) /100;
            return FindZ(baseValue);
        }

        public override object GetConfidenceInterval(double cl)
        {
            double zParameter = (double)GetZForConfidenceLevel(cl);
            return zParameter * (double)GetStandardDeviation() / Math.Sqrt(dataArray.Length);
        }

        public override object GetConfidenceInterval(double cl, double s, int n)
        {
            double zParameter = (double)GetZForConfidenceLevel(cl);
            return zParameter * s / Math.Sqrt(n);
        }

        public override object GetHypothesisTestingForMean(object m, object sigma, out double lessThan, out double greaterThan)
        {
            if (!IsDouble(m) || !IsDouble(sigma))
                throw new ArgumentException(ERROR_ARGUMENT_DOUBLE);

            double z = (mean - (double)m) / ((double)sigma / Math.Sqrt(dataArray.Length));

            SimpsonMethod sm1 = new SimpsonMethod(-3.6, z, 30000, zFunction);
            lessThan =  (1 / Math.Sqrt(2 * Math.PI)) * sm1.GetResult();

            SimpsonMethod sm2 = new SimpsonMethod(z, 3.6, 30000, zFunction);
            greaterThan = (1 / Math.Sqrt(2 * Math.PI)) * sm2.GetResult();

            return z;
        }

        double GetZValue(double x)
        {
            return (x - mean) / standardDeviation;
        }

        double GetValueFromZ(double z)
        {
            return mean + z * standardDeviation;
        }

        double zFunction(double x)
        {
            return Math.Pow(Math.E, -(Math.Pow(x, 2) / 2));
        }

        double FindZ(double baseValue)
        {
            double initialValue = -3.60;

            while (initialValue < 3.61)
            {
                SimpsonMethod sm = new SimpsonMethod(-3.6, initialValue, 30000, zFunction);
                double checkValue = (1 / Math.Sqrt(2 * Math.PI)) * sm.GetResult();

                if (baseValue - checkValue < 0.00025)
                {
                    return initialValue;
                }
                initialValue += 0.01;
            }

            return initialValue;
        }

        double GetRandomValue(double mean, double sd)
        {
            Random r = new Random();
            double x = r.Next(10000000, 20000000);
            double a = r.Next(20000000, 40000000);
            double m = r.Next(41000000, 99000000);
            int n = 12;
            double initialValue = x / m;           
            double[] arrayX = new double[n];
            double[] arrayR;

            for (int i=0; i<n; i++)
            {
                if (i==0)
                {
                    arrayX[i] = x;
                }
                else
                {
                    arrayX[i] = ((arrayX[i - 1] * a) % m);
                }
                Thread.Sleep(1);
            }

            arrayR = arrayX.Select(y => y / m).ToArray();

            double s = arrayR.Sum();
            double Ms = n/2;
            double Ds = n/12;
            double z = s - Ms / Math.Sqrt(Ds);
            return mean + sd * z;
        }
    }
}
