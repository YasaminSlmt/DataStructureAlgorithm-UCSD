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

        public int Parent (int i)
        {
            return (int)Math.Floor(Convert.ToDouble(i)/ 2.0);
        }

        public int LeftChild(int i)
        {
            return 2*i;
        }

        public int RightChild(int i)
        {
            return 2*i+1;
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
            while (i > 0 && Data[Parent(i)] < Data[i])
            {
                Swap(Parent(i), i);
                i = Parent(i);
            }
        }

        public void SiftDown(int i)
        {
            int maxIndex = i;
            int leftChild = LeftChild(i);

            if (leftChild <= Data.Count() && Data[leftChild] > Data[maxIndex])
                maxIndex = leftChild;

            int rightChild = RightChild(i);
            if (rightChild <= Data.Count() && Data[rightChild] > Data[maxIndex])
                maxIndex = rightChild;

            if (i != maxIndex)
            {
                Swap(i, maxIndex);
                SiftDown(maxIndex);
            }
        }

        public int ExtractMax()
        {
            int result = Data[0];
            Data[0] = Data[Data.Count() - 1];
            SiftDown(0);
            return result;
        }
    }
    
    public class SwapArray
    {
        
        public List<int> Index1 { get; set; }
        public List<int> Index2 { get; set; }
    }
    
    
    class Program
    {
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            string[] inputStr = Console.ReadLine().Split(" ");
            int[] inputNums = Array.ConvertAll(inputStr, s => int.Parse(s));

            Heap heap = new Heap();

            for (int i = 0; i < n; i++)
            {
                heap.Data.Add(inputNums[i]);
            }
            int stop = 1;
        }
    }
}
