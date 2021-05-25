using System;
using System.Collections.Generic;
using System.Linq;

namespace BasicQueueOperations
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

            int s = commands[1];
            int x = commands[2];

            Queue<int> queueNumbers = new Queue<int>(numbers);

            if (queueNumbers.Count > 0)
            {
                for (int i = 0; i < s; i++)
                {
                    queueNumbers.Dequeue();
                }
            }

            if (queueNumbers.Contains(x))
            {
                Console.WriteLine("true");
            }
            else if (queueNumbers.Count == 0)
            {
                Console.WriteLine("0");
            }
            else
            {
                Console.WriteLine(queueNumbers.Min());
            }
        }
    }
}
