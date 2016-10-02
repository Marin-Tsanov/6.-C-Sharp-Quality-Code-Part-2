namespace Homework
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    using System.Threading;

    public class DecimalTest
    {
        public const decimal DecimalVariableNumber = 1M;
        public const int StartNumber = 0;
        public const int NumberOfTimes = 10000;
        private Stopwatch stopwatch = new Stopwatch();

        public delegate T DecimalDelegate<T>(T a);

        public T AddNumber<T>(T x)
        {
            dynamic a = x;

            a = a + DecimalVariableNumber;

            return a;
        }

        public T SubtractNumber<T>(T y)
        {
            dynamic a = y;

            a = a - DecimalVariableNumber;

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

            a = a * DecimalVariableNumber;

            return a;
        }

        public T Divide<T>(T v)
        {
            dynamic a = v;

            a = a / DecimalVariableNumber;

            return a;
        }

        public void MeasureTime<T>(T a, DecimalDelegate<T> del)
        {
            this.stopwatch.Reset();
            this.stopwatch.Start();

            for (int times = StartNumber; times < NumberOfTimes; times++)
            {
                a = del(a);
            }

            this.stopwatch.Stop();
        }

        public void StartDecimalTest()
        {
            DecimalTest test = new DecimalTest();

            test.MeasureTime(StartNumber, new DecimalTest.DecimalDelegate<decimal>(test.AddNumber));
            Console.WriteLine($"The time for performing the Add operation with decimal value 10,000 times is {test.stopwatch.Elapsed}");

            test.MeasureTime(StartNumber, new DecimalTest.DecimalDelegate<decimal>(test.SubtractNumber));
            Console.WriteLine($"The time for performing the Substract operation with decimal value 10,000 times is {test.stopwatch.Elapsed}");

            test.MeasureTime(StartNumber, new DecimalTest.DecimalDelegate<decimal>(test.SubtractNumber));
            Console.WriteLine($"The time for performing the Increment operation with decimal value 10,000 times is {test.stopwatch.Elapsed}");

            test.MeasureTime(StartNumber, new DecimalTest.DecimalDelegate<decimal>(test.Multiply));
            Console.WriteLine($"The time for performing the Multiply operation with decimal value 10,000 times is {test.stopwatch.Elapsed}");

            test.MeasureTime(StartNumber, new DecimalTest.DecimalDelegate<decimal>(test.Divide));
            Console.WriteLine($"The time for performing the Divide operation with decimal value 10,000 times is {test.stopwatch.Elapsed}");
        }
    }
}
