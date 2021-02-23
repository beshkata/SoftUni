using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnonymousThreat
{
    class Program
    {
        static void Main()
        {
            List<string> data = Console.ReadLine()
                .Split()
                .ToList();

            string input = Console.ReadLine();

            while (input != "3:1")
            {
                string[] commands = input
                    .Split()
                    .ToArray();

                string command = commands[0];

                if (command == "merge")
                {
                    int startIndex = int.Parse(commands[1]);
                    int endIndex = int.Parse(commands[2]);

                    MergeStrings(data, startIndex, endIndex);
                }
                else
                {
                    int index = int.Parse(commands[1]);
                    int partitions = int.Parse(commands[2]);

                    DivideString(data, index, partitions);
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(string.Join(' ', data));
        }

        private static void DivideString(List<string> data, int index, int partitions)
        {
            string str = data[index];
            int partitionLenght = str.Length / partitions;

            string[] substrings = new string[partitions];
            int startIndex = 0;
            for (int i = 0; i < partitions - 1; i++)
            {
                substrings[i] = str.Substring(startIndex, partitionLenght);
                startIndex += partitionLenght;
            }
            int lastPartitionLenght = partitionLenght + (str.Length % partitions);
            substrings[partitions-1] = str.Substring(startIndex, lastPartitionLenght);

            data.RemoveAt(index);
            data.InsertRange(index, substrings);
        }

        private static void MergeStrings(List<string> data, int startIndex, int endIndex)
        {
            if (startIndex > data.Count - 1)
            {
                return;
            }
            if (endIndex < 0)
            {
                return;
            }
            if (startIndex < 0)
            {
                startIndex = 0;
            }

            if (endIndex > data.Count - 1)
            {
                endIndex = data.Count - 1;
            }

            StringBuilder stringBuilder = new StringBuilder();

            for (int i = startIndex; i <= endIndex; i++)
            {
                stringBuilder.Append(data[i]);
            }

            int count = endIndex - startIndex + 1;
            data.RemoveRange(startIndex, count);
            data.Insert(startIndex, stringBuilder.ToString());
        }
    }
}
