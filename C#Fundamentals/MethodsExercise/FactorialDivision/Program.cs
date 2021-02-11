using System;
using System.Numerics;

namespace FactorialDivision
{
    class Program
    {
        static void Main()
        {
            double firstNum = double.Parse(Console.ReadLine());
            double secondNum = double.Parse(Console.ReadLine());

            double result = DivideFactorials(firstNum, secondNum);

            Console.WriteLine($"{result:f2}");
        }

        private static double DivideFactorials(double firstNum, double secondNum)
        {
            double firstNumFact = GetFactorial(firstNum);
            double secondNumFact = GetFactorial(secondNum);

            double result = firstNumFact / secondNumFact;

            return result;
        }

        private static double GetFactorial(double number)
        {
            double factoriel = 1;

            for (int i = 2; i <= number; i++)
            {
                factoriel = factoriel * i;
            }

            return factoriel;
        }
    }
}
