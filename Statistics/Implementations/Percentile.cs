using System;

namespace Statistics.Implementations
{
    public sealed class Percentile : StatisticsBase
    {
        private object data;
        
        #region Constructors
        /// <summary>
        /// A constructor of Percentile class. Using for percentile calculation by the nearest rank method.
        /// </summary>
        /// <param name="data">An array of numbers - acceptable types are double[], float[], int[], decimal[].</param>
        /// <param name="KthPercentile">K-number of a percentile, an integer value between 0 and 100.</param>
        public Percentile(object data, int KthPercentile)
        {
            this.KthPercentile = KthPercentile;
            this.data = data;
            GetCalculation(this.data);            
        }
        #endregion

        #region Properties
        /// <summary>
        /// K-number of a percentile, an integer value between 0 and 100.
        /// </summary>
        private int _KthPercentile;
        public int KthPercentile
        {
            get { return _KthPercentile; }
            set
            {
                if (value >= 0 && value <= 100)
                {
                    _KthPercentile = value;
                    if(calculation != null)
                        GetCalculation(data);
                }
                else
                {
                    throw new Exception(INCORRECT_PERCENTILE_DEFINITION);
                }
            }
        }
        #endregion

        #region IGetResult invocation
        /// <summary>
        /// A method returns result of a percentile calculation based on K-number.
        /// </summary>
        /// <returns>A calcualtion result as an object.</returns>
        public object GetResult()
        {
            return calculation.GetResult();
        }
        #endregion

        #region Private / Protected members
        protected override void GetCalculation(object data)
        {
            var strongTypeDataDouble = data as double[];

            if (strongTypeDataDouble != null)
            {
                double[] array = strongTypeDataDouble;
                calculation = new PercentileDouble(array, KthPercentile);
                variableType = array.GetType();
                return;
            }

            var strongTypeDataInt = data as int[];

            if (strongTypeDataInt != null)
            {
                int[] array = strongTypeDataInt;
                calculation = new PercentileInt(array, KthPercentile);
                variableType = array.GetType();
                return;
            }

            var strongTypeDataDecimal = data as decimal[];

            if (strongTypeDataDecimal != null)
            {
                decimal[] array = strongTypeDataDecimal;
                calculation = new PercentileDecimal(array, KthPercentile);
                variableType = array.GetType();
                return;
            }

            var strongTypeDataFloat = data as float[];

            if (strongTypeDataFloat != null)
            {
                float[] array = strongTypeDataFloat;
                calculation = new PercentileFloat(array, KthPercentile);
                variableType = array.GetType();
                return;
            }

            throw new Exception(TYPE_NOT_SUPPORTED_ERROR_MESSAGE);
        }
        #endregion
    }
}
