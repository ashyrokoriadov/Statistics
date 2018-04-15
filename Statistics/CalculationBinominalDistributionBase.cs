using System;
using Statistics.IntegralCalculus;
using Statistics.Implementations;

namespace Statistics
{
    abstract class CalculationBinominalDistributionBase : CalculationDistribution
    {
        protected int n;
        protected int x;
        
        public abstract object GetCombinationNumber();
        
        public abstract object GetProbability();

        public abstract object GetProbabilityReverse(double criterion);

        public abstract object GetProbabilityRange(object range);

        public abstract object GetCumulativeDistribution(int criterion);

        public abstract object GetHypothesisTestingForPercentage(object p0, out object lessThan, out object greaterThan);
        
        public virtual object GetTwoPercentageEqualTesting(BinominalSample sample1, BinominalSample sample2, out object lessThan, out object greaterThan)
        {
            double totalP = Convert.ToDouble(sample1.nFeature + sample2.nFeature) / Convert.ToDouble(sample1.nTotal + sample2.nTotal);
            double z = (sample1.testingP - sample2.testingP) - (sample1.p - sample2.p) / Math.Sqrt(totalP * (1 - totalP) * (1 / Convert.ToDouble(sample1.nTotal) + 1 / Convert.ToDouble(sample2.nTotal)));

            SimpsonMethod sm1 = new SimpsonMethod(-3.6, z, 30000, zFunction);
            lessThan = (1 / Math.Sqrt(2 * Math.PI)) * sm1.GetResult();

            SimpsonMethod sm2 = new SimpsonMethod(z, 3.6, 30000, zFunction);
            greaterThan = (1 / Math.Sqrt(2 * Math.PI)) * sm2.GetResult();

            return z;
        }

        public virtual object GetTwoPercentageTesting(BinominalSample sample1, BinominalSample sample2, out object lessThan, out object greaterThan)
        {
            double totalP = Convert.ToDouble(sample1.nFeature + sample2.nFeature) / Convert.ToDouble(sample1.nTotal + sample2.nTotal);
            double z = (sample1.testingP - sample2.testingP) / Math.Sqrt(totalP * (1 - totalP) * (1 / Convert.ToDouble(sample1.nTotal) + 1 / Convert.ToDouble(sample2.nTotal)));

            SimpsonMethod sm1 = new SimpsonMethod(-3.6, z, 30000, zFunction);
            lessThan = (1 / Math.Sqrt(2 * Math.PI)) * sm1.GetResult();

            SimpsonMethod sm2 = new SimpsonMethod(z, 3.6, 30000, zFunction);
            greaterThan = (1 / Math.Sqrt(2 * Math.PI)) * sm2.GetResult();

            return z;
        }

        double zFunction(double x)
        {
            return Math.Pow(Math.E, -(Math.Pow(x, 2) / 2));
        }
    }
}
