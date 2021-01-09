using System;

namespace _03._Santas_Holiday
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            string room = Console.ReadLine();
            string grade = Console.ReadLine();

            double price = 0;

            if (room == "room for one person")
            {
                price = (days - 1) * 18.0;
            }
            else if (room == "apartment")
            {
                price = (days - 1) * 25.0;
            }
            else
            {
                price = (days - 1) * 35.0;
            }

            if (days < 10)
            {
                switch (room)
                {
                    case "apartment":
                        price = price - price * 0.3;
                        break;
                    case "president apartment":
                        price = price - price * 0.1;
                        break;
                }
            }
            else if (days < 16)
            {
                switch (room)
                {
                    case "apartment":
                        price = price - price * 0.35;
                        break;
                    case "president apartment":
                        price = price - price * 0.15;
                        break;
                }
            }
            else
            {
                switch (room)
                {
                    case "apartment":
                        price = price - price * 0.5;
                        break;
                    case "president apartment":
                        price = price - price * 0.2;
                        break;
                }
            }

            if (grade == "positive")
            {
                price = price + price * 0.25;
            }
            else
            {
                price = price - price * 0.1;
            }

            Console.WriteLine($"{price:f2}");
        }
    }
}
