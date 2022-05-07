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
        public List<long> nextAvailTimes = new List<long>();
        public ArrayList workerIDs = new ArrayList();
        public int size = new int();

        public Heap(int heapSize)
        {
            // Contsructing the heap
            // At the beginning, all the threads have an available time of 0 (they are all available) and have a rank of 0
            size = heapSize;
            for (int iWorker = 0; iWorker < size; iWorker++)
            {
                nextAvailTimes.Add(0);
                workerIDs.Add(iWorker);
            }

        }
        
        public int Parent(int i)
        {
            return (int)Math.Floor(Convert.ToDouble(i - 1) / 2.0);
        }

        public int LeftChild(int i)
        {
            return 2 * i + 1;
        }

        public int RightChild(int i)
        {
            return 2 * i + 2;
        }

        public void Swap(int index1, int index2)
        {
            long temp = nextAvailTimes[index1];
            nextAvailTimes[index1] = nextAvailTimes[index2];
            nextAvailTimes[index2] = temp;

            temp = (int)workerIDs[index1];
            workerIDs[index1] = workerIDs[index2];
            workerIDs[index2] = temp;

        }

        public void SiftUp(int i)
        {
            while (i > 0 && nextAvailTimes[Parent(i)] > nextAvailTimes[i])
            {
                Swap(Parent(i), i);
                i = Parent(i);
            }
        }

        public void SiftDown(int i)
        {
            int minIndex = i;
            int leftChild = LeftChild(i);

            if (leftChild < size && nextAvailTimes[leftChild] < nextAvailTimes[minIndex])
                minIndex = leftChild;

            int rightChild = RightChild(i);
            if (rightChild < size && nextAvailTimes[rightChild] < nextAvailTimes[minIndex])
                minIndex = rightChild;

            if (i != minIndex)
            {
                Swap(i, minIndex);
                SiftDown(minIndex);
            }
        }


        public long ExtractMin()
        {
            long result = nextAvailTimes[0];
            nextAvailTimes[0] = nextAvailTimes[size - 1];
            size -= 1;
            SiftDown(0);
            return result;
        }
    }

    
    
    class Program
    {
        static void Main(string[] args)
        {
            // Get inputs
            string[] inputStr1 = Console.ReadLine().Split(" ");
            string[] inputStr2 = Console.ReadLine().Split(" ");

            int nThreads = Convert.ToInt32(inputStr1[0]);
            int nJobs = Convert.ToInt32(inputStr1[1]);

            
            long[] jobsProcessingTimes = Array.ConvertAll(inputStr2, s => Convert.ToInt64(s));
            long[] jobsStartTimes = new long[nJobs];
            int[] jobsWorkers = new int[nJobs]; // ID of the workers that are assigned a job

            Heap heap = new Heap(nThreads);


            for(int iJob = 0; iJob < nJobs; iJob ++)
            {
                long processingTime = jobsProcessingTimes[iJob];

                // Assign the job to the root of the heap because that's the worker with smallest next available time
                jobsStartTimes[iJob] = heap.nextAvailTimes[0];
                jobsWorkers[iJob] = (int) heap.workerIDs[0];
                heap.nextAvailTimes[0] += processingTime;
            }

            // Output

            for(int iJob = 0; iJob < nJobs; iJob++)
            {
                Console.WriteLine(jobsWorkers[iJob] + " " + jobsStartTimes[iJob]);
            }






        }
    }
}
