using SortAlgorithmsConsoleApp.Base;
using System;

namespace SortAlgorithmsConsoleApp.Basic
{
    public class Bubble<T> : SortAlgorithm<T> where T : IComparable<T>
    {
        public Bubble(T[] array) : base(array)
        {
        }

        public override T[] Sort()
        {
            bool swap;
            int length = _array.Length;

            do
            {
                swap = false;

                for(int i = 1; i < length; i++)
                {
                    if(Less(_array[i], _array[i - 1]))
                    {
                        Exchange(i, i - 1);
                        swap = true;
                    }
                }
                length--;

            } while (swap);

            return _array;
        }
    }
}
