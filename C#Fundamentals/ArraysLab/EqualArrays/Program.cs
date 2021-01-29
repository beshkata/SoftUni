using System;
using System.Linq;

namespace EqualArrays
{
    class Program
    {
        static void Main()
        {
            int[] firstArr = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[] secondArr = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int sum = 0;
            bool areEqual = true;
            int index = -1;

            for (int i = 0; i < firstArr.Length; i++)
            {
                if (firstArr[i] != secondArr[i])
                {
                    areEqual = false;
                    index = i;
                    break;
                }
                sum += firstArr[i];
            }

            if (areEqual)
            {
                Console.WriteLine($"Arrays are identical. Sum: {sum}");
            }
            else
            {
                Console.WriteLine($"Arrays are not identical. Found difference at {index} index");
            }
        }
    }
}
