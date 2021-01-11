using System;

namespace _05._Divide_Without_Remainder
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int p1 = 0;
            int p2 = 0;
            int p3 = 0;

            for (int i = 0; i < n; i++)
            {
                int currentNum = int.Parse(Console.ReadLine());
                if (currentNum % 2 == 0)
                {
                    p1++;
                }
                if (currentNum % 3 == 0)
                {
                    p2++;
                }
                if (currentNum % 4 == 0)
                {
                    p3++;
                }
            }
            Console.WriteLine($"{(double)p1 / n * 100:f2}%");
            Console.WriteLine($"{(double)p2 / n * 100:f2}%");
            Console.WriteLine($"{(double)p3 / n * 100:f2}%");
        }
    }
}
