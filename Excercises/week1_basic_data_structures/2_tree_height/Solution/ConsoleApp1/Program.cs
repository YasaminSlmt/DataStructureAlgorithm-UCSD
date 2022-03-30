using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;


namespace ConsoleApp1
{


    class Program
    {

        static void Main(string[] args)
        {
            int n = Convert.ToInt32 (Console.ReadLine());
            string[] inputTxt = File.ReadAllLines(@"G:\My Drive\Yasamin\Courses\Data Structure and Algorithm Specialization\Excercises\week1_basic_data_structures\2_tree_height\tests\24");
            string[] inputStr = inputTxt[1].Split(" ");
            //string[] inputStr = Console.ReadLine().Split(" ");
            int[] input = Array.ConvertAll(inputStr, s => int.Parse(s));

            int maxHeight = 0;
            foreach(int node in input)
            {
                int height = 0;
                int current = node;
                while(current != -1)
                {
                    height++;
                    current = input[current];
                }
                maxHeight = Math.Max(maxHeight, height + 1);
            }

            Console.WriteLine(maxHeight);

            
        }
    }
}
