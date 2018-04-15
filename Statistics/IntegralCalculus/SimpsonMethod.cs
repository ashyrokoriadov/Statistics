using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Statistics.IntegralCalculus
{
    sealed class SimpsonMethod
    {
        private double[] resultArray;

        public SimpsonMethod(double a, double b, int n, Func<double, double> method)
        {
            this.a = a;
            this.b = b;
            this.n = n;
            this.method = method;
        }

        public SimpsonMethod(double a, double b, int n, double x, double y, Func<double, double, double, double> parameterizedMethod2Parameters)
        {
            this.a = a;
            this.b = b;
            this.n = n;
            this.x = x;
            this.y = y;
            this.parameterizedMethod2Parameters = parameterizedMethod2Parameters;
        }

        private double _a;
        public double a
        {
            get
            {
                return _a;
            }
            set
            {
                _a = value;
            }
        }

        private double _b;
        public double b {
            get
            {
                return _b;
            }
            set
            {
                if (value > _a)
                {
                    _b = value;
                }
                else
                {
                    _b = _a;
                    _a = value;
                }
            }
        }

        private int _n;
        public int n
        {
            get
            {
                return _n;
            }
            set
            {
                if(value >= 0)
                {
                    _n = value;
                }
                else
                {
                    _n = -value;
                }
            }
        }

        private Func<double, double> _method;
        public Func<double, double> method
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

        private Func<double, double, double, double> _parameterizedMethod2Parameters;
        public Func<double, double, double, double> parameterizedMethod2Parameters
        {
            get
            {
                return _parameterizedMethod2Parameters;
            }
            set
            {
                _parameterizedMethod2Parameters = value;
            }
        }

        private double _x;
        public double x
        {
            get
            {
                return _x;
            }
            set
            {
                _x = value;
            }
        }

        private double _y;
        public double y
        {
            get
            {
                return _y;
            }
            set
            {
                _y = value;
            }
        }

        private double _t;
        public double t
        {
            get
            {
                return _t;
            }
            set
            {
                _t = value;
            }
        }

        private double calculateArgument(int i)
        {
            double argument = _a + (_b - _a) * i / (2 * _n);
            return _method(argument);
        }

        private double calculateArgument(int i, double x, double y)
        {
            double argument = _a + (_b - _a) * i / (2 * _n);
            return _parameterizedMethod2Parameters(argument, x, y);
        }

        private double[] segmentsSimpsonMethod()
        {
            double[] result = new double[4];
            result[1] = 0;
            result[2] = 1;

            for (int i = 0; i <= 2 * n; i++)
            {
                if (i == 0)
                    result[0] = calculateArgument(i);

                if (i == 20)
                    result[3] = calculateArgument(i);

                if (i % 2 == 0)
                { result[2] += calculateArgument(i); }
                else
                { result[1] += calculateArgument(i); }

            }
            return result;
        }

        private double[] segmentsSimpsonParameterizedMethod()
        {
            double[] result = new double[4];
            result[1] = 0;
            result[2] = 1;

            for (int i = 0; i <= 2 * n; i++)
            {
                if (i == 0)
                    result[0] = calculateArgument(i, x, y);

                if (i == 2 * n)
                    result[3] = calculateArgument(i, x, y);

                if (i % 2 == 0)
                {
                    result[2] += calculateArgument(i, x, y);
                }
                else
                { result[1] += calculateArgument(i, x, y); }

            }
            return result;
        }

        public double GetResult()
        {
            resultArray = segmentsSimpsonMethod();
            return ((_b - _a) / (6 * _n)) * (resultArray[0] + 4 * resultArray[1] + 2 * resultArray[2] + resultArray[3]);
        }

        public double GetResultParameterizedMethod2Arguments()
        {
            resultArray = segmentsSimpsonParameterizedMethod();
            return ((_b - _a) / (6 * _n)) * (resultArray[0] + 4 * resultArray[1] + 2 * resultArray[2] + resultArray[3]);
        }
    }
}
