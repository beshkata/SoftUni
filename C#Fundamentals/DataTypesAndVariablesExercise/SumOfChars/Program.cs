using System;

namespace SumOfChars
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int totalSum = 0;

            for (int i = 0; i < n; i++)
            {
                char currentChar = char.Parse(Console.ReadLine());
                totalSum += currentChar;
            }
            Console.WriteLine($"The sum equals: {totalSum}");
        }
    }
}
