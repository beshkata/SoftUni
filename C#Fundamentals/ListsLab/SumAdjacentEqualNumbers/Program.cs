using System;
using System.Collections.Generic;
using System.Linq;

namespace SumAdjacentEqualNumbers
{
    class Program
    {
        static void Main()
        {
            List<double> numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToList();
            bool areEqualNumbers = false;
            do
            {
                areEqualNumbers = false;
                for (int i = 1; i < numbers.Count; i++)
                {
                    if (numbers[i - 1] == numbers[i])
                    {
                        numbers[i- 1] += numbers[i];
                        numbers.RemoveAt(i);
                        areEqualNumbers = true;
                    }
                }
            }
            while (areEqualNumbers);
            Console.WriteLine(string.Join(' ', numbers));
        }
    }
}
