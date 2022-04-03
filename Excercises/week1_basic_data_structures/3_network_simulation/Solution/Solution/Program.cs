using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;


namespace Solution
{
    public class Packet
    {
        public int InTime { get; set; }
        public int ProcTime { get; set; }

        public Packet(int inTime, int procTime)
        {
            this.InTime = inTime;
            this.ProcTime = procTime;
        }
    }

    public class Buffer
    {
        public int Size { get; set; } 
        public List<int> finish_time { get; set; }
        public Buffer(int size)
        {
            this.Size = size;
            this.finish_time = new List<int>();
        }

    }
    class Program
    {

        private static List<Packet> ReadInputPackets (int nLine)
        {
            List<Packet> packets = new List<Packet>();
            string[] inputLine = new string[2];
            for (int iLine = 0; iLine < nLine; iLine++)
            {
                inputLine = Console.ReadLine().Split(" ");
                packets.Add(new Packet(Convert.ToInt32(inputLine[0]), Convert.ToInt32(inputLine[1])));

            }
            return packets;
        }
        private static int[] ProcessOutputs (List<Packet> packets, Buffer buffer)
        {
            int current_time = 0;
            int[] output = new int[packets.Count]; 
            for (int i = 0; i < packets.Count; i++)
            {
                if (buffer.finish_time.Count != 0)
                {
                    int a = buffer.finish_time.FindIndex(0, buffer.finish_time.Count, x => x <= packets[i].InTime);
                    buffer.finish_time.RemoveAll(x => x <= packets[i].InTime);

                }
                if (buffer.finish_time.Count == buffer.Size)
                {
                    // Buffer is full
                    output[i] = -1;
                    continue;
                }
                else if (buffer.finish_time.Count == 0)
                {
                    output[i] = packets[i].InTime;
                    buffer.finish_time.Add(packets[i].InTime + packets[i].ProcTime);
                    
                }

                else
                {
                    output[i] = buffer.finish_time[buffer.finish_time.Count - 1];
                    buffer.finish_time.Add(packets[i].InTime + packets[i].ProcTime + buffer.finish_time[buffer.finish_time.Count - 1]);
                }
            }
            return output;
        }

        public static void PrintOutputs(int[] ouput)
        {
            foreach(int line in ouput)
                Console.WriteLine(line);
        }

        static void Main(string[] args)
        {

            List<int> a = new List<int>();
            string[] inputStr = Console.ReadLine().Split(" ");
            int SSize = Convert.ToInt32(inputStr[0]);
            int nLine = Convert.ToInt32(inputStr[1]);

            List<Packet> packets = ReadInputPackets(nLine);
            Buffer buffer = new Buffer(SSize);

            int[] output = ProcessOutputs(packets, buffer);
            PrintOutputs(output);




        }
    }
}

