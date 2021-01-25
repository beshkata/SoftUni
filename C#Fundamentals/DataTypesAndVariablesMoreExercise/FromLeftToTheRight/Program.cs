using System;

namespace FromLeftToTheRight
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                string[] numbers = input.Split(' ');
                long firstNum = long.Parse(numbers[0]);
                long secondNum = long.Parse(numbers[1]);
                if (firstNum > secondNum)
                {
                    SumOfDigit(firstNum);
                }
                else
                {
                    SumOfDigit(secondNum);
                }
            }
        }
        static void SumOfDigit(long number)
        {
            long sum = 0;
            number = Math.Abs(number);

            while(number > 0)
            {
                sum += number % 10;
                number /= 10;
            }
            Console.WriteLine(sum);
        }
    }
}
