using System;

namespace MultiplyEvensByOdds
{
    class Program
    {
        static void Main()
        {
            int number = Math.Abs(int.Parse(Console.ReadLine()));

            int result = GetMultipleOfEvenAndOdds(number);

            Console.WriteLine(result);
        }

        private static int GetMultipleOfEvenAndOdds(int number)
        {
            int sumOfEven = GetSumOfEven(number);
            int sumOfOdd = GetSumOfOdd(number);

            return sumOfEven * sumOfOdd;
        }

        private static int GetSumOfOdd(int number)
        {
            int sumOfOdd = 0;

            while(number > 0)
            {
                if ((number % 10) %2 == 1)
                {
                    sumOfOdd += number % 10;
                }
                
                number /= 10;
            }

            return sumOfOdd;
        }

        private static int GetSumOfEven(int number)
        {
            int sumOfEven = 0;

            while (number > 0)
            {
                if ((number % 10) % 2 == 0)
                {
                    sumOfEven += number % 10;
                }

                number /= 10;
            }

            return sumOfEven;
        }
    }
}
