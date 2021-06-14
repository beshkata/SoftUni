using System;
using System.Linq;

namespace CustomComparator
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Array.Sort(numbers, (a, b) =>
            {
                //a - even , b - odd
                if (a % 2 == 0 && b % 2 != 0)
                {
                    return -1;
                }
                //a - odd, b - even
                else if (a % 2 != 0 && b % 2 == 0)
                {
                    return 1;
                }
                else
                {
                    return a.CompareTo(b);
                }
                
            });

            Console.WriteLine(string.Join(' ', numbers));
        }
    }
}
