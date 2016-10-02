using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assertions.Contracts
{
    public interface ISelectionSort
    {
        void SelectionSort<T>(T[] arr) where T : IComparable<T>;
    }
}
