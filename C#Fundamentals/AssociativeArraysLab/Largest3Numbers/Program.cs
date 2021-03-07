using System;
using System.Linq;

namespace Largest3Numbers
{
    class Program
    {
        static void Main()
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .OrderByDescending(n => n)
                .ToArray();
            int counts = 3;

            if (numbers.Length < 3)
            {
                counts = numbers.Length;
            }

            for (int i = 0; i < counts; i++)
            {
                Console.Write($"{numbers[i]} ");
            }
        }
    }
}
