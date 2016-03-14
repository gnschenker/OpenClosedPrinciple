using System;
using System.Collections.Generic;

namespace OpenClosedPrinciple
{
    public enum SortAlgorithms
    {
        BubbleSort = 1,
        QuickSort = 2,
        HeapSort = 3
    }

    // this class is not closed for code changes. Each time we add a new sort algorithm
    // we need to change the class. Also if one of the algorithms needs to be changed/tuned/improved
    // we need to change this class
    public class Sorter
    {
        public int[] Sort(int[] data, SortAlgorithms algorithm = SortAlgorithms.QuickSort)
        {
            switch (algorithm)
            {
                case SortAlgorithms.BubbleSort:
                    BubbleSort(data);
                    break;
                case SortAlgorithms.QuickSort:
                    QuickSort(data, 0, data.Length-1);
                    break;
                case SortAlgorithms.HeapSort:
                    HeapSort(data);
                    break;
                default:
                    throw new ArgumentException("Unknown sort algorithm");
            }
            return data;
        }

        #region Bubble sort

        private static void BubbleSort(int[] data)
        {
            for (var write = 0; write < data.Length; write++)
            {
                for (var sort = 0; sort < data.Length - 1; sort++)
                {
                    if (data[sort] <= data[sort + 1]) continue;
                    var temp = data[sort + 1];
                    data[sort + 1] = data[sort];
                    data[sort] = temp;
                }
            }
        }

        #endregion

        #region Quick sort

        private static void QuickSort(int[] input, int left, int right)
        {
            if (left < right)
            {
                int q = Partition(input, left, right);
                QuickSort(input, left, q - 1);
                QuickSort(input, q + 1, right);
            }
        }

        private static int Partition(IList<int> input, int left, int right)
        {
            var pivot = input[right];

            var i = left;
            for (var j = left; j < right; j++)
            {
                if (input[j] > pivot) continue;
                var temp = input[j];
                input[j] = input[i];
                input[i] = temp;
                i++;
            }

            input[right] = input[i];
            input[i] = pivot;

            return i;
        }

        #endregion

        #region Heap sort

        private static void HeapSort(int[] input)
        {
            //Build-Max-Heap
            var heapSize = input.Length;
            for (var p = (heapSize - 1)/2; p >= 0; p--)
                MaxHeapify(input, heapSize, p);

            for (var i = input.Length - 1; i > 0; i--)
            {
                //Swap
                var temp = input[i];
                input[i] = input[0];
                input[0] = temp;

                heapSize--;
                MaxHeapify(input, heapSize, 0);
            }
        }

        private static void MaxHeapify(IList<int> input, int heapSize, int index)
        {
            while (true)
            {
                var left = (index + 1)*2 - 1;
                var right = (index + 1)*2;
                int largest;

                if (left < heapSize && input[left] > input[index])
                    largest = left;
                else
                    largest = index;

                if (right < heapSize && input[right] > input[largest])
                    largest = right;

                if (largest == index) return;
                var temp = input[index];
                input[index] = input[largest];
                input[largest] = temp;

                index = largest;
            }
        }

        #endregion
    }

}