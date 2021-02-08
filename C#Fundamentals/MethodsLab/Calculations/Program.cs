using System;

namespace Calculations
{
    class Program
    {
        static void Main()
        {
            string command = Console.ReadLine();
            double firstNumber = double.Parse(Console.ReadLine());
            double secondNumber = double.Parse(Console.ReadLine());

            switch (command)
            {
                case "add":
                    PrintSum(firstNumber, secondNumber);
                    break;
                case "multiply":
                    PrintMultiplication(firstNumber, secondNumber);
                    break;
                case "subtract":
                    PrintSubstraction(firstNumber, secondNumber);
                    break;
                case "divide":
                    PrintDivision(firstNumber, secondNumber);
                    break;
                default:
                    Console.WriteLine("Wrong command");
                    break;
            }
        }

        private static void PrintDivision(double firstNumber, double secondNumber)
        {
            Console.WriteLine(firstNumber/secondNumber);
        }

        private static void PrintSubstraction(double firstNumber, double secondNumber)
        {
            Console.WriteLine(firstNumber - secondNumber);
        }

        private static void PrintMultiplication(double firstNumber, double secondNumber)
        {
            Console.WriteLine(firstNumber * secondNumber);
        }

        private static void PrintSum(double firstNumber, double secondNumber)
        {
            Console.WriteLine(firstNumber + secondNumber);
        }
    }
}
