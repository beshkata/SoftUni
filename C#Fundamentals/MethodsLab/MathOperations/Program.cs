using System;

namespace MathOperations
{
    class Program
    {
        static void Main()
        {
            double firstNumber = double.Parse(Console.ReadLine());
            string operationSign = Console.ReadLine();
            double secondNumber = double.Parse(Console.ReadLine());

            double result = Calculate(firstNumber, operationSign, secondNumber);

            Console.WriteLine(Math.Round(result, 2));
        }

        private static double Calculate(double firstNumber, string operationSign, double secondNumber)
        {
            double result = 0.0;

            switch (operationSign)
            {
                case "+":
                    result = firstNumber + secondNumber;
                    break;
                case "*":
                    result = firstNumber * secondNumber;
                    break;
                case "-":
                    result = firstNumber - secondNumber;
                    break;
                case "/":
                    result = firstNumber / secondNumber;
                    break;
                default:
                    Console.WriteLine("Wrong operation sign");
                    break;
            }

            return result;
        }
    }
}
