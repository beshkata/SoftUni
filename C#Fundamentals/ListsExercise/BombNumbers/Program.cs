using System;
using System.Collections.Generic;
using System.Linq;

namespace BombNumbers
{
    class Program
    {
        static void Main()
        {
            List<int> numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            int[] bombParams = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int bombNumber = bombParams[0];
            int bombPow = bombParams[1];

            int count = numbers.Count;

            int index = numbers.IndexOf(bombNumber);

            while (index >= 0)
            {
                Detonation(numbers, index, bombPow);
                index = numbers.IndexOf(bombNumber);
            }

            int sum = GetSum(numbers);
            Console.WriteLine(sum);
        }

        private static int GetSum(List<int> numbers)
        {
            int sum = 0;
            foreach (int num in numbers)
            {
                sum += num;
            }
            return sum;
        }

        private static void Detonation(List<int> numbers, int index, int bombPow)
        {
            int startIndex = 0;
            int bombRange = 2 * bombPow + 1;
            if (index - bombPow >= 0)
            {
                startIndex = index - bombPow;
            }

            if (startIndex + bombRange > numbers.Count - 1)
            {
                bombRange = numbers.Count - startIndex;
            }
            numbers.RemoveRange(startIndex, bombRange);
        }
    }
}
