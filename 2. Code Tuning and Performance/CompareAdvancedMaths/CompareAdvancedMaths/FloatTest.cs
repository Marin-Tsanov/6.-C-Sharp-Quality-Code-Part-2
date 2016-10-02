namespace Homework
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    using System.Threading;

    public class FloatTest
    {
        public const float FloatVariableNumber = 1F;
        public const int StartNumber = 0;
        public const float NumberOfTimes = 10000;
        private Stopwatch stopwatch = new Stopwatch();

        public delegate T FloatDelegate<T>(T a);

        public T AddNumber<T>(T x)
        {
            dynamic a = x;

            a = a + FloatVariableNumber;

            return a;
        }

        public T SubtractNumber<T>(T y)
        {
            dynamic a = y;

            a = a - FloatVariableNumber;

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

            a = a * FloatVariableNumber;

            return a;
        }

        public T Divide<T>(T v)
        {
            dynamic a = v;

            a = a / FloatVariableNumber;

            return a;
        }

        public void MeasureTime<T>(T a, FloatDelegate<T> del)
        {
            this.stopwatch.Reset();
            this.stopwatch.Start();

            for (int times = StartNumber; times < NumberOfTimes; times++)
            {
                a = del(a);
            }

            this.stopwatch.Stop();
        }

        public void StartFloatTest()
        {
            FloatTest test = new FloatTest();

            test.MeasureTime(StartNumber, new FloatTest.FloatDelegate<float>(test.AddNumber));
            Console.WriteLine($"The time for performing the Add operation with float value 10,000 times is {test.stopwatch.Elapsed}");

            test.MeasureTime(StartNumber, new FloatTest.FloatDelegate<float>(test.SubtractNumber));
            Console.WriteLine($"The time for performing the Substract operation with float value 10,000 times is {test.stopwatch.Elapsed}");

            test.MeasureTime(StartNumber, new FloatTest.FloatDelegate<float>(test.SubtractNumber));
            Console.WriteLine($"The time for performing the Increment operation with float value 10,000 times is {test.stopwatch.Elapsed}");

            test.MeasureTime(StartNumber, new FloatTest.FloatDelegate<float>(test.Multiply));
            Console.WriteLine($"The time for performing the Multiply operation with float value 10,000 times is {test.stopwatch.Elapsed}");

            test.MeasureTime(StartNumber, new FloatTest.FloatDelegate<float>(test.Divide));
            Console.WriteLine($"The time for performing the Divide operation with float value 10,000 times is {test.stopwatch.Elapsed}");
        }
    }
}