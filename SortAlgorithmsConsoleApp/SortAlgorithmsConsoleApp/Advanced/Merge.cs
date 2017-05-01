using SortAlgorithmsConsoleApp.Base;
using System;

namespace SortAlgorithmsConsoleApp.Advanced
{
    public class Merge<T> : SortAlgorithm<T> where T : IComparable<T>
    {
        private T[] aux;

        public Merge(T[] array) : base(array)
        {
        }

        public override T[] Sort()
        {
            aux = new T[_array.Length];
            Sort(0, _array.Length - 1);

            return _array;
        }

        private void Sort(int lo, int hi)
        {
            if(lo >= hi)
            {
                return;
            }

            int mid = lo + (hi - lo) / 2;

            Sort(lo, mid);
            Sort(mid + 1, hi);

            MergeLoToHi(lo, mid, hi);
        }

        private void MergeLoToHi(int lo, int mid, int hi)
        {
            for(int k = lo; k <= hi; k++)
            {
                aux[k] = _array[k];
            }

            int i = lo;
            int j = mid + 1;

            for(int k = lo; k <= hi; k++)
            {
                if(i > mid)
                {
                    _array[k] = aux[j++];
                }
                else if(j > hi)
                {
                    _array[k] = aux[i++];
                }
                else if(Less(aux[i], aux[j]))
                {
                    _array[k] = aux[i++];
                }
                else
                {
                    _array[k] = aux[j++];
                }
            }
        }
    }
}
