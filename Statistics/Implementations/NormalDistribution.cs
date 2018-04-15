using System;

namespace Statistics.Implementations
{
    public sealed class NormalDistribution : StatisticsBase
    {
        new CalculationNormalDistributionBase calculation { get; set; }

        #region Constructors
        /// <summary>
        /// A constructor of NormalDistribution class. 
        /// </summary>
        /// <param name="data">An array of numeric data.</param>
        public NormalDistribution(object data)
        {
            GetCalculation(data);
        }
        #endregion

        #region CalculationBinominalDistribution invocation
        /// <summary>
        /// A method returns result of a sample variance calculation. 
        /// </summary>
        /// <returns>A calcualtion result as an object.</returns>
        public object GetVariance()
        {
            return calculation.GetVariance();
        }

        /// <summary>
        /// A method returns result of a standard deviation calculation.
        /// </summary>
        /// <returns>A calcualtion result as an object.</returns>
        public object GetStandardDeviation()
        {
            return calculation.GetStandardDeviation();
        }

        /// <summary>
        /// A method returns result of an arithmetic mean calculation. 
        /// </summary>
        /// <returns>A calcualtion result as an object.</returns>
        public object GetMean()
        {
            return calculation.GetMean();
        }

        /// <summary>
        /// A method returns result of a probability that a value will be less than a value of a parameter. 
        /// </summary>
        /// <param name="a">A treshold value that will be used to define a probability that other value are less than the treshold.</param>
        /// <returns>A calcualtion result as an object.</returns>
        public object GetProbabilityLessThan(object a)
        {
            return calculation.GetProbabilityLessThan(a);
        }

        /// <summary>
        /// A method returns result of a probability that a value will be greater than a value of a parameter. 
        /// </summary>
        /// <param name="a">A treshold value that will be used to define a probability that other value are greater than the treshold.</param>
        public object GetProbabilityGreaterThan(object a)
        {
            return calculation.GetProbabilityGreaterThan(a);
        }

        /// <summary>
        /// A method returns result of a probability that a value will be within a given range. 
        /// </summary>
        /// <param name="a">A range minimum value.</param>
        /// <param name="b">A range minimum value.</param>
        /// <returns>A calcualtion result as an object.</returns>
        public object GetProbabilityBetween(object a, object b)
        {
            return calculation.GetProbabilityBetween(a, b);
        }

        /// <summary>
        /// A method returns a standard Z array for a given data array.
        /// </summary>
        /// <returns>An object representing a Z array. It could be decumail[], double[] or float[] depending on type used to initialize the class.</returns>
        public object GetZArray()
        {
            return calculation.GetZArray();
        }

        /// <summary>
        /// A method returns a value normal distributed array for a given probability.
        /// </summary>
        /// <param name="probability">An integer value between 0 and 100.</param>
        /// <returns>A calcualtion result as an object. It could be decumail, double or float depending on type used to initialize the class.</returns>
        public object GetValueFromProbability(int probability)
        {
            return calculation.GetValueFromProbability(probability);
        }

        /// <summary>
        /// A method used to calcualte Z value for a confidence interval.
        /// </summary>
        /// <param name="confidenceLevel">A required confidence level - a type should be similar to a type used to initialize the class.</param>
        /// <returns>A Z value for a confidence interval.</returns>
        public object GetZForConfidenceLevel(object confidenceLevel)
        {
            return calculation.GetZForConfidenceLevel(confidenceLevel);
        }

        /// <summary>
        /// A method used to calculate a confidence interval.
        /// </summary>
        /// <param name="cl">A confidence level.</param>
        /// <returns>A confidence inteval.</returns>
        public object GetConfidenceInterval(double cl)
        {
            return calculation.GetConfidenceInterval(cl);
        }
        #endregion

        [Obsolete("The purpose of this method is unknown. Usage of the method at your own risk and resposibility. The method is not tested.")]
        public object GetHypothesisTestingForMean(object m, object sigma, out double lessThan, out double greaterThan)
        {
            return calculation.GetHypothesisTestingForMean(m, sigma, out lessThan, out greaterThan);
        }

        [Obsolete("The purpose of this method is unknown. Usage of the method at your own risk and resposibility. The method is not tested.")]
        public static object GetConfidenceInterval(double cl, double s, int n)
        {
            double[] testArray = new double[2];
            CalculationNormalDistributionBase calculation = new NormalDistributionDouble(testArray);
            return calculation.GetConfidenceInterval(cl, s, n);
        }

        /// <summary>
        /// A static method that returns random values distributed normally
        /// </summary>
        /// <param name="n">A number of values.</param>
        /// <param name="mean">An arithmetic mean.</param>
        /// <param name="sd">A standard deviation</param>
        /// <returns>An array of values distributed normally.</returns>
        public static object GetRandomNormalDistribution(int n, object mean, object sd)
        {
            if(mean is double)
            {
                double[] testArray = new double[2];
                CalculationNormalDistributionBase calculation = new NormalDistributionDouble(testArray);
                return calculation.GetRandomNormalDistribution(n, mean, sd);
            }

            if (mean is float)
            {
                float[] testArray = new float[2];
                CalculationNormalDistributionBase calculation = new NormalDistributionFloat(testArray);
                return calculation.GetRandomNormalDistribution(n, mean, sd);
            }

            if (mean is decimal)
            {
                decimal[] testArray = new decimal[2];
                CalculationNormalDistributionBase calculation = new NormalDistributionDecimal(testArray);
                return calculation.GetRandomNormalDistribution(n, mean, sd);
            }

            throw new Exception(TYPE_NOT_SUPPORTED_ERROR_MESSAGE_NOINT);

        }

        #region Private / Protected members
        protected override void GetCalculation(object data)
        {
            var strongTypeDataDouble= data as double[];

            if (strongTypeDataDouble != null)
            {
                double[] array = strongTypeDataDouble;
                calculation = new NormalDistributionDouble(array);
                variableType = array.GetType();
                return;
            }

            var strongTypeDataDecimal = data as decimal[];

            if (strongTypeDataDecimal != null)
            {
                decimal[] array = strongTypeDataDecimal;
                calculation = new NormalDistributionDecimal(array);
                variableType = array.GetType();
                return;
            }

            var strongTypeDataFloat = data as float[];

            if (strongTypeDataFloat != null)
            {
                float[] array = strongTypeDataFloat;
                calculation = new NormalDistributionFloat(array);
                variableType = array.GetType();
                return;
            }

            throw new Exception(TYPE_NOT_SUPPORTED_ERROR_MESSAGE_NOINT);
        }
        #endregion
    }
}
