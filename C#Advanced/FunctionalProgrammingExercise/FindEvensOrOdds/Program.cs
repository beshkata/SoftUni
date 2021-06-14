using System;
using System.Collections.Generic;

namespace FindEvensOrOdds
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            int start = int.Parse(input[0]);
            int end = int.Parse(input[1]);
            string filter = Console.ReadLine();

            Predicate<int> numFilter = FindEvenOdd(filter);

            PrintNumbers(start, end, numFilter);
        }

        private static void PrintNumbers(int start, int end, Predicate<int> numFilter)
        {
            List<int> result = new List<int>();

            for (int i = start; i <= end; i++)
            {
                if (numFilter(i))
                {
                    result.Add(i);
                }
            }

            Console.WriteLine(string.Join(' ', result));
        }

        static Predicate<int> FindEvenOdd(string filter)
        {
            switch (filter)
            {
                case "even": return n => n % 2 == 0;
                case "odd": return n => n % 2 != 0;
                default:
                    return null;
            }
        }
    }
}
