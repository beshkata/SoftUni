using System;

namespace NxNMatrix
{
    class Program
    {
        static void Main()
        {
            int num = int.Parse(Console.ReadLine());

            PrintMatrix(num);

        }

        private static void PrintMatrix(int num)
        {
            for (int i = 0; i < num; i++)
            {
                for (int j = 0; j < num; j++)
                {
                    Console.Write($"{num} ");
                }
                Console.WriteLine();
            }
        }
    }
}
