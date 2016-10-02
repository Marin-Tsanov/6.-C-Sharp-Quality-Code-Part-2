using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assertions.Contracts
{
    public interface IBinarySearch
    {
        string BinarySearch<T>(T[] arr, T value) where T : IComparable<T>;
    }
}
