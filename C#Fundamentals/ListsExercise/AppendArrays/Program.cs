using System;
using System.Collections.Generic;
using System.Linq;

namespace AppendArrays
{
    class Program
    {
        static void Main()
        {
            List<string> arrays = Console.ReadLine()
                .Split('|')
                .ToList();
            List<int> result = new List<int>();

            for (int i = arrays.Count-1; i >= 0; i--)
            {
                int[] numbers = arrays[i]
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                result.AddRange(numbers);
            }

            Console.WriteLine(string.Join(' ', result));
        }
    }
}
