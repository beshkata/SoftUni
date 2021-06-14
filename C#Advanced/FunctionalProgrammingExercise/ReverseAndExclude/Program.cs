using System;
using System.Linq;

namespace ReverseAndExclude
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int divider = int.Parse(Console.ReadLine());

            Predicate<int> canBeDivided = n => n % divider != 0;

            int[] result = numbers
                .Where(n => canBeDivided(n))
                .Reverse()
                .ToArray();

            Console.WriteLine(string.Join(' ', result));
        }
    }
}
