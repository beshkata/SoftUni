using System;

namespace _04._Sequence_2k_1
{
    class Program
    {
        static void Main()
        {
            int input = int.Parse(Console.ReadLine());

            int sum = 1;
            while (sum <= input)
            {
                Console.WriteLine(sum);
                sum = sum * 2 + 1;
            }
        }
    }
}
