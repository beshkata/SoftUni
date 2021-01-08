using System;

namespace _01._Number_Pyramid
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int numberToPrint = 1;

            for (int i = 1; i <= n; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (numberToPrint <= n)
                    {
                        Console.Write(numberToPrint + " ");
                    }
                    numberToPrint++;
                }
                Console.WriteLine();
                if (numberToPrint > n)
                {
                    break;
                }
            }
        }
    }
}
