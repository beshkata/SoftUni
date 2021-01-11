using System;

namespace _07._Hotel_Room
{
    class Program
    {
        static void Main(string[] args)
        {
            string month = Console.ReadLine();
            int nightsCount = int.Parse(Console.ReadLine());

            switch (month)
            {
                case "May":
                case "October":
                    if (nightsCount > 7 && nightsCount <= 14)
                    {
                        Console.WriteLine("Apartment: {0:f2} lv.", nightsCount * 65.00);
                        Console.WriteLine("Studio: {0:f2} lv.", nightsCount * (50.00 - (50 * 0.05)));
                    }
                    else if (nightsCount > 14)
                    {
                        Console.WriteLine("Apartment: {0:f2} lv.", nightsCount * (65.00 - (65.00 * 0.1)));
                        Console.WriteLine("Studio: {0:f2} lv.", nightsCount * (50.00 - (50 * 0.3)));

                    }
                    else
                    {
                        Console.WriteLine("Apartment: {0:f2} lv.", nightsCount * 65.00);
                        Console.WriteLine("Studio: {0:f2} lv.", nightsCount * 50.00);
                    }
                    break;
                case "June":
                case "September":
                    if (nightsCount > 14)
                    {
                        Console.WriteLine("Apartment: {0:f2} lv.", nightsCount * (68.70 - (68.70 * 0.1)));
                        Console.WriteLine("Studio: {0:f2} lv.", nightsCount * (75.20 - (75.20 * 0.2)));
                    }
                    else
                    {
                        Console.WriteLine("Apartment: {0:f2} lv.", nightsCount * 68.70);
                        Console.WriteLine("Studio: {0:f2} lv.", nightsCount * 75.20);
                    }
                    break;
                case "July":
                case "August":
                    if (nightsCount > 14)
                    {
                        Console.WriteLine("Apartment: {0:f2} lv.", nightsCount * (77.00 - (77.00 * 0.1)));
                        Console.WriteLine("Studio: {0:f2} lv.", nightsCount * 76.00);
                    }
                    else
                    {
                        Console.WriteLine("Apartment: {0:f2} lv.", nightsCount * 77.00);
                        Console.WriteLine("Studio: {0:f2} lv.", nightsCount * 76.00);
                    }
                    break;
            }
        }
    }
}
