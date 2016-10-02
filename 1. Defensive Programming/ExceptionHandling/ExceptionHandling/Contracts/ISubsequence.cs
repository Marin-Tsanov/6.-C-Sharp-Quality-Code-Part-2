using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionHandling.Contracts
{
    public interface ISubsequence
    {
        T[] Subsequence<T>(T[] arr, int startIndex, int count);
    }
}
