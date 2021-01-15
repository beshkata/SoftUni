using System;

namespace _03_Vacation
{
    class Program
    {
        static void Main()
        {
            int personsCount = int.Parse(Console.ReadLine());
            string typeOfGroup = Console.ReadLine().ToLower();
            string dayOfWeek = Console.ReadLine().ToLower();

            double singlePrice = 0.0;
            double totalPrice = 0.0;

            if (typeOfGroup == "students")
            {
                if (dayOfWeek == "friday")
                {
                    singlePrice = 8.45;
                }
                else if (dayOfWeek == "saturday")
                {
                    singlePrice = 9.80;
                }
                else if (dayOfWeek == "sunday")
                {
                    singlePrice = 10.46;
                }
                totalPrice = singlePrice * personsCount;
                if (personsCount >= 30)
                {
                    totalPrice *= 0.85;
                }
            }
            else if (typeOfGroup == "business")
            {
                if (dayOfWeek == "friday")
                {
                    singlePrice = 10.90;
                }
                else if (dayOfWeek == "saturday")
                {
                    singlePrice = 15.60;
                }
                else if (dayOfWeek == "sunday")
                {
                    singlePrice = 16.00;
                }
                if (personsCount >= 100)
                {
                    personsCount -= 10;
                }
                totalPrice = singlePrice * personsCount;
            }
            else if (typeOfGroup == "regular")
            {
                if (dayOfWeek == "friday")
                {
                    singlePrice = 15.00;
                }
                else if (dayOfWeek == "saturday")
                {
                    singlePrice = 20.00;
                }
                else if (dayOfWeek == "sunday")
                {
                    singlePrice = 22.50;
                }
                totalPrice = singlePrice * personsCount;
                if (personsCount >= 10 && personsCount <=20)
                {
                    totalPrice *= 0.95;
                }
            }
            Console.WriteLine($"Total price: {totalPrice:f2}");
        }
    }
}
