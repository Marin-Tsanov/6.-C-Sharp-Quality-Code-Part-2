using System;
using System.Collections.Generic;
using System.Text;
using ExceptionHandling.Contracts;

class ExceptionsHomework : ISubsequence,IExtractEnding,ICheckPrime
{
    public T[] Subsequence<T>(T[] arr, int startIndex, int count)
    {
        List<T> result = new List<T>();

        if (startIndex < 0 || arr.Length - 1 < startIndex)
        {
            throw new ArgumentOutOfRangeException($"StartIndex's value is {startIndex}, it cannot be less than zero or bigger than array's length {arr.Length - 1}.");
        }

        if (startIndex + count > arr.Length)
        {
            throw new ArgumentOutOfRangeException($"The value of startIndex + count is {startIndex + count}, it cannot be bigger than array's length {arr.Length}.");
        }

        for (int i = startIndex; i < startIndex + count; i++)
        {
            result.Add(arr[i]);
        }

        var resultToArray = result.ToArray();

        return resultToArray;
    }

    public string ExtractEnding(string str, int count)
    {
        if (count > str.Length)
        {
            throw new ArgumentOutOfRangeException($"The value of count is {count}, it cannot be bigger than string's length {str.Length}");
        }

        string result = str.Substring(str.Length - count, count);

        return result;
    }

    public/* static*/ void/*string*/ CheckPrime(int number)
    {
        for (int divisor = 2; divisor <= Math.Sqrt(number); divisor++)
        {
            if (number % divisor == 0)
            {
                throw new ArgumentException($"{number} is not prime number.");
            }
        }
    }
}