using System;

namespace Statistics.Implementations
{
    public sealed class ArithmeticMean : StatisticsBase
    {
        new CalculationArithmeticMean calculation { get; set; }

        #region Constructors
        /// <summary>
        /// A constructor of Arithmetic Mean class.
        /// </summary>
        /// <param name="data">An array of numbers - acceptable types are double[], float[], int[], decimal[].</param>
        public ArithmeticMean(object data)
        {
            GetCalculation(data);
        }
        #endregion

        #region IGetResult invocation
        /// <summary>
        /// A method returns result of an arithmetic mean calculation.
        /// </summary>
        /// <returns>A calcualtion result as an object.</returns>
        public object GetResult()
        {
            return calculation.GetResult();
        }
        #endregion

        #region CalculationArithmeticMean invocation
        /// <summary>
        /// A method returns result of an arithmetic mean calculation. 
        /// </summary>
        /// <param name="method">A predicate method used to filter initial data for calcualtion.</param>
        /// <returns>A calcualtion result as an object.</returns>
        public object GetMeanCondition(Func<object, bool> method)
        {
            calculation.method = method;
            return calculation.GetMeanCondition();
        }

        /// <summary>
        /// A method filters input data.
        /// </summary>
        /// <param name="method">A predicate method used to filter initial data for calcualtion.</param>
        /// <returns>Filtered input data based on predicate parameter.</returns>
        public object GetArrayCondition(Func<object, bool> method)
        {
            calculation.method = method;
            return calculation.GetArrayCondition();
        }

        /// <summary>
        /// A method filters input data.
        /// </summary>
        /// <param name="methodArray">An array of predicate methods used to filter initial data for calcualtion.</param>
        /// <returns>Filtered input data based on predicate parameter.</returns>
        public object GetArrayConditions(Func<object, bool>[] methodArray)
        {
            calculation.methodArray = methodArray;
            return calculation.GetArrayConditions();
        }

        /// <summary>
        /// A method returns result of an arithmetic mean calculation. 
        /// </summary>
        /// <param name="method">A predicate method used to filter initial data for calcualtion.</param>
        /// <returns>A calcualtion result as an object.</returns>
        public object GetMeanConditions(Func<object, bool>[] methodArray)
        {
            calculation.methodArray = methodArray;
            return calculation.GetMeanConditions();
        }
        #endregion

        [Obsolete("The purpose of this method is unknown. Usage of the method at your own risk and resposibility. The method is not tested.")]
        public static object GetTwoMeansEqualTesting(MeanSample sample1, MeanSample sample2, out object lessThan, out object greaterThan)
        {
            ArithmeticMean am = new ArithmeticMean(new double[] { 1.0, 2.0, 3.0 });
            return am.GetTwoMeansEqualTestingPrivate(sample1, sample2, out lessThan, out greaterThan);
        }

        [Obsolete("The purpose of this method is unknown. Usage of the method at your own risk and resposibility. The method is not tested.")]
        public static object GetTwoMeansTesting(MeanSample sample1, MeanSample sample2, out object lessThan, out object greaterThan)
        {
            ArithmeticMean am = new ArithmeticMean(new double[] { 1.0, 2.0, 3.0 });
            return am.GetTwoMeansTestingPrivate(sample1, sample2, out lessThan, out greaterThan);
        }

        #region Private / Protected members
        protected override void GetCalculation(object data)
        {
            var strongTypeDataDouble = data as double[];

            if (strongTypeDataDouble != null)
            {
                double[] array = strongTypeDataDouble;
                calculation = new ArithmeticMeanDouble(array);
                variableType = array.GetType();
                return;
            }

            var strongTypeDataInt = data as int[];

            if (strongTypeDataInt != null)
            {
                int[] array = strongTypeDataInt;
                calculation = new ArithmeticMeanInt(array);
                variableType = array.GetType();
                return;
            }

            var strongTypeDataDecimal = data as decimal[];

            if (strongTypeDataDecimal != null)
            {
                decimal[] array = strongTypeDataDecimal;
                calculation = new ArithmeticMeanDecimal(array);
                variableType = array.GetType();
                return;
            }

            var strongTypeDataFloat = data as float[];

            if (strongTypeDataFloat != null)
            {
                float[] array = strongTypeDataFloat;
                calculation = new ArithmeticMeanFloat(array);
                variableType = array.GetType();
                return;
            }

            throw new Exception(TYPE_NOT_SUPPORTED_ERROR_MESSAGE);
        }

        object GetTwoMeansEqualTestingPrivate(MeanSample sample1, MeanSample sample2, out object lessThan, out object greaterThan)
        {
            return calculation.GetTwoMeansEqualTesting(sample1, sample2, out lessThan, out greaterThan);
        }

        object GetTwoMeansTestingPrivate(MeanSample sample1, MeanSample sample2, out object lessThan, out object greaterThan)
        {
            return calculation.GetTwoMeansTesting(sample1, sample2, out lessThan, out greaterThan);
        }
        #endregion
    }

    /// <summary>
    /// A clas to represent an entity for comparison of 2 means.
    /// </summary>
    public sealed class MeanSample
    {
        private const string INCORRECT_N_ERROR = "Incorrect sample size. Sample size n is less than or equal to 0.";

        public MeanSample(double mean, int sampleQuantity, double meanPopulation, double sigmaPopulation)
        {
            this.sampleQuantity = sampleQuantity;
            this.mean = mean;
            this.meanPopulation = meanPopulation;
            this.sigmaPopulation = sigmaPopulation;
        }

        private int _sampleQuantity;
        public int sampleQuantity
        {
            get
            {
                return _sampleQuantity;
            }
            set
            {
                if (value > 0)
                {
                    _sampleQuantity = value;
                }
                else
                {
                    throw new ArgumentException(INCORRECT_N_ERROR);
                }
            }
        }

        private double _mean;
        public double mean
        {
            get
            {
                return _mean;
            }
            set
            {
                _mean = value;
            }
        }

        private double _meanPopulation;
        public double meanPopulation
        {
            get
            {
                return _meanPopulation;
            }
            set
            {
                _meanPopulation = value;
            }
        }

        private double _sigmaPopulation;
        public double sigmaPopulation
        {
            get
            {
                return _sigmaPopulation;
            }
            set
            {
                _sigmaPopulation = value;
            }
        }
    }
}
