using System;

namespace RefactorSpecialNumbers
{
    class Program
    {
        static void Main()
        {
            int number = int.Parse(Console.ReadLine());
            for (int i = 1; i <= number; i++)
            {
                int digitSum = 0;
                int currentNumber = i;
                while (currentNumber > 0)
                {
                    digitSum += currentNumber % 10;
                    currentNumber = currentNumber / 10;
                }
                bool isNumberSpecial = (digitSum == 5) || (digitSum == 7) || (digitSum == 11);
                Console.WriteLine("{0} -> {1}", i, isNumberSpecial);
                
            }

        }
    }
}
