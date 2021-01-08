using System;

namespace _03._Fitness_Card
{
    class Program
    {
        static void Main()
        {
            double money = double.Parse(Console.ReadLine());
            string sex = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            string sport = Console.ReadLine();

            double price = 0;

            if (sex == "m")
            {
                switch (sport)
                {
                    case "Gym":
                        price = 42.0;
                        break;
                    case "Boxing":
                        price = 41.0;
                        break;
                    case "Yoga":
                        price = 45.0;
                        break;
                    case "Zumba":
                        price = 34.0;
                        break;
                    case "Dances":
                        price = 51.0;
                        break;
                    case "Pilates":
                        price = 39.0;
                        break;
                }
            }
            else
            {
                switch (sport)
                {
                    case "Gym":
                        price = 35.0;
                        break;
                    case "Boxing":
                        price = 37.0;
                        break;
                    case "Yoga":
                        price = 42.0;
                        break;
                    case "Zumba":
                        price = 31.0;
                        break;
                    case "Dances":
                        price = 53.0;
                        break;
                    case "Pilates":
                        price = 37.0;
                        break;
                }
            }
            if (age < 20)
            {
                price -= price * 0.2;
            }
            if (money >= price)
            {
                Console.WriteLine($"You purchased a 1 month pass for {sport}.");
            }
            else
            {
                Console.WriteLine($"You don't have enough money! You need ${price - money:f2} more.");
            }
        }
    }
}
