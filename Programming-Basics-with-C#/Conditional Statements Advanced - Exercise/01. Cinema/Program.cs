using System;

namespace _01._Cinema
{
    class Program
    {
        static void Main(string[] args)
        {
            string type = Console.ReadLine();
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());
            decimal income = 0m;

            if (type == "Premiere")
            {
                income = rows * cols * 12m;
                Console.WriteLine("{0:f2} leva", income);
            }
            else if (type == "Normal")
            {
                income = rows * cols * 7.5m;
                Console.WriteLine("{0:f2} leva", income);
            }
            else
            {
                income = rows * cols * 5m;
                Console.WriteLine("{0:f2} leva", income);
            }
        }
    }
}
