using SortAlgorithmsConsoleApp.Base;
using System;

namespace SortAlgorithmsConsoleApp.Basic
{
    public class Insertion<T> : SortAlgorithm<T> where T : IComparable<T>
    {
        public Insertion(T[] array) : base(array)
        {
        }

        public override T[] Sort()
        {
            for (int i = 1; i < _array.Length; i++)
            {
                for (int j = i; j > 0 && Less(_array[j], _array[j - 1]); j--)
                {
                    Exchange(j, j - 1);
                }
            }

            return _array;
        }
    }
}
