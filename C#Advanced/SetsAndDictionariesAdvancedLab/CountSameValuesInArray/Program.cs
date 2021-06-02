using System;
using System.Collections.Generic;
using System.Linq;

namespace CountSameValuesInArray
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray();

            Dictionary<double, int> numbersByRepetition = new Dictionary<double, int>();

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbersByRepetition.ContainsKey(numbers[i]) == false)
                {
                    numbersByRepetition.Add(numbers[i], 0);
                }

                numbersByRepetition[numbers[i]]++;
            }

            foreach (var number in numbersByRepetition)
            {
                Console.WriteLine($"{number.Key} - {number.Value} times" );
            }
        }
    }
}
