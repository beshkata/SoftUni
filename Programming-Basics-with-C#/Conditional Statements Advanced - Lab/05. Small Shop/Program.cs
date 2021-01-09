using System;

namespace _05._Small_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            int row = 0;
            int col = 0;

            string type = Console.ReadLine();
            string town = Console.ReadLine();
            decimal num = decimal.Parse(Console.ReadLine());

            switch (town)
            {
                case "Sofia":
                    row = 0;
                    break;
                case "Plovdiv":
                    row = 1;
                    break;
                case "Varna":
                    row = 2;
                    break;
                default:
                    Console.WriteLine("Wrong town.");
                    break;
            }
            switch (type)
            {
                case "coffe":
                    col = 0;
                    break;
                case "water":
                    col = 1;
                    break;
                case "beer":
                    col = 2;
                    break;
                case "sweets":
                    col = 3;
                    break;
                case "peanuts":
                    col = 4;
                    break;
                default:
                    Console.WriteLine("Wrong product type");
                    break;
            }

            decimal[,] matrix = { { 0.5m, 0.8m, 1.2m, 1.45m, 1.60m },
                                     { 0.40m, 0.70m, 1.15m, 1.30m, 1.50m},
                                     { 0.45m, 0.70m, 1.10m, 1.35m, 1.55m}
                                    };

            Console.WriteLine(matrix[row, col] * num);
        }
    }
}
