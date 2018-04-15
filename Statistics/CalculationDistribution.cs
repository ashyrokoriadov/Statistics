using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Statistics
{
    abstract class CalculationDistribution : CalculationBase
    {
        protected const string ERROR_ARGUMENT_DOUBLE = "Expected type of an argument is double";
        protected const string ERROR_ARGUMENT_DOUBLE_ARRAY = "Expected type of an argument is double[]";
        protected const string ERROR_ARGUMENT_DECIMAL = "Expected type of an argument is decimal";
        protected const string ERROR_ARGUMENT_DECIMAL_ARRAY = "Expected type of an argument is decimal[]";
        protected const string ERROR_ARGUMENT_FLOAT = "Expected type of an argument is float";
        protected const string ERROR_ARGUMENT_FLOAT_ARRAY = "Expected type of an argument is float[]";
        protected const string ERROR_ARGUMENT_N_NUMBER = "n value has to be not greater than 100 and not less than 0";

        public override object GetResult()
        {
            throw new NotImplementedException();
        }

        public abstract object GetMean();

        public abstract object GetStandardDeviation();

        public abstract object GetVariance();

        protected bool IsDouble(object a)
        {
            Type type = a.GetType();

            switch (type.ToString())
            {
                case "System.Double":
                case "System.Int32":
                    return true;
                default:
                    return false;
            }
        }

        protected bool IsDecimal(object a)
        {
            if (a.GetType() == typeof(decimal))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        protected bool IsFloat(object a)
        {
            if (a.GetType() == typeof(float))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        protected bool IsDoubleArray(object a)
        {
            if (a.GetType() == typeof(double[]))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        protected bool IsDecimalArray(object a)
        {
            if (a.GetType() == typeof(decimal[]))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        protected bool IsFloatArray(object a)
        {
            if (a.GetType() == typeof(float[]))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
