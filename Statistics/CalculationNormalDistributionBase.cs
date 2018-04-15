using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Statistics
{
    abstract class CalculationNormalDistributionBase : CalculationDistribution
    {
        public abstract object GetProbabilityLessThan(object a);

        public abstract object GetProbabilityGreaterThan(object a);

        public abstract object GetProbabilityBetween(object a, object b);

        public abstract object GetZArray();

        public abstract object GetValueFromProbability(int probability);

        public abstract object GetZForConfidenceLevel(object confidenceLevel);

        public abstract object GetRandomNormalDistribution(int n, object mean, object sd);

        public abstract object GetConfidenceInterval(double cl);

        public abstract object GetConfidenceInterval(double cl, double s, int n);

        public abstract object GetHypothesisTestingForMean(object m, object sigma, out double lessThan, out double greaterThan);        
    }
}
