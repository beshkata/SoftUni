using System;

namespace _03._Easter_Trip
{
    class Program
    {
        static void Main()
        {
            string destination = Console.ReadLine();
            string dates = Console.ReadLine();
            int nights = int.Parse(Console.ReadLine());
            double price = 0;

            if (dates == "21-23")
            {
                switch (destination)
                {
                    case "France":
                        price = nights * 30;
                        break;
                    case "Italy":
                        price = nights * 28;
                        break;
                    case "Germany":
                        price = nights * 32;
                        break;
                }
            }
            else if (dates == "24-27")
            {
                switch (destination)
                {
                    case "France":
                        price = nights * 35;
                        break;
                    case "Italy":
                        price = nights * 32;
                        break;
                    case "Germany":
                        price = nights * 37;
                        break;
                }
            }
            else
            {
                switch (destination)
                {
                    case "France":
                        price = nights * 40;
                        break;
                    case "Italy":
                        price = nights * 39;
                        break;
                    case "Germany":
                        price = nights * 43;
                        break;
                }
            }

            Console.WriteLine($"Easter trip to {destination} : {price:f2} leva.");
        }
    }
}
