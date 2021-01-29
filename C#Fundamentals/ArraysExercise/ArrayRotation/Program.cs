using System;
using System.Linq;

namespace ArrayRotation
{
    class Program
    {
        static void Main()
        {
            int[] numbersArr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int rotations = int.Parse(Console.ReadLine());

            for (int i = 0; i < rotations; i++)
            {
                int[] tempArr = new int[numbersArr.Length];

                for (int j = 0; j < numbersArr.Length; j++)
                {
                    if (j == 0)
                    {
                        tempArr[tempArr.Length - 1] = numbersArr[j];
                    }
                    else
                    {
                        tempArr[j - 1] = numbersArr[j];
                    }
                }
                numbersArr = tempArr;
            }
            Console.WriteLine(string.Join(' ', numbersArr));
        }
    }
}
