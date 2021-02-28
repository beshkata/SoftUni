using System;
using System.Linq;

namespace ThirdProblem
{
    class Program
    {
        static void Main()
        {
            int[] items = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int entryPoint = int.Parse(Console.ReadLine());
            string typeOfItems = Console.ReadLine();

            int leftSum = 0;
            int rightSum = 0;

            if (typeOfItems == "expensive")
            {
                for (int i = entryPoint - 1; i >= 0; i--)
                {
                    if (items[i] >= items[entryPoint])
                    {
                        leftSum += items[i];
                    }
                }

                for (int i = entryPoint + 1; i < items.Length; i++)
                {
                    if (items[i] >= items[entryPoint])
                    {
                        rightSum += items[i];
                    }
                }
            }
            else
            {
                for (int i = entryPoint - 1; i >= 0; i--)
                {
                    if (items[i] < items[entryPoint])
                    {
                        leftSum += items[i];
                    }
                }

                for (int i = entryPoint + 1; i < items.Length; i++)
                {
                    if (items[i] < items[entryPoint])
                    {
                        rightSum += items[i];
                    }
                }
            }

            if (leftSum >= rightSum)
            {
                Console.WriteLine($"Left - {leftSum}");
            }
            else
            {
                Console.WriteLine($"Right - {rightSum}");
            }
        }
    }
}
