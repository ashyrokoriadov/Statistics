using System;

namespace Statistics.Implementations
{
    public sealed class BinominalDistribution : StatisticsBase
    {
        new CalculationBinominalDistributionBase calculation { get; set; }

        #region Constructors
        /// <summary>
        /// A constructor of BinominalDistribution class. 
        /// </summary>
        /// <param name="n">A number of samples.</param>
        /// <param name="x">A number of successful samples. It should be less or equal to n.</param>
        /// <param name="p">A probability of success in a sample.</param>
        public BinominalDistribution(int n, int x, object p)
        {
            if (x > n)
                throw new Exception(BINOMINAL_X_N_ERROR);

            GetCalculation(n, x, p);
        }
        #endregion

        #region CalculationBinominalDistribution invocation
        /// <summary>
        /// A method to calculate a possible combination's number of x successes from n trials.
        /// </summary>
        /// <returns>A possible combination's number of x successes from n trials. It could ecimael, double or float dending of o typs used for a class BinominalDistribution initialization.</returns>
        public object GetCombinationNumber()
        {
            return calculation.GetCombinationNumber();
        }

        /// <summary>
        /// A method to calculate a probability for a certain x success number (x is set during a class BinominalDistribution initialization).
        /// </summary>
        /// <returns>A probability of x sucesses in a given binominal distribution.</returns>
        public object GetProbability()
        {
            return calculation.GetProbability();
        }

        [Obsolete("The purpose of this method is unknown. Usage of the method at your own risk and resposibility. The method is not tested.")]
        public object GetProbabilityRange(object range)
        {
            return calculation.GetProbabilityRange(range);
        }

        [Obsolete("The purpose of this method is unknown. Usage of the method at your own risk and resposibility. The method is not tested.")]
        public object GetProbabilityReverse(double criterion)
        {
            return calculation.GetProbabilityReverse(criterion);
        }

        [Obsolete("The purpose of this method is unknown. Usage of the method at your own risk and resposibility. The method is not tested.")]
        public object GetCumulativeDistribution(int criterion)
        {
            return calculation.GetCumulativeDistribution(criterion);
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
        #endregion

        [Obsolete("The purpose of this method is unknown. Usage of the method at your own risk and resposibility. The method is not tested.")]
        public object GetHypothesisTestingForPercentage(object p0, out object lessThan, out object greaterThan)
        {
            return calculation.GetHypothesisTestingForPercentage(p0, out lessThan, out greaterThan);
        }

        [Obsolete("The purpose of this method is unknown. Usage of the method at your own risk and resposibility. The method is not tested.")]
        public static double GetTwoPercentageTesting(BinominalSample sample1, BinominalSample sample2, out object lessThan, out object greaterThan)
        {
            BinominalDistribution bd = new BinominalDistribution(10, 5, 0.5);
            return (double)bd.GetTwoPercentageTestingPrivate(sample1, sample2, out lessThan, out greaterThan);
        }

        [Obsolete("The purpose of this method is unknown. Usage of the method at your own risk and resposibility. The method is not tested.")]
        public static double GetTwoPercentageEqualTesting(BinominalSample sample1, BinominalSample sample2, out object lessThan, out object greaterThan)
        {
            BinominalDistribution bd = new BinominalDistribution(10, 5, 0.5);
            return (double)bd.GetTwoPercentageEqualTestingPrivate(sample1, sample2, out lessThan, out greaterThan);
        }

        #region Private / Protected members
        object GetTwoPercentageTestingPrivate(BinominalSample sample1, BinominalSample sample2, out object lessThan, out object greaterThan)
        {
            return calculation.GetTwoPercentageTesting(sample1, sample2, out lessThan, out greaterThan);
        }

        object GetTwoPercentageEqualTestingPrivate(BinominalSample sample1, BinominalSample sample2, out object lessThan, out object greaterThan)
        {
            return calculation.GetTwoPercentageEqualTesting(sample1, sample2, out lessThan, out greaterThan);
        }

        void GetCalculation(int n, int x, object p)
        {
            if (p is double)
            {
                calculation = new BinominalDistributionDouble(n, x, (double)p);
                variableType = typeof(double);
                return;
            }

            if (p is decimal)
            {
                calculation = new BinominalDistributionDecimal(n, x, (decimal)p);
                variableType =typeof(decimal);
                return;
            }

            if (p is float)
            {
                calculation = new BinominalDistributionFloat(n, x, (float)p);
                variableType = typeof(float);
                return;
            }

            throw new Exception(BINOMINAL_TYPE_NOT_SUPPORTED_ERROR);
        }

        protected override void GetCalculation(object data)
        {
            throw new NotImplementedException();
        }
        #endregion
    }

    public sealed class BinominalSample
    {
        private const string INCORRECT_N_ERROR = "Incorrect sample size. Sample size n is less than or equal to 0.";
        private const string INCORRECT_N_FEATURE_ERROR = "Incorrect fature sample size. Feature sample size has to be less than sample size.";
        private const string INCORRECT_P_ERROR = "Incorrect p value. Testing p value has to be within interval [0:1].";

        public BinominalSample(int nTotal, int nFeature)
        {
            this.nTotal = nTotal;
            this.nFeature = nFeature;
        }

        public BinominalSample(int nTotal, int nFeature, double p)
        {
            this.nTotal = nTotal;
            this.nFeature = nFeature;
            this.p = p;
        }

        private int _nTotal;
        public int nTotal
        {
            get
            {
                return _nTotal;
            }
            set
            {
                if (value > 0)
                {
                    _nTotal = value;
                }
                else
                {
                    throw new ArgumentException(INCORRECT_N_ERROR);
                }
            }
        }

        private int _nFeature;
        public int nFeature
        {
            get
            {
                return _nFeature;
            }
            set
            {
                if (value > 0)
                {
                    if(value<_nTotal)
                    {
                        _nFeature = value;
                    }
                    else
                    {
                        throw new ArgumentException(INCORRECT_N_FEATURE_ERROR);
                    }
                    
                }
                else
                {
                    throw new ArgumentException(INCORRECT_N_ERROR);
                }
            }
        }

        public double testingP
        {
            get
            {
                return Convert.ToDouble(nFeature) / Convert.ToDouble(nTotal);
            }
        }

        private double _p;
        public double p
        {
            get
            {
                return _p;
            }
            set
            {
                if (value >= 0 && value <= 1)
                {
                    _p = value;
                }
                else
                {
                    throw new ArgumentException(INCORRECT_P_ERROR);
                }
            }
        }
    }
}
