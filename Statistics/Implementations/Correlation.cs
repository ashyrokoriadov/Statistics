using System;

namespace Statistics.Implementations
{
    public class Correlation : StatisticsBase
    {
        new CalculationCorrelation calculation { get; set; }

        #region Constructors
        /// <summary>
        /// A constructor of Standard Deviation class.
        /// </summary>
        /// <param name="array1">An array of numbers - acceptable types are double[], float[], decimal[].</param>
        /// <param name="array2">An array of numbers - acceptable types are double[], float[], decimal[].</param>
        public Correlation(object array1, object array2)
        {
            GetCalculation(array1, array2);
        }
        #endregion

        #region Private / Protected members
        protected void GetCalculation(object array1, object array2)
        {
            var strongTypeDataDouble1 = array1 as double[];
            var strongTypeDataDouble2 = array2 as double[];

            if (strongTypeDataDouble1 != null && strongTypeDataDouble2 != null)
            {
                double[] arrayDouble1 = strongTypeDataDouble1;
                double[] arrayDouble2 = strongTypeDataDouble2;
                calculation = new CorrelationDouble(arrayDouble1, arrayDouble2);
                variableType = arrayDouble1.GetType();
                return;
            }

            var strongTypeDataFloat1 = array1 as float[];
            var strongTypeDataFloat2 = array2 as float[];

            if (strongTypeDataFloat1 != null && strongTypeDataFloat2 != null)
            {
                float[] arrayFloat1 = strongTypeDataFloat1;
                float[] arrayFloat2 = strongTypeDataFloat2;
                calculation = new CorrelationFloat(arrayFloat1, arrayFloat2);
                variableType = arrayFloat1.GetType();
                return;
            }

            var strongTypeDataDecimal1 = array1 as decimal[];
            var strongTypeDataDecimal2 = array2 as decimal[];

            if (strongTypeDataDecimal1 != null && strongTypeDataDecimal2 != null)
            {
                decimal[] arrayDecimal1 = strongTypeDataDecimal1;
                decimal[] arrayDecimal2 = strongTypeDataDecimal2;
                calculation = new CorrelationDecimal(arrayDecimal1, arrayDecimal2);
                variableType = arrayDecimal1.GetType();
                return;
            }

            throw new Exception(TYPE_NOT_SUPPORTED_ERROR_MESSAGE_NOINT_ARRAY);
        }

        protected override void GetCalculation(object data)
        {
            throw new NotImplementedException();
        }
        #endregion

        /// <summary>
        /// A method that calculates a corellation ratio.
        /// </summary>
        /// <returns>An object reprenting corellation ratio.</returns>
        public object GetCorrelaionRatio()
        {
            return calculation.GetCorrelationRatio();
        }

        /// <summary>
        /// A method that calculates a "great statistical five".
        /// </summary>
        /// <param name="mean1">A mean of the 1st array.</param>
        /// <param name="mean2">A mean of the 2nd array.</param>
        /// <param name="sigma1">A standard deviation of the 1st array.</param>
        /// <param name="sigma2">A standard deviation of the 2nd array.</param>
        /// <param name="r">A correlation ratio.</param>
        public void GetGreatFive(out object mean1, out object mean2, out object sigma1, out object sigma2, out object r)
        {
            calculation.GetGreatFive(out mean1, out mean2, out sigma1, out sigma2, out r);
        }

        [Obsolete("The purpose of this method is unknown. Usage of the method at your own risk and resposibility. The method is not tested.")]
        public void GetLinearEquationCoefficient(out object m, out object b)
        {
            calculation.GetLinearEquationCoefficient(out m, out b);
        }
    }
}
