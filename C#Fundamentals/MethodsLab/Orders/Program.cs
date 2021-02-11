using System;

namespace Orders
{
    class Program
    {
        static void Main()
        {
            string product = Console.ReadLine();
            int quantity = int.Parse(Console.ReadLine());

            double result = GetTotalPrice(product, quantity);
            Console.WriteLine($"{result:f2}");
        }

        private static double GetTotalPrice(string product, int quantity)
        {
            double singlePrice = 0.0;

            switch (product)
            {
                case "coffee":
                    singlePrice = 1.50;
                    break;
                case "water":
                    singlePrice = 1.00;
                    break;
                case "coke":
                    singlePrice = 1.40;
                    break;
                case "snacks":
                    singlePrice = 2.00;
                    break;
                default:
                    Console.WriteLine("Wrong product!");
                    break;
            }
            return singlePrice * quantity;
        }
    }
}
