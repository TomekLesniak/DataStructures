using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.SortingAlgorithms
{
    public class BubbleSort
    {
        public static void Sort(int[] numbers)
        {
            if (numbers.Length == 0)
                return;

            bool isSorted = false;
            int toSort = numbers.Length;

            while (toSort != 1)
            {
                isSorted = true;
                for (int i = 0; i < numbers.Length - 1; i++)
                {
                    if (i > toSort)
                        continue;

                    if (numbers[i] > numbers[i + 1])
                    {
                        Swap(numbers, i, i + 1);
                        isSorted = false;
                    }
                }

                if (isSorted)
                    return;

                toSort--;
            }

        }

        private static void Swap(int[] numbers, int indexFirst, int indexSecond)
        {
            int temp = numbers[indexFirst];
            numbers[indexFirst] = numbers[indexSecond];
            numbers[indexSecond] = temp;
        }
    }
}
