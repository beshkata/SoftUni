using System;

namespace SmallestOfThreeNumbers
{
    class Program
    {
        static void Main()
        {
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());
            int thirdNumber = int.Parse(Console.ReadLine());

            int smallestNum = GetMinNum(firstNumber, secondNumber, thirdNumber);
            Console.WriteLine(smallestNum);
        }

        private static int GetMinNum(int firstNumber, int secondNumber, int thirdNumber)
        {
            return Math.Min(Math.Min(firstNumber, secondNumber), thirdNumber);
        }
    }
}
