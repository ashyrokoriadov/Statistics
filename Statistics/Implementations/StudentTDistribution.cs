using System;

namespace Statistics.Implementations
{
    public sealed class StudentTDistribution : StatisticsBase
    {
        new CalculationStudentTDistributionBase calculation { get; set; }

        #region Constructors
        /// <summary>
        ///  A constructor of NormalDistribution class. 
        /// </summary>
        /// <param name="n">Degrees of freedom. It should be less than 30 and greater then 0.</param>
        /// <param name="t">t value.</param>
        public StudentTDistribution(int n, object t)
        {
            if (n <= 0)
                throw new Exception(TSTUDENT_LESS_THAN_0_ERROR);
            if (n > 30)
                throw new Exception(TSTUDENT_GREATER_THAN_30_ERROR);

            GetCalculation(n, t);
        }
        #endregion

        #region CalculationStudentTDistribution invocation
        /// <summary>
        /// A method returns probability for a given t and n.
        /// </summary>
        /// <returns>A calcualtion result as an object.</returns>
        public object GetProbability()
        {
            return calculation.GetProbability();
        }

        /// <summary>
        /// A method returns probability density for a given t and n.
        /// </summary>
        /// <returns>A calcualtion result as an object.</returns>
        public object GetProbabilityDensity()
        {
            return calculation.GetProbabilityDensity();
        }

        /// <summary>
        /// A method returns T parameter for a given confidence level.
        /// </summary>
        /// <param name="cl">Confidence level. It should be within range [80:90].</param>
        /// <returns>A calcualtion result as an object.</returns>
        public object GetTParameter(double cl)
        {
            return calculation.GetTParameter(cl);
        }

        [Obsolete("The purpose of this method is unknown. Usage of the method at your own risk and resposibility. The method is not tested.")]
        public object GetConfidenceInterval(double cl, double s)
        {
            return calculation.GetConfidenceInterval(cl, s);
        }

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
        /// A method returns T parameter for a given confidence level.
        /// </summary>
        /// <param name="cl">Confidence level. It should be within range [80:90].</param>
        /// <param name="n">Degrees of freedom. It should be less than 30 and greater then 0.</param>
        /// <returns>A calcualtion result as an object.</returns>
        public static object GetTParameter(double cl, int n)
        {
            StudentTDistribution tDistribution = new StudentTDistribution(n, 1.27);
            return tDistribution.GetTParameter(cl);
        }

        [Obsolete("The purpose of this method is unknown. Usage of the method at your own risk and resposibility. The method is not tested.")]
        public static object GetConfidenceInterval(double cl, double s, int n)
        {
            StudentTDistribution tDistribution = new StudentTDistribution(n, 1.27);
            return tDistribution.GetConfidenceInterval(cl, s);
        }

        [Obsolete("The purpose of this method is unknown. Usage of the method at your own risk and resposibility. The method is not tested.")]
        public static object GetTTestValue(double[] array1, double[] array2)
        {
            StudentTDistribution tDistribution = new StudentTDistribution(3, 1.27);
            return tDistribution.GetTTestValue(array1, array2, 3);
        }
        #endregion

        #region Private / Protected Methods
        private void GetCalculation(int n, object t)
        {
            if (t is double)
            {
                calculation = new StudentTDistributionDouble(n, (double)t);
                variableType = typeof(double);
                return;
            }

            if (t is float)
            {
                calculation = new StudentTDistributionFloat(n, (float)t);
                variableType = typeof(double);
                return;
            }

            if (t is decimal)
            {
                calculation = new StudentTDistributionDecimal(n, (decimal)t);
                variableType = typeof(double);
                return;
            }

            throw new Exception(TYPE_NOT_SUPPORTED_ERROR_MESSAGE_NOINT);
        }

        private object GetTTestValue(double[] array1, double[] array2, int n)
        {
            return calculation.GetTTestValue(array1, array2);
        }

        protected override void GetCalculation(object data)
        {
            throw new NotImplementedException();
        }
        #endregion

        [Obsolete("The purpose of this method is unknown. Usage of the method at your own risk and resposibility. The method is not tested.")]
        public object GetHypothesisTestingForMean(object array, object m, object sigma, out object lessThan, out object greaterThan)
        {
            return calculation.GetHypothesisTestingForMean(array, m, sigma, out lessThan, out greaterThan);
        }
    }
}
