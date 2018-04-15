using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Statistics
{
    public abstract class StatisticsBase
    {
        protected Type variableType { get; set; }

        protected CalculationBase calculation { get; set; }

        #region Constants
        protected const string CONVERT_FUNCTION_ERROR_MESSAGE = "Type is not supported. Supported types are decimal[], double[], float[], int[].";
        protected const string TYPE_NOT_SUPPORTED_ERROR_MESSAGE = "Type is not supported. Supported types are Decimal, Double, Single, Int32.";
        protected const string TYPE_NOT_SUPPORTED_ERROR_MESSAGE_ARRAY = "Type is not supported. Supported types are Decimal[], Double[], Single[], Int32[].";
        protected const string TYPE_NOT_SUPPORTED_ERROR_MESSAGE_NOINT = "Type is not supported. Supported types are Decimal, Double, Single.";
        protected const string TYPE_NOT_SUPPORTED_ERROR_MESSAGE_NOINT_ARRAY = "Type is not supported. Supported types are Decimal[], Double[], Single[].";
        protected const string GENERAL_ERROR_MESSAGE = "An error occured while executing a method.";
        protected const string INCORRECT_PERCENTILE_DEFINITION = "Incorrect percentile definition. The K-th percentile value has to be integer and within scope from 0 to 100.";
        protected const string BINOMINAL_X_N_ERROR = "Value x has to be less than or equal to value n.";
        protected const string BINOMINAL_TYPE_NOT_SUPPORTED_ERROR = "Type is not supported. Supported types are Decimal, Double, Single.";
        protected const string TSTUDENT_LESS_THAN_0_ERROR = "Incorrect sample size. Sample size n is less than or equal to 0.";
        protected const string TSTUDENT_GREATER_THAN_30_ERROR = "Incorrect sample size. Sample size n is greater than 30. Please use Normal Distribution class.";
        #endregion

        protected abstract void GetCalculation(object data);
        
    }
}
