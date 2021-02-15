using System;

namespace TopNumber
{
    class Program
    {
        static void Main()
        {
            int number = int.Parse(Console.ReadLine());

            for (int i = 1; i <= number; i++)
            {
                if (GetSumOfDigits(i) % 8 == 0 && HasOddDigit(i))
                {
                    Console.WriteLine(i);
                }
            }
        }

        private static bool HasOddDigit(int number)
        {
            while (number > 0)
            {
                int digit = number % 10;
                number /= 10;
                if (digit % 2 == 1)
                {
                    return true;
                }
            }

            return false;
        }

        private static int GetSumOfDigits(int number)
        {
            int sum = 0;
            while (number > 0)
            {
                sum += number % 10;
                number /= 10;
            }
            return sum;
        }
    }
}
