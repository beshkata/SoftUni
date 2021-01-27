using System;

namespace RoundingNumbers
{
    class Program
    {
        static void Main()
        {
            string strNumbers = Console.ReadLine();
            decimal[] numbers = Array.ConvertAll(strNumbers.Split(" "), arrTemp => Convert.ToDecimal(arrTemp));
            for (int i = 0; i < numbers.Length; i++)
            {
                Console.WriteLine($"{numbers[i]} => {Math.Round(numbers[i],MidpointRounding.AwayFromZero)}");
            }

        }
    }
}
