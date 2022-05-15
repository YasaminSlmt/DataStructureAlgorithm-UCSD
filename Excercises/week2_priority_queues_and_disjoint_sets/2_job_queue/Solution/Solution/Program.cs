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
        public List<int> workerIDs = new List<int>();
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

            int tempID = (int)workerIDs[index1];
            workerIDs[index1] = workerIDs[index2];
            workerIDs[index2] = tempID;

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

            if (leftChild < size)
                if (nextAvailTimes[leftChild] < nextAvailTimes[minIndex])
                    minIndex = leftChild;
                else if (nextAvailTimes[leftChild] == nextAvailTimes[minIndex] && workerIDs[leftChild] < workerIDs[minIndex])
                    // if the values are the same, the minimum should be the worker with smaller ID (ther worker with the smaller ID is prioritized in terms of job assignment)
                    minIndex = leftChild;



            int rightChild = RightChild(i);
            if (rightChild < size)
                if (nextAvailTimes[rightChild] < nextAvailTimes[minIndex])
                    minIndex = rightChild;
                else if (nextAvailTimes[rightChild] == nextAvailTimes[minIndex] && workerIDs[rightChild] < workerIDs[minIndex])
                    // if the values are the same, the minimum should be the worker with smaller ID (ther worker with the smaller ID is prioritized in terms of job assignment)
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

            // The logic is using min heap to sort the workers based on their next available time and use an array which
            // tracks the ID of the workers
            // Min heap is initialized by assigning 0 to all the nodes
            // Then the program would loop over each process and assign it to the root of the heap, which base on the logic
            // of min heap, would be the node with smallest available time. Then the processing time of the new job is added
            // to the value of the root, and then SiftDown is called to sort the min heap. 
            // SiftDown is similar to the one used for the first assignment (and similar to the one used in the course lecture
            // except that one was a max heap), though it's modified to accound for conditions when the next available time of the parent
            // is the same as the left or right child, the node with the lowest worker ID should be the parent
            // In Swap, both the workerID and node in the heap are swapped.
            Heap heap = new Heap(nThreads);


            for(int iJob = 0; iJob < nJobs; iJob ++)
            {
                long processingTime = jobsProcessingTimes[iJob];

                // Assign the job to the root of the heap because that's the worker with smallest next available time
                jobsStartTimes[iJob] = heap.nextAvailTimes[0];
                jobsWorkers[iJob] = (int) heap.workerIDs[0];
                heap.nextAvailTimes[0] += processingTime;
                heap.SiftDown(0);
            }

            // Output

            for(int iJob = 0; iJob < nJobs; iJob++)
            {
                Console.WriteLine(jobsWorkers[iJob] + " " + jobsStartTimes[iJob]);
            }






        }
    }
}
