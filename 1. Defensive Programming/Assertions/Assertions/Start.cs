using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefensiveProgramming
{
    class Start
    {
        public static void Main()
        {
            Assertion assertion = new Assertion();
            int[] arr = new int[] { 3, -1, 15, 4, 17, 2, 33, 0 };
            Console.WriteLine("The original array is = [{0}]", string.Join(", ", arr));
            assertion.SelectionSort(arr);
            Console.WriteLine("The sorted array is = [{0}]", string.Join(", ", arr));

            assertion.SelectionSort(new int[0]); // Test sorting empty array
            assertion.SelectionSort(new int[1]); // Test sorting single element array

            Console.WriteLine(assertion.BinarySearch(arr, -1000));
            Console.WriteLine(assertion.BinarySearch(arr, 0));
            Console.WriteLine(assertion.BinarySearch(arr, 17));
            Console.WriteLine(assertion.BinarySearch(arr, 10));
            Console.WriteLine(assertion.BinarySearch(arr, 1000));
        }
    }
}