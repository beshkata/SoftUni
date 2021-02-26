using System;

namespace ComputerStore
{
    class Program
    {
        static void Main()
        {
            double priceWithoutTaxes = 0.0;

            string input = Console.ReadLine();

            while (double.TryParse(input, out double price))
            {
                if (price < 0)
                {
                    Console.WriteLine("Invalid price!");
                    input = Console.ReadLine();
                    continue;
                }

                priceWithoutTaxes += price;

                input = Console.ReadLine();
            }

            if (priceWithoutTaxes == 0)
            {
                Console.WriteLine("Invalid order!");
                return;
            }

            double taxes = priceWithoutTaxes * 0.2;
            double finalPrice = taxes + priceWithoutTaxes;

            if (input == "special")
            {
                finalPrice *= 0.9;
            }

            Console.WriteLine("Congratulations you've just bought a new computer!");
            Console.WriteLine($"Price without taxes: {priceWithoutTaxes:f2}$");
            Console.WriteLine($"Taxes: {taxes:f2}$");
            Console.WriteLine("-----------");
            Console.WriteLine($"Total price: {finalPrice:f2}$");
        }
    }
}
