using System;

namespace PrintingTriangle
{
    class Program
    {
        static void Main()
        {
            int number = int.Parse(Console.ReadLine());

            PrintTriangle(number);
        }

        private static void PrintTriangle(int number)
        {
            for (int i = 1; i <= number; i++)
            {
                PrintLine(i);
                Console.WriteLine();
            }

            for (int i = number - 1; i > 0; i--)
            {
                PrintLine(i);
                Console.WriteLine();
            }
        }

        private static void PrintLine(int endNumber)
        {
            for (int i = 1; i <= endNumber; i++)
            {
                Console.Write($"{i} ");
            }
        }
    }
}
