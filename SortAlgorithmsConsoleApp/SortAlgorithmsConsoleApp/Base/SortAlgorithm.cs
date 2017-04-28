using System;

namespace SortAlgorithmsConsoleApp.Base
{
    public abstract class SortAlgorithm<T> where T : IComparable<T>
    {
        protected readonly T[] _array;

        public SortAlgorithm(T[] array)
        {
            _array = array ?? throw new ArgumentNullException(nameof(array));
        }

        public abstract T[] Sort();

        protected bool Less(T obj1, T obj2)
        {
            return obj1.CompareTo(obj2) < 0;
        }

        protected void Exchange(int pos1, int pos2)
        {
            T temp = _array[pos1];
            _array[pos1] = _array[pos2];
            _array[pos2] = temp;
        }
    }
}
