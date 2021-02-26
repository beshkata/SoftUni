using System;
using System.Collections.Generic;
using System.Linq;

namespace Numbers
{
    class Program
    {
        static void Main()
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int numbersSum = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                numbersSum += numbers[i];
            }

            double averageValue = 1.0 * numbersSum / numbers.Length;

            List<int> numbersBiggerThanAverage = new List<int>();

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] > averageValue)
                {
                    numbersBiggerThanAverage.Add(numbers[i]);
                }
            }

            numbersBiggerThanAverage.Sort();
            numbersBiggerThanAverage.Reverse();

            if (numbersBiggerThanAverage.Count == 0)
            {
                Console.WriteLine("No");
            }
            else if (numbersBiggerThanAverage.Count <= 5)
            {
                Console.WriteLine(string.Join(' ', numbersBiggerThanAverage));
            }
            else
            {
                for (int i = 0; i < 5; i++)
                {
                    Console.Write($"{numbersBiggerThanAverage[i]} ");
                }
            }
        }
    }
}
