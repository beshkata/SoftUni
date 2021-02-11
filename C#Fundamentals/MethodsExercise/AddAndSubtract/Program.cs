using System;

namespace AddAndSubtract
{
    class Program
    {
        static void Main()
        {
            int firstNum = int.Parse(Console.ReadLine());
            int secondNum = int.Parse(Console.ReadLine());
            int thirdNum = int.Parse(Console.ReadLine());

            int result = GetDifference(GetSum(firstNum, secondNum), thirdNum);

            Console.WriteLine(result);
        }

        private static int GetSum(int firstNumber, int secondNumber)
        {
            return firstNumber + secondNumber;
        }

        private static int GetDifference(int firstNumber, int secondNumber)
        {
            return firstNumber - secondNumber;
        }
    }
}
