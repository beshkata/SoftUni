using System;
using System.Collections.Generic;

namespace Orders
{
    class Program
    {
        static void Main()
        {
            Dictionary<string, double> priceToProducts = new Dictionary<string, double>();
            Dictionary<string, int> quantityToProducts = new Dictionary<string, int>();

            string line = Console.ReadLine();

            while (line != "buy")
            {
                string[] inputs = line.Split();
                string product = inputs[0];
                double price = double.Parse(inputs[1]);
                int quantity = int.Parse(inputs[2]);

                if (priceToProducts.ContainsKey(product) == false)
                {
                    priceToProducts.Add(product, 0.0);
                    quantityToProducts.Add(product, 0);
                }
                priceToProducts[product] = price;
                quantityToProducts[product] += quantity;

                line = Console.ReadLine();
            }

            foreach (var kvp in priceToProducts)
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value * quantityToProducts[kvp.Key]:f2}");
            }
        }
    }
}
