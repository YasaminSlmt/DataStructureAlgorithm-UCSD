using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;


namespace Solution
{

    public class Tree
    {
        public List<TreeNode> Nodes = new List<TreeNode>();
        public int Root { get; set; }

        public void AddNode(TreeNode node)
        {
            this.Nodes.Add(node);
        }


    }
    
    public class TreeNode 
    {
        public int Parent { get; set; }
        public List<TreeNode> Childeren = new List<TreeNode>();

        public TreeNode()
        {

        }

        public void AddChild(TreeNode child)
        {
            this.Childeren.Add(child);
        }

        public int GetHeight()
        {
            
            if (this == null)
                return 0;
            int MaxHeight = 0;
            foreach (TreeNode child in this.Childeren)
            {
                MaxHeight = Math.Max(MaxHeight, child.GetHeight());
            }
            return MaxHeight + 1;
        }

    }


    class Program
    {

        static void Main(string[] args)
        {

            //string[] inputTxt = File.ReadAllLines(@"G:\My Drive\Yasamin\Courses\Data Structure and Algorithm Specialization\Excercises\week1_basic_data_structures\2_tree_height\tests\05");
            //string[] inputStr = inputTxt[1].Split(" ");
            //int n = Convert.ToInt32(inputTxt[0]);

            int n = Convert.ToInt32(Console.ReadLine()); 
            string[] inputStr = Console.ReadLine().Split(" ");
            int[] input = Array.ConvertAll(inputStr, s => int.Parse(s));
            
            
            TreeNode[] nodes = new TreeNode[n];

            for(int i = 0; i < input.Length; i++)
            {
                nodes[i] = new TreeNode();
                nodes[i].Parent = input[i];

            }

            int rootIdx = 0;
            for (int childIdx = 0; childIdx < input.Length; childIdx++)
            {
                int parentIdx = input[childIdx];
                if (parentIdx == -1)
                    rootIdx = childIdx;
                else
                    nodes[parentIdx].AddChild(nodes[childIdx]);

            }

            int maxHeight = nodes[rootIdx].GetHeight();
            Console.WriteLine(maxHeight);



            //int maxHeight = 0;
            //foreach(int node in input)
            //{
            //    int height = 0;
            //    int current = node;
            //    while(current != -1)
            //    {
            //        height++;
            //        current = input[current];
            //    }
            //    maxHeight = Math.Max(maxHeight, height + 1);
            //}

            

            
        }
    }
}
