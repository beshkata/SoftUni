using System;
using System.Numerics;

namespace SumOfRealNumbers
{
    class Program
    {
        static void Main()
        {
            int numbersCount = int.Parse(Console.ReadLine());
            decimal sum = 0.0M;
            BigInteger sumBigInt = 0;
            bool isInteger = true;

            for (int i = 0; i < numbersCount; i++)
            {
                string input = Console.ReadLine();
                BigInteger current = 0;
                if (BigInteger.TryParse(input, out current) && isInteger)
                {
                    sumBigInt += current;
                }
                else
                {
                    sum += decimal.Parse(input);
                    isInteger = false;
                }
                
            }

            if (isInteger)
            {
                Console.WriteLine(sumBigInt);
            }
            else
            {
                if (sumBigInt != 0)
                {
                    sum += (decimal)sumBigInt;
                }
                Console.WriteLine(sum);
            }
        }
    }
}
