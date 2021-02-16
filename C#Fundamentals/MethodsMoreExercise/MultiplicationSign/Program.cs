using System;

namespace MultiplicationSign
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            int num3 = int.Parse(Console.ReadLine());

            Console.WriteLine(GetMultiplicationSign(num1, num2, num3));
        }

        private static string GetMultiplicationSign(int num1, int num2, int num3)
        {
            if (num1 == 0 || num2 == 0 || num3 == 0)
            {
                return "zero";
            }
            else
            {
                int negativeNumCount = 0;
                int[] nums = { num1, num2, num3 };
                for (int i = 0; i < 3; i++)
                {
                    if (nums[i] < 0)
                    {
                        negativeNumCount++;
                    }
                }
                if (negativeNumCount % 2 == 1)
                {
                    return "negative";
                }
                else
                {
                    return "positive";
                }
            }
        }
    }
}
