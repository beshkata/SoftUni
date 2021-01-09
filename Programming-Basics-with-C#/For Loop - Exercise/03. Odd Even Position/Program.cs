using System;

namespace _03._Odd_Even_Position
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            double oddSum = 0.0;
            double oddMin = double.MaxValue;
            double oddMax = double.MinValue;
            double evenSum = 0.0;
            double evenMin = double.MaxValue;
            double evenMax = double.MinValue;

            for (int i = 1; i <= n; i++)
            {
                double currentNum = double.Parse(Console.ReadLine());
                if (i % 2 == 0)
                {
                    evenSum += currentNum;
                    if (currentNum > evenMax)
                    {
                        evenMax = currentNum;
                    }
                    if (currentNum < evenMin)
                    {
                        evenMin = currentNum;
                    }
                }
                else
                {
                    oddSum += currentNum;
                    if (currentNum > oddMax)
                    {
                        oddMax = currentNum;
                    }
                    if (currentNum < oddMin)
                    {
                        oddMin = currentNum;
                    }
                }
            }

            Console.WriteLine($"OddSum={oddSum:f2},");
            if (oddMin == double.MaxValue)
            {
                Console.WriteLine("OddMin=No,");
            }
            else
            {
                Console.WriteLine($"OddMin={oddMin:f2},");
            }
            if (oddMax == double.MinValue)
            {
                Console.WriteLine("OddMax=No,");
            }
            else
            {
                Console.WriteLine($"OddMax={oddMax:f2},");
            }
            Console.WriteLine($"EvenSum={evenSum:f2},");
            if (evenMin == double.MaxValue)
            {
                Console.WriteLine("EvenMin=No,");
            }
            else
            {
                Console.WriteLine($"EvenMin={evenMin:f2},");
            }
            if (evenMax == double.MinValue)
            {
                Console.WriteLine("EvenMax=No");
            }
            else
            {
                Console.WriteLine($"EvenMax={evenMax:f2}");
            }
        }
    }
}
