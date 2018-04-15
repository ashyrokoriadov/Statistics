
namespace Statistics
{
    abstract class CalculationStudentTDistributionBase : CalculationDistribution
    {
        protected int n;

        protected const string N_GREATER_THAN_1 = "n value has to be greater than 1 in order to calculate mean value";
        protected const string N_GREATER_THAN_2_SD = "n value has to be greater than 2 in order to calculate standard deviation value";
        protected const string N_GREATER_THAN_2_V = "n value has to be greater than 2 in order to calculate variance value";
        protected const string CONFIDENCE_LEVEL = "Confidence level has to be greater than or equal to 80% and less than or equal to 99%";
        protected const string N_NUMBER_ERROR = "n value has to be not greater than 30 and not less than 1 in Student T distribution";

        public abstract object GetProbability();

        public abstract object GetProbabilityDensity();

        public abstract object GetTParameter(double cl);

        public abstract object GetConfidenceInterval(double cl, double s);

        public abstract object GetTParameter(double cl, int n);

        public abstract object GetConfidenceInterval(double cl, double s, int n);

        public abstract object GetTTestValue(object array1, object array2);

        public abstract object GetHypothesisTestingForMean(object array, object m, object sigma, out object lessThan, out object greaterThan);
                
    }
}
