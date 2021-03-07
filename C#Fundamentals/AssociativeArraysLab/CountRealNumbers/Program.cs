using System;
using System.Collections.Generic;
using System.Linq;

namespace CountRealNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            SortedDictionary<int, int> countByNumbers = new SortedDictionary<int, int>();

            foreach (int num in numbers)
            {
                if (countByNumbers.ContainsKey(num) == false)
                {
                    countByNumbers.Add(num, 0);
                }

                countByNumbers[num] += 1;
            }

            foreach (var kvp in countByNumbers)
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
            }
        }
    }
}
