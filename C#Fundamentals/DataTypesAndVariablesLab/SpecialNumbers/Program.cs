using System;

namespace SpecialNumbers
{
    class Program
    {
        static void Main()
        {
            int number = int.Parse(Console.ReadLine());

            for (int i = 1; i <= number; i++)
            {
                Console.WriteLine($"{i} -> {SumOfDigits(i)}");
            }
        }
        static bool SumOfDigits(int num)
        {
            int sum = 0;

            while (num > 0)
            {
                sum += num % 10;
                num /= 10;
            }
            return sum == 5 || sum == 7 || sum == 11;
        }
    }
}
