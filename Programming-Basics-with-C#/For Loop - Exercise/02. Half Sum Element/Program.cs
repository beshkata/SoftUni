using System;

namespace _02._Half_Sum_Element
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            int biggestNum = 0;
            int sum = 0;

            for (int i = 0; i < n; i++)
            {
                int currentNum = int.Parse(Console.ReadLine());

                if (currentNum > biggestNum)
                {
                    biggestNum = currentNum;
                }

                sum += currentNum;
            }

            if (sum - biggestNum == biggestNum)
            {
                Console.WriteLine("Yes");
                Console.WriteLine($"Sum = {biggestNum}");
            }
            else
            {
                Console.WriteLine("No");
                Console.WriteLine($"Diff = {Math.Abs((sum - biggestNum) - biggestNum)}");
            }
        }
    }
}
