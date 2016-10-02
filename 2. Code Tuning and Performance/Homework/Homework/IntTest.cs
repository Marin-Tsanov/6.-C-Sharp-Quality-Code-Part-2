namespace Homework
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    using System.Threading;

    public class IntTest
    {
        public const int IntVariableNumber = 1;
        public const int StartNumber = 0;
        public const int NumberOfTimes = 10000;
        private Stopwatch stopwatch = new Stopwatch();

        public delegate T IntDelegate<T>(T a);

        public T AddNumber<T>(T x)
        {
            dynamic a = x;

            a = a + IntVariableNumber;

            return a;
        }

        public T SubtractNumber<T>(T y)
        {
            dynamic a = y;

            a = a - IntVariableNumber;

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

            a = a * IntVariableNumber;

            return a;
        }

        public T Divide<T>(T v)
        {
            dynamic a = v;

            a = a / IntVariableNumber;

            return a;
        }

        ////public void MeasureTimeAdd()
        ////{
        ////    int a = 0;
        ////    stopwatch.Reset();
        ////    stopwatch.Start();

        ////    for (int times = 0; times < 10000; times++)
        ////    {
        ////        a = AddNumber(a);   
        ////    }

        ////    stopwatch.Stop();
        ////}

        public void MeasureTime<T>(T a, IntDelegate<T> del)
        {
            this.stopwatch.Reset();
            this.stopwatch.Start();

            for (int times = StartNumber; times < NumberOfTimes; times++)
            {
                a = del(a);
            }

            this.stopwatch.Stop();
        }

        ////public void MeasureTimeSubstract()
        ////{
        ////    int a = 0;
        ////    stopwatch.Reset();
        ////    stopwatch.Start();

        ////    for (int times = 0; times < 10000; times++)
        ////    {
        ////        a = SubtractNumber(a);
        ////    }

        ////    stopwatch.Stop();
        ////}

        ////public void MeasureTimeIncrement()
        ////{
        ////    int a = 0;
        ////    stopwatch.Reset();
        ////    stopwatch.Start();

        ////    for (int times = 0; times < 10000; times++)
        ////    {
        ////        a = Increment(a);
        ////    }

        ////    stopwatch.Stop();
        ////}

        ////public void MeasureTimeMultiply()
        ////{
        ////    int a = 0;
        ////    stopwatch.Reset();
        ////    stopwatch.Start();

        ////    for (int times = 0; times < 10000; times++)
        ////    {
        ////        a = Multiply(a);
        ////    }

        ////    stopwatch.Stop();
        ////}

        ////public void MeasureTimeDivide()
        ////{
        ////    int a = 0;
        ////    stopwatch.Reset();
        ////    stopwatch.Start();

        ////    for (int times = 0; times < 10000; times++)
        ////    {
        ////        a = Divide(a);
        ////    }

        ////    stopwatch.Stop();
        ////}

        public void StartIntTest()
        {
            IntTest test = new IntTest();

            test.MeasureTime(StartNumber, new IntTest.IntDelegate<int>(test.AddNumber));
            Console.WriteLine($"The time for performing the Add operation with int value 10,000 times is {test.stopwatch.Elapsed}");

            test.MeasureTime(StartNumber, new IntTest.IntDelegate<int>(test.SubtractNumber));
            Console.WriteLine($"The time for performing the Substract operation with int value 10,000 times is {test.stopwatch.Elapsed}");

            test.MeasureTime(StartNumber, new IntTest.IntDelegate<int>(test.SubtractNumber));
            Console.WriteLine($"The time for performing the Increment operation with int value 10,000 times is {test.stopwatch.Elapsed}");

            test.MeasureTime(StartNumber, new IntTest.IntDelegate<int>(test.Multiply));
            Console.WriteLine($"The time for performing the Multiply operation with int value 10,000 times is {test.stopwatch.Elapsed}");

            test.MeasureTime(StartNumber, new IntTest.IntDelegate<int>(test.Divide));
            Console.WriteLine($"The time for performing the Divide operation with int value 10,000 times is {test.stopwatch.Elapsed}");
        }
    }
}
