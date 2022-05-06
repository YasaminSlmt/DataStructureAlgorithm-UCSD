using System;
using System.Text;
using System.Linq;
using System.IO;
using System.Collections.Generic;
using System.Collections;

namespace Solution
{
    public class Heap
    {
        public List<int> Data = new List<int>();
        public SwapArray swap = new SwapArray();
        public int Size = new int();

        public int Parent (int i)
        {
            return (int)Math.Floor(Convert.ToDouble(i-1)/ 2.0);
        }

        public int LeftChild(int i)
        {
            return 2*i+1;
        }

        public int RightChild(int i)
        {
            return 2*i+2;
        }

        public void Swap(int index1, int index2)
        {
            int temp = Data[index1];
            Data[index1] = Data[index2];
            Data[index2] = temp;

            swap.Index1.Add(index1);
            swap.Index2.Add(index2);
        }

        public void SiftUp(int i)
        {
            while (i > 0 && Data[Parent(i)] > Data[i])
            {
                Swap(Parent(i), i);
                i = Parent(i);
            }
        }

        public void SiftDown(int i)
        {
            int minIndex = i;
            int leftChild = LeftChild(i);

            if (leftChild < Size && Data[leftChild] < Data[minIndex])
                minIndex = leftChild;

            int rightChild = RightChild(i);
            if (rightChild < Size && Data[rightChild] < Data[minIndex])
                minIndex = rightChild;

            if (i != minIndex)
            {
                Swap(i, minIndex);
                SiftDown(minIndex);
            }
        }

        public int ExtractMin()
        {
            int result = Data[0];
            Data[0] = Data[Size - 1];
            Size -= 1 ;
            SiftDown(0);
            return result;
        }
    }
    
    public class SwapArray
    {
        
        public List<int> Index1 = new List<int>();
        public List<int> Index2 = new List<int>();


    }
    
    
    class Program
    {
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            string[] inputStr = Console.ReadLine().Split(" ");
            int[] inputNums = Array.ConvertAll(inputStr, s => int.Parse(s));

            Heap heap = new Heap();
            heap.Size = n;

            for (int i = 0; i < n; i++)
            {
                heap.Data.Add(inputNums[i]);
            }
            // Build the heap
            for (int i = (int)Math.Floor(Convert.ToDouble(heap.Size) / 2.0); i>=0 ; i--)
            {
                heap.SiftDown(i);
            }

            /// For sorting
            //for (int i = 0; i <n; i++)
            //{
            //    heap.Swap(0,i);
            //    heap.Size = i;
            //    heap.SiftDown(0);
            //}

            // Printing
            Console.WriteLine(heap.swap.Index1.Count());
            for(int i = 0; i < heap.swap.Index1.Count(); i++)
            {
                Console.WriteLine(heap.swap.Index1[i] + " " + heap.swap.Index2[i]);
            }

                

        }
    }
}
