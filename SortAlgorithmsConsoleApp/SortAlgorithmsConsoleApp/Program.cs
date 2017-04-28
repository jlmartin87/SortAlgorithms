using SortAlgorithmsConsoleApp.Base;
using SortAlgorithmsConsoleApp.Basic;
using System;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace SortAlgorithmsConsoleApp
{
    class Program
    {
        static void Main()
        {
            int[] array = GenerateIntArray(10000);

            EvalPerformanceOfBubbleSort(array);
            EvalPerformanceOfSelectionSort(array);
        }

        private static void EvalPerformanceOfBubbleSort(int[] array)
        {
            var bubble = new Bubble<int>(array.ToArray());
            EvalPerformanceOfSortAlgorithm(bubble);
        }

        private static void EvalPerformanceOfSelectionSort(int[] array)
        {
            var selection = new Selection<int>(array.ToArray());
            EvalPerformanceOfSortAlgorithm(selection);
        }

        #region Helper Methods

        static int[] GenerateIntArray(int size)
        {
            var array = new int[size];

            var rng = new RNGCryptoServiceProvider();
            var bytes = new byte[4];
            for (int i = 0; i < size; i++)
            {
                rng.GetBytes(bytes);
                array[i] = BitConverter.ToInt32(bytes, 0);
            }

            return array;
        }

        static void EvalPerformanceOfSortAlgorithm<T>(SortAlgorithm<T> algorithm) where T : IComparable<T>
        {
            var sw = new Stopwatch();
            sw.Start();
            T[] sortedArray = algorithm.Sort();
            sw.Stop();

            ThrowsIfArrayIsUnordered(sortedArray);
            ShowMessage(algorithm.GetType().Name, sw);
        }

        private static void ShowMessage(string algorithmName, Stopwatch sw)
        {
            int genericIndex = algorithmName.IndexOf('`');
            Console.WriteLine($"Ordered by {algorithmName.Substring(0, genericIndex)}Sort algorithm in {sw.Elapsed}.");
        }

        static void ThrowsIfArrayIsUnordered<T>(T[] array) where T : IComparable<T>
        {
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i].CompareTo(array[i - 1]) < 0)
                {
                    throw new Exception("Unordered array.");
                }
            }
        }

        static void ShowArray<T>(T[] array)
        {
            var sb = new StringBuilder();

            foreach (var item in array)
            {
                sb.Append($"{item} ");
            }

            Console.WriteLine(sb);
        }

        #endregion
    }
}
