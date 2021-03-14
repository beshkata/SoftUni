using System;
using System.Collections.Generic;

namespace MultiplyBigNumber
{
    class Program
    {
        static void Main()
        {
            string number = Console.ReadLine();
            int multyplier = int.Parse(Console.ReadLine());

            List<string> result = new List<string>();
            int remainder = 0;

            for (int i = number.Length - 1; i >= 0; i--)
            {
                int currentDigit = number[i] - '0';

                remainder += currentDigit * multyplier;

                if (remainder <= 9)
                {
                    result.Add(remainder.ToString());
                    remainder = 0;
                }
                else
                {
                    result.Add((remainder % 10).ToString());
                    remainder /= 10;
                }
            }

            if (remainder > 0)
            {
                result.Add(remainder.ToString());
            }

            result.Reverse();
            Console.WriteLine(string.Concat(result));
        }
    }
}
