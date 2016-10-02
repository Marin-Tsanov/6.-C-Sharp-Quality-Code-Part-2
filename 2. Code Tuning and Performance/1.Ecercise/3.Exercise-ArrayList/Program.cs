using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Exercise_Memory
{
    class Program
    {
        static void Main(string[] args)
        {
            // 

            MeasureTime();
        }

        public static void MeasureTime()
        {
            var a = 0;

            for (int outTimes = 0; outTimes < 10; outTimes++)
            {
                Stopwatch sw = new Stopwatch();
                sw.Start();
                //var list = new List<int>();
                 var list = new HashSet<int>();

                for (int times = 0; times < 10000; times++)
                {
                    list.Add(times);
                }

                int count = 0;
                for (int times = 0; times < 20000; times++)
                {
                    if (list.Contains(times))
                    {
                        count++;
                    }
                }
                
                sw.Stop();
                Console.WriteLine(count);
                Console.WriteLine(sw.Elapsed);
            }
        }
    }
}