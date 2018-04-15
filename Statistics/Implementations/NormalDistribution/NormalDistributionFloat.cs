using System;
using System.Linq;
using System.Threading;
using Statistics.IntegralCalculus;

namespace Statistics.Implementations
{
    class NormalDistributionFloat: CalculationNormalDistributionBase
    {
        float[] dataArray;
        float mean;
        float standardDeviation;
        StandardDeviation sd;          

        public NormalDistributionFloat(float[] array)
        {
            dataArray = array;
            sd = new StandardDeviation(dataArray);
            standardDeviation = (float)sd.GetResult();
            mean = (float)sd.GetMean();
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
            if (!IsFloat(a))
                throw new ArgumentException(ERROR_ARGUMENT_FLOAT);

            float za = GetZValue(Convert.ToSingle(a));
            SimpsonMethod sm = new SimpsonMethod(-3.6, za, 30000, zFunction);
            return (float)((1 / Math.Sqrt(2 * Math.PI)) * sm.GetResult());
        }

        public override object GetProbabilityGreaterThan(object a)
        {
            if (!IsFloat(a))
                throw new ArgumentException(ERROR_ARGUMENT_FLOAT);

            float za = GetZValue(Convert.ToSingle(a));
            SimpsonMethod sm = new SimpsonMethod(za, 3.6, 30000, zFunction);
            return (float)((1 / Math.Sqrt(2 * Math.PI)) * sm.GetResult());
        }

        public override object GetProbabilityBetween(object a, object b)
        {
            if (!IsFloat(a) || !IsFloat(b))
                throw new ArgumentException(ERROR_ARGUMENT_FLOAT);

            float za = GetZValue(Convert.ToSingle(a));
            float zb = GetZValue(Convert.ToSingle(b));
            SimpsonMethod sm = new SimpsonMethod(za, zb, 30000, zFunction);
            return (float)((1 / Math.Sqrt(2 * Math.PI)) * sm.GetResult());
        }

        public override object GetValueFromProbability(int probability)
        {
            if (probability < 0 || probability > 100)
                throw new ArgumentException(ERROR_ARGUMENT_N_NUMBER);

            float zValue = FindZ((float)probability /100);
            return GetValueFromZ(zValue);
        }

        public override object GetZArray()
        {
            float[] result = new float[dataArray.Length];

            for(int i=0; i<dataArray.Length; i++)
            {
                result[i] = (dataArray[i] - mean) / standardDeviation;
            }

            return result;
        }

        public override object GetRandomNormalDistribution(int n, object mean, object sd)
        {
            if (!IsFloat(mean) || !IsFloat(sd))
                throw new ArgumentException(ERROR_ARGUMENT_FLOAT);

            float[] result = new float[n];
            for (int i=0; i<n; i++)
            {
                result[i] = (float)GetRandomValue(Convert.ToSingle(mean), Convert.ToSingle(sd));
            }
            return result;
        }

        public override object GetZForConfidenceLevel(object confidenceLevel)
        {
            if (!IsFloat(confidenceLevel))
                throw new ArgumentException(ERROR_ARGUMENT_FLOAT);

            float confidenceLevelFloat = Convert.ToSingle(confidenceLevel);

            if (confidenceLevelFloat < 0 || confidenceLevelFloat > 100)
                throw new ArgumentException(ERROR_ARGUMENT_N_NUMBER);

            float baseValue = (confidenceLevelFloat + (100 - confidenceLevelFloat) / 2)/100;
            return FindZ(baseValue);
        }

        public override object GetConfidenceInterval(double cl)
        {
            float zParameter = (float)GetZForConfidenceLevel(Convert.ToSingle(cl));
            return (float)(zParameter * (float)GetStandardDeviation()/Math.Sqrt(dataArray.Length));
        }

        public override object GetConfidenceInterval(double cl, double s, int n)
        {
            float zParameter = (float)GetZForConfidenceLevel(Convert.ToSingle(cl));
            return zParameter * s / Math.Sqrt(n);
        }

        public override object GetHypothesisTestingForMean(object m, object sigma, out double lessThan, out double greaterThan)
        {
            if (!IsFloat(m) || !IsFloat(sigma))
                throw new ArgumentException(ERROR_ARGUMENT_DOUBLE);

            float z = (mean - (float)m) / ((float)sigma / Convert.ToSingle(Math.Sqrt(dataArray.Length)));

            SimpsonMethod sm1 = new SimpsonMethod(-3.6, Convert.ToDouble(z), 30000, zFunction);
            lessThan = (1 / Math.Sqrt(2 * Math.PI)) * sm1.GetResult();

            SimpsonMethod sm2 = new SimpsonMethod(Convert.ToDouble(z), 3.6, 30000, zFunction);
            greaterThan = (1 / Math.Sqrt(2 * Math.PI)) * sm2.GetResult();

            return z;
        }

        float GetZValue(float x)
        {
            return (x - mean) / standardDeviation;
        }

        float GetValueFromZ(float z)
        {
            return mean + z * standardDeviation;
        }

        double zFunction(double x)
        {
            return Math.Pow(Math.E, -(Math.Pow(x, 2) / 2));
        }

        float FindZ(float baseValue)
        {
            float initialValue = -3.60F;

            while (initialValue < 3.61F)
            {
                SimpsonMethod sm = new SimpsonMethod(-3.6, initialValue, 30000, zFunction);
                double checkValue = (1 / Math.Sqrt(2 * Math.PI)) * sm.GetResult();

                if (baseValue - checkValue < 0.0005F)
                {
                    return initialValue;
                }
                initialValue += 0.01F;
            }

            return initialValue;
        }

        float GetRandomValue(float mean, float sd)
        {
            Random r = new Random();
            float x = r.Next(10000000, 20000000);
            float a = r.Next(20000000, 40000000);
            float m = r.Next(41000000, 99000000);
            int n = 12;
            float initialValue = x / m;           
            float[] arrayX = new float[n];
            float[] arrayR;

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

            float s = arrayR.Sum();
            float Ms = n/2;
            float Ds = n/12;
            float z = s - Ms / (float)Math.Sqrt(Ds);
            return mean + sd * z;
        }
       
    }
}
