using System;
using System.Linq;

namespace TopIntegers
{
    class Program
    {
        static void Main()
        {
            int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            bool isTopInt = true;
            string topInts = "";

            for (int i = 0; i < numbers.Length; i++)
            {
                for (int j = i +1; j < numbers.Length; j++)
                {
                    if (numbers[i] <= numbers[j])
                    {
                        isTopInt = false;
                        break;
                    }
                }
                if (isTopInt)
                {
                    topInts += numbers[i] + " ";
                }
                isTopInt = true;
            }
            Console.WriteLine(topInts);
        }
    }
}
