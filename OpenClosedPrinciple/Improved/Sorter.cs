using System.Collections.Generic;
using System.Linq;

namespace OpenClosedPrinciple.Improved
{
    // much better code NOT violating the Open-Close principle
    // it uses the "strategy pattern" to achieve this
    // Note: both, the Sorter class and the individual sort strategies are now "closed"
    //       and never need to be changed...
    public class Sorter
    {
        private readonly ISortStrategy[] _sortStrategies;

        public Sorter(ISortStrategy[] sortStrategies)
        {
            _sortStrategies = sortStrategies;
        }

        public int[] Sort(int[] data, SortAlgorithms algorithm = SortAlgorithms.QuickSort)
        {
            var strategy = _sortStrategies.Single(x => x.CanHandle(algorithm) == true);
            return strategy.Sort(data);
        }
    }

    public interface ISortStrategy
    {
        bool CanHandle(SortAlgorithms algorithm);
        int[] Sort(int[] data);
    }

    public class BubbleSortStrategy : ISortStrategy
    {
        public bool CanHandle(SortAlgorithms algorithm)
        {
            return algorithm == SortAlgorithms.BubbleSort;
        }

        public int[] Sort(int[] data)
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
            return data;
        }
    }

    public class HeapSortStrategy : ISortStrategy
    {
        public bool CanHandle(SortAlgorithms algorithm)
        {
            return algorithm == SortAlgorithms.HeapSort;
        }

        public int[] Sort(int[] data)
        {
            HeapSort(data);
            return data;
        }

        private static void HeapSort(int[] input)
        {
            //Build-Max-Heap
            var heapSize = input.Length;
            for (var p = (heapSize - 1) / 2; p >= 0; p--)
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
                var left = (index + 1) * 2 - 1;
                var right = (index + 1) * 2;
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
    }
}