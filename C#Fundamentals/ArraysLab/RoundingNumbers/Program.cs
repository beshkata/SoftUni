using System;
using System.Linq;

namespace RoundingNumbers
{
    class Program
    {
        static void Main()
        {
            double[] numbers = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();
            int[] numInt = new int[numbers.Length];
            for (int i = 0; i < numInt.Length; i++)
            {
                if (numbers[i] == 0)
                {
                    numbers[i] = 0;
                }
                numInt[i] = (int)Math.Round(numbers[i], MidpointRounding.AwayFromZero);
            }
            
            for (int i = 0; i < numbers.Length; i++)
            {
                Console.WriteLine($"{numbers[i]} => {numInt[i]}");
            }

        }
    }
}
