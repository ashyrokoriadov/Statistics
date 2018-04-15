
namespace Statistics
{
    abstract class CalculationCorrelation : CalculationBase
    {
        public abstract object GetCorrelationRatio();

        public abstract void GetGreatFive(out object mean1, out object mean2, out object sigma1, out object sigma2, out object r);

        public abstract void GetLinearEquationCoefficient(out object m, out object b);
    }
}
