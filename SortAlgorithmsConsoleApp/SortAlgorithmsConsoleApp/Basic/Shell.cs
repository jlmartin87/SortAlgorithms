using SortAlgorithmsConsoleApp.Base;
using System;

namespace SortAlgorithmsConsoleApp.Basic
{
    public class Shell<T> : SortAlgorithm<T> where T : IComparable<T>
    {
        public Shell(T[] array) : base(array)
        {
        }

        public override T[] Sort()
        {
            int h = 1;
            while(h < _array.Length / 3)
            {
                h = 3 * h + 1;
            }

            while(h >= 1)
            {
                for (int i = h; i < _array.Length; i++)
                {
                    for (int j = i; j >= h && Less(_array[j], _array[j - h]); j -= h)
                    {
                        Exchange(j, j - h);
                    }
                }

                h /= 3;
            }

            return _array;
        }
    }
}
