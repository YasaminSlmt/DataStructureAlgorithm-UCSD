using System;
using System.Text;
using System.Linq;
using System.IO;
using System.Collections.Generic;
using System.Collections;

namespace Solution
{
    class Program
    {
        static void Main(string[] args)
        {

         //char[] inputTxt = File.ReadAllText(@"G:\My Drive\Yasamin\Courses\Data Structure and Algorithm Specialization\Excercises\week1_basic_data_structures\1_brackets_in_code\tests\26").ToCharArray();


         char[] inputTxt = Console.ReadLine().ToCharArray();


         Stack brackets = new Stack();
         Stack bracketsIdx = new Stack();
         bool result = true;
         IDictionary<char, char> pairs = new Dictionary<char, char>()
            {
                { '(',')'},
                { '[',']'},
                {'{','}' }
            };

        int badIdx = 0;
        for (int idx = 0; idx < inputTxt.Length; idx++) 
            {
                if (!pairs.ContainsKey(inputTxt[idx]) && !pairs.Values.Contains(inputTxt[idx]))
                {
                    continue;
                }

            if (pairs.Any(current => inputTxt[idx].Equals(current.Key)))
                {
                    brackets.Push(inputTxt[idx]);
                    bracketsIdx.Push(idx);
                }
                    
            else if (brackets.Count == 0)
                    {
                        result = false;
                        badIdx = idx + 1;
                        break;
                    }
            else
                    {
                        char lastIn = (Char)brackets.Pop();
                        int lastInIdx = (int)bracketsIdx.Pop();
                    
                        if (!inputTxt[idx].Equals(pairs[lastIn]))
                        {
                            result = false;
                            badIdx = idx + 1;
                            break;
                        }

                    }



            }
                // Check if the stack is empty
             if (brackets.Count != 0 && result == true)
                {
                    result = false;
                    badIdx = (int)bracketsIdx.Pop() + 1 ;
                }
                    

             // Console.WriteLine((result == true ? "Success" : badIdx)); Coursera gave compilation error because of this line
             if (result == true)
                Console.WriteLine("Success");
             else
                Console.WriteLine(badIdx);
           




        }
    }
}
