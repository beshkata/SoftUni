using System;
using System.Collections.Generic;
using System.Linq;

namespace BasicStackOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] commands = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int n = commands[0];
            int s = commands[1];
            int x = commands[2];

            Stack<int> stackNumbers = new Stack<int>(numbers);

            if (stackNumbers.Count > 0)
            {
                for (int i = 0; i < s; i++)
                {
                    stackNumbers.Pop();
                }
            }

            if (stackNumbers.Contains(x))
            {
                Console.WriteLine("true");
            }
            else if (stackNumbers.Count == 0)
            {
                Console.WriteLine("0");
            }
            else
            {
                Console.WriteLine(stackNumbers.Min());
            }
        }
    }
}
