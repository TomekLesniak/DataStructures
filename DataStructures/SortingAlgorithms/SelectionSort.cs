using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.SortingAlgorithms
{
    public class SelectionSort
    {
        public static void Sort(int[] numbers)
        {
            var currentSorted = 0;

            while (currentSorted != numbers.Length)
            {
                var smallestIndex = GetIndexOfSmallest(numbers, currentSorted);
                Swap(numbers, smallestIndex, currentSorted);
                currentSorted++;
            }
        }

        private static void Swap(int[] numbers, int indexFirst, int indexSecond)
        {
            int temp = numbers[indexFirst];
            numbers[indexFirst] = numbers[indexSecond];
            numbers[indexSecond] = temp;
        }

        private static int GetIndexOfSmallest(int[] numbers, int currentSmallest)
        {
            var smallestIndex = currentSmallest;

            for (int i = currentSmallest; i < numbers.Length; i++)
            {
                if (numbers[i] < numbers[smallestIndex])
                    smallestIndex = i;
            }

            return smallestIndex;
        }
    }
}
