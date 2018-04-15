using System;
using Statistics.Interfaces;
using Statistics.IntegralCalculus;
using Statistics.Implementations;

namespace Statistics
{
    abstract class CalculationArithmeticMean : CalculationBase
    {
        public abstract object GetMeanCondition();

        public abstract object GetArrayCondition();

        public abstract object GetMeanConditions();

        public abstract object GetArrayConditions();

        private Func<object, bool> _method;
        public Func<object, bool> method
        {
            get
            {
                return _method;
            }
            set
            {
                _method = value;
            }
        }

        private Func<object, bool>[] _methodArray;
        public Func<object, bool>[] methodArray
        {
            get
            {
                return _methodArray;
            }
            set
            {
                _methodArray = value;
            }
        }
    }
}
