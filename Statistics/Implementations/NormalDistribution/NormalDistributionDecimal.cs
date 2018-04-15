using System;
using System.Linq;
using System.Threading;
using Statistics.IntegralCalculus;

namespace Statistics.Implementations
{
    class NormalDistributionDecimal : CalculationNormalDistributionBase
    {
        decimal[] dataArray;
        decimal mean;
        decimal standardDeviation;
        StandardDeviation sd;        

        public NormalDistributionDecimal(decimal[] array)
        {
            dataArray = array;
            sd = new StandardDeviation(dataArray);
            standardDeviation = (decimal)sd.GetResult();
            mean = (decimal)sd.GetMean();
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
            if (!IsDecimal(a))
                throw new ArgumentException(ERROR_ARGUMENT_DECIMAL);

            decimal za = GetZValue((decimal)a);
            SimpsonMethod sm = new SimpsonMethod(-3.6, (double)za, 30000, zFunction);
            return (decimal)((1 / Math.Sqrt(2 * Math.PI)) * sm.GetResult());
        }

        public override object GetProbabilityGreaterThan(object a)
        {
            if (!IsDecimal(a))
                throw new ArgumentException(ERROR_ARGUMENT_DECIMAL);

            decimal za = GetZValue((decimal)a);
            SimpsonMethod sm = new SimpsonMethod((double)za, 3.6, 30000, zFunction);
            return (decimal)((1 / Math.Sqrt(2 * Math.PI)) * sm.GetResult());
        }

        public override object GetProbabilityBetween(object a, object b)
        {
            if (!IsDecimal(a) || !IsDecimal(b))
                throw new ArgumentException(ERROR_ARGUMENT_DECIMAL);

            decimal za = GetZValue((decimal)a);
            decimal zb = GetZValue((decimal)b);
            SimpsonMethod sm = new SimpsonMethod((double)za, (double)zb, 30000, zFunction);
            return (decimal)((1 / Math.Sqrt(2 * Math.PI)) * sm.GetResult());
        }

        public override object GetValueFromProbability(int probability)
        {
            if (probability < 0 || probability > 100)
                throw new ArgumentException(ERROR_ARGUMENT_N_NUMBER);

            decimal zValue = FindZ((decimal)probability/100);
            return GetValueFromZ(zValue);
        }

        public override object GetZArray()
        {
            decimal[] result = new decimal[dataArray.Length];

            for(int i=0; i<dataArray.Length; i++)
            {
                result[i] = (dataArray[i] - mean) / standardDeviation;
            }

            return result;
        }

        public override object GetRandomNormalDistribution(int n, object mean, object sd)
        {
            if (!IsDecimal(mean)|| !IsDecimal(sd))
                throw new ArgumentException(ERROR_ARGUMENT_DECIMAL);

            decimal[] result = new decimal[n];
            for (int i=0; i<n; i++)
            {
                result[i] = GetRandomValue((decimal)mean, (decimal)sd);
            }
            return result;
        }

        public override object GetZForConfidenceLevel(object confidenceLevel)
        {
            if(!IsDecimal(confidenceLevel))
                throw new ArgumentException(ERROR_ARGUMENT_DECIMAL);

            decimal confidenceLevelDecimal = Convert.ToDecimal(confidenceLevel);

            if (confidenceLevelDecimal < 0 || confidenceLevelDecimal > 100)
                throw new ArgumentException(ERROR_ARGUMENT_N_NUMBER);

            decimal baseValue = (confidenceLevelDecimal + (100 - confidenceLevelDecimal) / 2)/100;
            return FindZ(baseValue);
        }

        public override object GetConfidenceInterval(double cl)
        {
            decimal zParameter = (decimal)GetZForConfidenceLevel(Convert.ToDecimal(cl));
            return zParameter * (decimal)GetStandardDeviation() / (decimal)Math.Sqrt(dataArray.Length);
        }

        public override object GetConfidenceInterval(double cl, double s, int n)
        {
            decimal zParameter = (decimal)GetZForConfidenceLevel(Convert.ToDecimal(cl));
            return zParameter * (decimal)s / (decimal)Math.Sqrt(n);
        }

        public override object GetHypothesisTestingForMean(object m, object sigma, out double lessThan, out double greaterThan)
        {
            if (!IsDecimal(m) || !IsDecimal(sigma))
                throw new ArgumentException(ERROR_ARGUMENT_DOUBLE);

            decimal z = (mean - (decimal)m) / ((decimal)sigma / Convert.ToDecimal(Math.Sqrt(dataArray.Length)));

            SimpsonMethod sm1 = new SimpsonMethod(-3.6, Convert.ToDouble(z), 30000, zFunction);
            lessThan = (1 / Math.Sqrt(2 * Math.PI)) * sm1.GetResult();

            SimpsonMethod sm2 = new SimpsonMethod(Convert.ToDouble(z), 3.6, 30000, zFunction);
            greaterThan = (1 / Math.Sqrt(2 * Math.PI)) * sm2.GetResult();

            return z;
        }

        decimal GetZValue(decimal x)
        {
            return (x - mean) / standardDeviation;
        }

        decimal GetValueFromZ(decimal z)
        {
            return mean + z * standardDeviation;
        }

        double zFunction(double x)
        {
            return Math.Pow(Math.E, -(Math.Pow(x, 2) / 2));
        }

        decimal FindZ(decimal baseValue)
        {
            double initialValue = -3.60;

            while (initialValue < 3.61)
            {
                SimpsonMethod sm = new SimpsonMethod(-3.6, initialValue, 30000, zFunction);
                double checkValue = (1 / Math.Sqrt(2 * Math.PI)) * sm.GetResult();

                if ((double)baseValue - checkValue < 0.0005)
                {
                    return (decimal)Math.Round(initialValue, 2);
                }
                initialValue += 0.01;
            }

            return (decimal)Math.Round(initialValue,2);
        }

        decimal GetRandomValue(decimal mean, decimal sd)
        {
            Random r = new Random();
            decimal x = r.Next(10000000, 20000000);
            decimal a = r.Next(20000000, 40000000);
            decimal m = r.Next(41000000, 99000000);
            int n = 12;
            decimal initialValue = x / m;           
            decimal[] arrayX = new decimal[n];
            decimal[] arrayR;

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

            decimal s = arrayR.Sum();
            decimal Ms = n/2;
            decimal Ds = n/12;
            decimal z = s - Ms / (decimal)Math.Sqrt((double)Ds);
            return mean + sd * z;
        }
        
    }
}
