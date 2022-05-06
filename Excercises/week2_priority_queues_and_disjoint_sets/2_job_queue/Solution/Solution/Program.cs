using System;
using System.Text;
using System.Linq;
using System.IO;
using System.Collections.Generic;
using System.Collections;

namespace Solution
{
    public class Thread
    {
        public bool isFree { get; set; }
        public int currentJob { get; set; }
        public int timeUntilFree { get; set; }
    }
    
    
    class Program
    {
        static void Main(string[] args)
        {
            string[] inputStr1 = Console.ReadLine().Split(" ");
            int nThreads = Convert.ToInt32(inputStr1[0]);
            int nJobs = Convert.ToInt32(inputStr1[1]);

            string[] inputStr2 = Console.ReadLine().Split(" ");
            int[] inputNums = Array.ConvertAll(inputStr2, s => int.Parse(s));



        }
    }
}
