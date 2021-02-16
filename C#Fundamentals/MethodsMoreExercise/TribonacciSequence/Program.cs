using System;
using System.Collections.Generic;
using System.Text;

namespace TribonacciSequence
{
    class Program
    {
        private static bool isAdded = false;

        static void Main()
        {
            int num = int.Parse(Console.ReadLine());

            PrintTribonacciSequence(num);
        }

        private static void PrintTribonacciSequence(int num)
        {
            List<int> tribonacciSeq = new List<int>();
            
            for (int i = 1; i <= num; i++)
            {
                if (i == 1 || i == 2)
                {
                    tribonacciSeq.Add(1);
                }
                else if (i == 3)
                {
                    tribonacciSeq.Add(2);
                }
                else
                {
                    tribonacciSeq.Add(tribonacciSeq[i- 2] + tribonacciSeq[i - 3] + tribonacciSeq[i - 4]);
                }
            }
            Console.WriteLine(string.Join(' ', tribonacciSeq));
        }

    }
}
