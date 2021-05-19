using System;
using System.Collections.Generic;
using System.Linq;

namespace StackSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            Stack<int> stackOfNumbers = new Stack<int>();

            for (int i = 0; i < numbers.Length; i++)
            {
                stackOfNumbers.Push(numbers[i]);
            }

            string command = Console.ReadLine().ToLower();

            while (command != "end")
            {
                string[] tokens = command.Split();
                if (command.Contains("add"))
                {
                    stackOfNumbers.Push(int.Parse(tokens[1]));
                    stackOfNumbers.Push(int.Parse(tokens[2]));
                }
                else
                {
                    int count = int.Parse(tokens[1]);
                    if (count <= stackOfNumbers.Count)
                    {
                        for (int i = 0; i < count; i++)
                        {
                            stackOfNumbers.Pop();
                        }
                    }
                }
                command = Console.ReadLine().ToLower();
            }

            int sum = 0;

            while (stackOfNumbers.Count > 0)
            {
                sum += stackOfNumbers.Pop();
            }

            Console.WriteLine($"Sum: {sum}");
        }
    }
}
