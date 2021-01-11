using System;

namespace _03._Computer_Room
{
    class Program
    {
        static void Main(string[] args)
        {
            string month = Console.ReadLine();
            int hours = int.Parse(Console.ReadLine());
            int numPeople = int.Parse(Console.ReadLine());
            string timeOfDay = Console.ReadLine();

            double pricePerPerson = 0;

            if (timeOfDay == "day")
            {
                switch (month)
                {
                    case "march":
                    case "april":
                    case "may":
                        pricePerPerson = 10.50;
                        break;
                    case "june":
                    case "july":
                    case "august":
                        pricePerPerson = 12.60;
                        break;
                }
            }
            else
            {
                switch (month)
                {
                    case "march":
                    case "april":
                    case "may":
                        pricePerPerson = 8.40;
                        break;
                    case "june":
                    case "july":
                    case "august":
                        pricePerPerson = 10.20;
                        break;
                }
            }
            if (numPeople >= 4)
            {
                pricePerPerson -= pricePerPerson * 0.1;
            }
            if (hours >= 5)
            {
                pricePerPerson -= pricePerPerson * 0.5;
            }


            Console.WriteLine($"Price per person for one hour: {pricePerPerson:f2}");
            Console.WriteLine($"Total cost of the visit: {pricePerPerson * hours * numPeople:f2}");
        }
    }
}
