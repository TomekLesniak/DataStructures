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

        public int Remove()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Heap is empty");

            var root = heap[0];

            var index = 0; // always removing root node
            heap[index] = heap[--size];

            if (heap[index] < heap[GetIndexOfLeftChild(index)]
                || heap[index] < heap[GetIndexOfRightChild(index)])
            {
                BubbleDown(index);
            }

            return root;
        }

        public bool IsFull()
        {
            return size == heap.Length;
        }

        public bool IsEmpty()
        {
            return size == 0;
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

        private void BubbleDown(int index)
        {
            if (index > size)
                return;

            var biggerIndex = GetIndexOfGreaterValue(index);

            if (heap[index] >= heap[biggerIndex])
                return;

            var temp = heap[biggerIndex];
            heap[biggerIndex] = heap[index];
            heap[index] = temp;

            BubbleDown(biggerIndex);
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

        private int GetIndexOfGreaterValue(int index)
        {
            if (GetIndexOfRightChild(index) > size)
            {
                if (GetIndexOfLeftChild(index) > size)
                    return index;
                return GetIndexOfLeftChild(index);
            }

            return (heap[GetIndexOfLeftChild(index)] > heap[GetIndexOfRightChild(index)])
                ? GetIndexOfLeftChild(index)
                : GetIndexOfRightChild(index);
        }

        private int GetIndexOfValue(int value)
        {
            for (int i = 0; i < size; i++)
            {
                if (heap[i] == value)
                    return i;
            }

            return -1;
        }

        private bool IsLastChild(int index)
        {
            if (index == size)
                return true;

            return false;
        }
    }
}
