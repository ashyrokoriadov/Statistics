using System;

namespace Statistics.Implementations
{
    public sealed class StandardDeviation:StatisticsBase
    {
        new CalculationStandardDeviationBase calculation { get; set; }

        #region Constructors
        /// <summary>
        /// A constructor of Standard Deviation class.
        /// </summary>
        /// <param name="data">An array of numbers - acceptable types are double[], float[], int[], decimal[].</param>
        public StandardDeviation(object data)
        {
            GetCalculation(data);
        }
        #endregion

        #region IGetResult invocation
        /// <summary>
        /// A method returns result of a standard deviation calculation.
        /// </summary>
        /// <returns>A calcualtion result as an object.</returns>
        public object GetResult()
        {
            return calculation.GetResult();
        }
        #endregion

        #region CalculationStandardDeviation invocation
        /// <summary>
        /// A method returns result of a sample variance calculation. 
        /// </summary>
        /// <returns>A calcualtion result as an object.</returns>
        public object GetSampleVariance()
        {
            return calculation.GetSampleVariance();
        }

        /// <summary>
        /// A method returns result of an arithmetic mean calculation. 
        /// </summary>
        /// <returns>A calcualtion result as an object.</returns>
        public object GetMean()
        {
            return calculation.GetMean();
        }
        #endregion

        #region Private / Protected members
        protected override void GetCalculation(object data)
        {
            var strongTypeDataDouble = data as double[];

            if (strongTypeDataDouble != null)
            {
                double[] array = strongTypeDataDouble;
                calculation = new StandardDeviationDouble(array);
                variableType = array.GetType();
                return;
            }

            var strongTypeDataInt = data as int[];

            if (strongTypeDataInt != null)
            {
                int[] array = strongTypeDataInt;
                calculation = new StandardDeviationInt(array);
                variableType = array.GetType();
                return;
            }

            var strongTypeDataDecimal = data as decimal[];

            if (strongTypeDataDecimal != null)
            {
                decimal[] array = strongTypeDataDecimal;
                calculation = new StandardDeviationDecimal(array);
                variableType = array.GetType();
                return;
            }

            var strongTypeDataFloat = data as float[];

            if (strongTypeDataFloat != null)
            {
                float[] array = strongTypeDataFloat;
                calculation = new StandardDeviationFloat(array);
                variableType = array.GetType();
                return;
            }

            throw new Exception(TYPE_NOT_SUPPORTED_ERROR_MESSAGE);
        }
        #endregion
    }
}
