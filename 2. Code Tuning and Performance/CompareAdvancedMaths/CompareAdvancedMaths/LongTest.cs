namespace Homework
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    using System.Threading;

    public class LongTest
    {
        public const long LongVariableNumber = 1L;
        public const int StartNumber = 0;
        public const int NumberOfTimes = 10000;
        private Stopwatch stopwatch = new Stopwatch();

        public delegate T LongDelegate<T>(T a);

        public T AddNumber<T>(T x)
        {
            dynamic a = x;

            a = a + LongVariableNumber;

            return a;
        }

        public T SubtractNumber<T>(T y)
        {
            dynamic a = y;

            a = a - LongVariableNumber;

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

            a = a * LongVariableNumber;

            return a;
        }

        public T Divide<T>(T v)
        {
            dynamic a = v;

            a = a / LongVariableNumber;

            return a;
        }

        public void MeasureTime<T>(T a, LongDelegate<T> del)
        {
            this.stopwatch.Reset();
            this.stopwatch.Start();

            for (int times = StartNumber; times < NumberOfTimes; times++)
            {
                a = del(a);
            }

            this.stopwatch.Stop();
        }

        public void StartLongTest()
        {
            LongTest test = new LongTest();

            test.MeasureTime(StartNumber, new LongTest.LongDelegate<long>(test.AddNumber));
            Console.WriteLine($"The time for performing the Add operation with long value 10,000 times is {test.stopwatch.Elapsed}");

            test.MeasureTime(StartNumber, new LongTest.LongDelegate<long>(test.SubtractNumber));
            Console.WriteLine($"The time for performing the Substract operation with long value 10,000 times is {test.stopwatch.Elapsed}");

            test.MeasureTime(StartNumber, new LongTest.LongDelegate<long>(test.SubtractNumber));
            Console.WriteLine($"The time for performing the Increment operation with long value 10,000 times is {test.stopwatch.Elapsed}");

            test.MeasureTime(StartNumber, new LongTest.LongDelegate<long>(test.Multiply));
            Console.WriteLine($"The time for performing the Multiply operation with long value 10,000 times is {test.stopwatch.Elapsed}");

            test.MeasureTime(StartNumber, new LongTest.LongDelegate<long>(test.Divide));
            Console.WriteLine($"The time for performing the Divide operation with long value 10,000 times is {test.stopwatch.Elapsed}");
        }
    }
}