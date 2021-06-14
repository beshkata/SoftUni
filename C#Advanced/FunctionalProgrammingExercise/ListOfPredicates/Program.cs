using System;
using System.Collections.Generic;
using System.Linq;

namespace ListOfPredicates
{
    class Program
    {
        static void Main(string[] args)
        {
            int end = int.Parse(Console.ReadLine());

            List<int> dividers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            List<int> numbers = Enumerable.Range(1, end).ToList();

            foreach (int num in numbers)
            {
                if (dividers.All(d => num % d == 0))
                {
                    Console.Write(num + " ");
                }
            }
        }
    }
}
