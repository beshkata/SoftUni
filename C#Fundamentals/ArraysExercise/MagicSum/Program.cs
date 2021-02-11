using System;
using System.Linq;

namespace MagicSum
{
    class Program
    {
        static void Main()
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int givenSum = int.Parse(Console.ReadLine());

            for (int i = 0; i < numbers.Length; i++)
            {
                int currentNumber = numbers[i];

                for (int j = i + 1; j < numbers.Length; j++)
                {
                    int rightNumber = numbers[j];

                    if (currentNumber + rightNumber == givenSum)
                    {
                        Console.WriteLine($"{currentNumber} {rightNumber}");
                        break;
                    }
                }
            }

        }
    }
}
