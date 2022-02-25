using System;
using System.Collections.Generic;

namespace Softuniada2021
{
    public class Program
    {
        public static void Main()
        {
            int startNum = int.Parse(Console.ReadLine());
            int endNum = int.Parse(Console.ReadLine());

            List<int> primeNumbers = new List<int>();

            for (int i = startNum; i <= endNum; i++)
            {
                bool isPrime = true;
                if (i == 1)
                {
                    continue;
                }

                for (int j = 2; j <= Math.Sqrt(i); j++)
                {
                    if (i % j == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }

                if (isPrime)
                {
                    primeNumbers.Add(i);
                }
            }

            Console.WriteLine(string.Join(" ", primeNumbers));
            Console.WriteLine($"The total number of prime numbers between {startNum} to {endNum} is {primeNumbers.Count}");
        }
    }

}
