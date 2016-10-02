using System;
using System.Linq;
using System.Diagnostics;
using Assertions.Contracts;

public class Assertion : ISelectionSort, IBinarySearch
{
    public void SelectionSort<T>(T[] arr) where T : IComparable<T>
    {
        for (int index = 0; index < arr.Length - 1; index++)
        {
            int minElementIndex = FindMinElementIndex(arr, index, arr.Length - 1);
            Swap(ref arr[index], ref arr[minElementIndex]);
        }
    }

    private int FindMinElementIndex<T>(T[] arr, int startIndex, int endIndex)
        where T : IComparable<T>
    {
        Debug.Assert((0 <= startIndex && startIndex <= arr.Length - 1),
              "The value of startIndex must be bigger than zero and less than the arr's lenght.");
        Debug.Assert((0 <= endIndex && endIndex <= arr.Length - 1),
                    "The value of endIndex must be bigger than zero and less than the arr's lenght.");
        Debug.Assert(startIndex + 1 <= endIndex,
                    "The value of startIndex + 1 must be greater or equal to the value of the endIndex.");

        int minElementIndex = startIndex;

        for (int i = startIndex + 1; i <= endIndex; i++)
        {
            if (arr[i].CompareTo(arr[minElementIndex]) < 0)
            {
                minElementIndex = i;
            }
        }
        return minElementIndex;
    }

    private void Swap<T>(ref T x, ref T y)
    {
        T oldX = x;
        x = y;
        y = oldX;
    }

    public string BinarySearch<T>(T[] arr, T value) where T : IComparable<T>
    {
        return BinarySearch(arr, value, 0, arr.Length - 1);
    }

    private string BinarySearch<T>(T[] arr, T value, int startIndex, int endIndex)
        where T : IComparable<T>
    {
        Debug.Assert(0 <= startIndex,
                    "The value of the startIndex cannot be less, than 0.");
        Debug.Assert((0 <= endIndex && endIndex <= arr.Length - 1),
                    "The value of endIndex must be bigger than zero and less than the arr's lenght.");
        Debug.Assert(startIndex <= endIndex,
                    "The value of the startIndex should be equal or less to the value of the endIndex.");

        while (startIndex <= endIndex)
        {
            int midIndex = (startIndex + endIndex) / 2;

            if (arr[midIndex].Equals(value))
            {
                return $"The value {value} was found at index {midIndex}.";
            }

            if (arr[midIndex].CompareTo(value) < 0)
            {
                // Search on the right half
                startIndex = midIndex + 1;
            }
            else
            {
                // Search on the left half
                endIndex = midIndex - 1;
            }
        }

        // Searched value not found
        return $"The value {value} was not found.";
    }
}