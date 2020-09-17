using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Heap
{
    public class Heap
    {
        private int[] heap;
        private int size;

        public Heap(int size)
        {
            heap = new int[size];
            size = 0;
        }

        public void Insert(int value)
        {
            if (IsFull())
                throw new InvalidOperationException("Heap is full");

            heap[size++] = value;

            var index = size - 1;

            if (index == 0)
                return;

            if (heap[index] > heap[GetParentIndex(index)])
                BubbleUp(index);
        }

        public bool IsFull()
        {
            return size == heap.Length;
        }

        private void BubbleUp(int index)
        {
            if (index == 0)
                return;
            if (heap[index] < heap[GetParentIndex(index)])
                return;

            var temp = heap[GetParentIndex(index)];
            heap[GetParentIndex(index)] = heap[index];
            heap[index] = temp;

            BubbleUp(GetParentIndex(index));
        }



        private int GetIndexOfLeftChild(int parentIndex)
        {
            return parentIndex * 2 + 1;
        }

        private int GetIndexOfRightChild(int parentIndex)
        {
            return parentIndex * 2 + 2;
        }

        private int GetParentIndex(int childIndex)
        {
            return (childIndex - 1) / 2;
        }
    }
}
