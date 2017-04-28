using SortAlgorithmsConsoleApp.Base;
using System;

namespace SortAlgorithmsConsoleApp.Basic
{
    public class Selection<T> : SortAlgorithm<T> where T : IComparable<T>
    {
        public Selection(T[] array) : base(array)
        {
        }

        public override T[] Sort()
        {
            int minValuePosition;

            for (int i = 0; i < _array.Length - 1; i++)
            {
                minValuePosition = i;

                for (int j = i + 1; j < _array.Length; j++)
                {
                    if (Less(_array[j], _array[minValuePosition]))
                    {
                        minValuePosition = j;
                    }
                }

                if(minValuePosition != i)
                {
                    Exchange(i, minValuePosition);
                }                
            }

            return _array;
        }
    }
}
