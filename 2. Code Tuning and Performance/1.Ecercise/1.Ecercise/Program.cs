using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace _1.Ecercise
{
    // Measure the amount of time for the programm needed
    class Program
    {
        static void Main(string[] args)
        {
            var a = new int[10];

            for (int outTimes = 0; outTimes < 10; outTimes++)
            {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            for (int times = 0; times < 1000000; times++)
            {
                    //for (int i = 0; i < 10; i++)
                    //{
                    //    a[i] = i;
                    //}

                    a[0] = 0;
                    a[1] = 1;
                    a[2] = 2;
                    a[3] = 3;
                    a[4] = 4;
                    a[5] = 5;
                    a[6] = 6;
                    a[7] = 7;
                    a[8] = 8;
                    a[9] = 9;
                }

            sw.Stop();
            Console.WriteLine(sw.Elapsed);

            }
        }
    }
}
