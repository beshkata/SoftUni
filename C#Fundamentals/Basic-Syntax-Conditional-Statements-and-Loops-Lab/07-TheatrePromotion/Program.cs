using System;

namespace _07_TheatrePromotion
{
    class Program
    {
        static void Main()
        {
            string typeOfDay = Console.ReadLine().ToLower();
            int age = int.Parse(Console.ReadLine());

            if (age > 122 || age < 0)
            {
                Console.WriteLine("Error!");
            }
            else if (typeOfDay == "Weekday")
            {
                if((age <= 18 && age >= 0) || (age > 64 && age <= 122))
                {
                    Console.WriteLine("12$");
                }
                else
                {
                    Console.WriteLine("18$");
                }
            }
            else if (typeOfDay == "Weekend")
            {
                if ((age <= 18 && age >= 0) || (age > 64 && age <= 122))
                {
                    Console.WriteLine("15$");
                }
                else
                {
                    Console.WriteLine("20$");
                }
            }
            else if (typeOfDay == "Holiday")
            {
                if (age <= 18 && age >= 0)
                {
                    Console.WriteLine("5$");
                }
                else if (age > 64 && age <= 122)
                {
                    Console.WriteLine("10$");
                }
                else
                {
                    Console.WriteLine("12$");
                }
            }

        }
    }
}
