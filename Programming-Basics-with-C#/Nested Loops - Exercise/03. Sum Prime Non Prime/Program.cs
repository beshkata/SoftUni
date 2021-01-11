using System;

namespace _03._Sum_Prime_Non_Prime
{
    class Program
    {
        static void Main()
        {
            string input = Console.ReadLine();
            int primeSum = 0;
            int nonPrimeSum = 0;
            while (input != "stop")
            {
                int currentNum = int.Parse(input);
                if (currentNum < 0)
                {
                    Console.WriteLine("Number is negative.");
                }
                else
                {
                    if (IsPrime(currentNum))
                    {
                        primeSum += currentNum;
                    }
                    else
                    {
                        nonPrimeSum += currentNum;
                    }
                }
                input = Console.ReadLine();
            }
            Console.WriteLine($"Sum of all prime numbers is: {primeSum}");
            Console.WriteLine($"Sum of all non prime numbers is: {nonPrimeSum}");
        }

        static bool IsPrime(int n)
        {
            bool isPrime = true;
            if (n == 1 || n == 0)
            {
                return isPrime;
            }
            else
            {
                for (int i = 2; i <= Math.Sqrt(n); i++)
                {
                    if (n % i == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }

            }
            return isPrime;
        }
    }
}
