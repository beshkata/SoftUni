using System;
using System.Linq;

namespace FoldAndSum
{
    class Program
    {
        static void Main()
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int[] firstArr = new int[numbers.Length / 2];
            int[] secondArr = new int[numbers.Length / 2];
            int[] result = new int[numbers.Length / 2];
            int counter = 0;

            for (int i = (numbers.Length / 4)-1; i >=0 ; i--)
            {
                firstArr[counter] = numbers[i];
                counter++;
            }
            for (int i = numbers.Length-1 ; i >= numbers.Length - numbers.Length / 4; i--)
            {
                firstArr[counter] = numbers[i];
                counter++;
            }

            counter = 0;
            for (int i = (numbers.Length / 4); i <= numbers.Length - numbers.Length / 4 - 1; i++)
            {
                secondArr[counter] = numbers[i];
                counter++;
            }

            for (int i = 0; i < result.Length; i++)
            {
                result[i] = firstArr[i] + secondArr[i];
            }
            Console.WriteLine(string.Join(' ', result));
        }
    }
}
