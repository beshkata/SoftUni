using System;

namespace _03._Energy_Booster
{
    class Program
    {
        static void Main()
        {
            string fruit = Console.ReadLine();
            string size = Console.ReadLine();
            int number = int.Parse(Console.ReadLine());

            double totalPrice = 0.0;

            if (size == "small")
            {
                switch (fruit)
                {
                    case "Watermelon":
                        totalPrice = 2 * 56.0 * number;
                        break;

                    case "Mango":
                        totalPrice = 2 * 36.66 * number;
                        break;

                    case "Pineapple":
                        totalPrice = 2 * 42.10 * number;
                        break;

                    case "Raspberry":
                        totalPrice = 2 * 20.0 * number;
                        break;
                }
            }
            else
            {
                switch (fruit)
                {
                    case "Watermelon":
                        totalPrice = 5 * 28.70 * number;
                        break;

                    case "Mango":
                        totalPrice = 5 * 19.60 * number;
                        break;

                    case "Pineapple":
                        totalPrice = 5 * 24.80 * number;
                        break;

                    case "Raspberry":
                        totalPrice = 5 * 15.20 * number;
                        break;
                }

            }

            if (totalPrice >= 400 && totalPrice <= 1000)
            {
                totalPrice = totalPrice - totalPrice * 0.15;
            }
            if (totalPrice > 1000)
            {
                totalPrice = totalPrice - totalPrice * 0.5;
            }
            Console.WriteLine($"{totalPrice:f2} lv.");
        }
    }
}
