namespace Homework
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    using System.Threading;

    public class DoubleTest
    {
        public const double DoubleVariableNumber = 1D;
        public const int StartNumber = 0;
        public const int NumberOfTimes = 10000;
        private Stopwatch stopwatch = new Stopwatch();

        public delegate T DoubleDelegate<T>(T a);

        public T AddNumber<T>(T x)
        {
            dynamic a = x;

            a = a + DoubleVariableNumber;

            return a;
        }

        public T SubtractNumber<T>(T y)
        {
            dynamic a = y;

            a = a - DoubleVariableNumber;

            return a;
        }

        public T Increment<T>(T z)
        {
            dynamic a = z;

            a = ++a;

            return a;
        }

        public T Multiply<T>(T w)
        {
            dynamic a = w;

            a = a * DoubleVariableNumber;

            return a;
        }

        public T Divide<T>(T v)
        {
            dynamic a = v;

            a = a / DoubleVariableNumber;

            return a;
        }

        public void MeasureTime<T>(T a, DoubleDelegate<T> del)
        {
            this.stopwatch.Reset();
            this.stopwatch.Start();

            for (int times = StartNumber; times < NumberOfTimes; times++)
            {
                a = del(a);
            }

            this.stopwatch.Stop();
        }

        public void StartDoubleTest()
        {
            DoubleTest test = new DoubleTest();

            test.MeasureTime(0, new DoubleTest.DoubleDelegate<double>(test.AddNumber));
            Console.WriteLine($"The time for performing the Add operation with double value 10,000 times is {test.stopwatch.Elapsed}");

            test.MeasureTime(0, new DoubleTest.DoubleDelegate<double>(test.SubtractNumber));
            Console.WriteLine($"The time for performing the Substract operation with double value 10,000 times is {test.stopwatch.Elapsed}");

            test.MeasureTime(0, new DoubleTest.DoubleDelegate<double>(test.SubtractNumber));
            Console.WriteLine($"The time for performing the Increment operation with double value 10,000 times is {test.stopwatch.Elapsed}");

            test.MeasureTime(0, new DoubleTest.DoubleDelegate<double>(test.Multiply));
            Console.WriteLine($"The time for performing the Multiply operation with double value 10,000 times is {test.stopwatch.Elapsed}");

            test.MeasureTime(0, new DoubleTest.DoubleDelegate<double>(test.Divide));
            Console.WriteLine($"The time for performing the Divide operation with double value 10,000 times is {test.stopwatch.Elapsed}");
        }
    }
}
