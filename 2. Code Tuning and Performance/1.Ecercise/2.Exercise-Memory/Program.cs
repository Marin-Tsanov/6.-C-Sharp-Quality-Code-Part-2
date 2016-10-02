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
            // The result, which will be received is in bytes

            var memory = GC.GetTotalMemory(true); // Garbage collector gives total memory with actual data
            var list = new List<int>(); // list is the more dinamyc data structure
            for (int i = 0; i < 1000; i++)
            {
                list.Add(i);
            }
            var memoryAfter = GC.GetTotalMemory(true);
            Console.WriteLine(memoryAfter - memory);
            Console.WriteLine(list[0]); // this is done, because GC will see, that we are not using the list anymore and will delete it, we prevent it to be deleted.
        }

        public static void MeasureTime()
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
