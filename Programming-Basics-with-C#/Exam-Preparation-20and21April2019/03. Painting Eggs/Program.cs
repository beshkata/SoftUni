using System;

namespace _03._Painting_Eggs
{
    class Program
    {
        static void Main()
        {
            string eggsSize = Console.ReadLine();
            string eggsColor = Console.ReadLine();
            int number = int.Parse(Console.ReadLine());

            double profit = 0.0;

            if (eggsSize == "Large")
            {
                switch (eggsColor)
                {
                    case "Red":
                        profit = number * 16 * 1.0;
                        break;
                    case "Green":
                        profit = number * 12 * 1.0;
                        break;
                    case "Yellow":
                        profit = number * 9 * 1.0;
                        break;
                }
            }
            else if (eggsSize == "Medium")
            {
                switch (eggsColor)
                {
                    case "Red":
                        profit = number * 13 * 1.0;
                        break;
                    case "Green":
                        profit = number * 9 * 1.0;
                        break;
                    case "Yellow":
                        profit = number * 7 * 1.0;
                        break;
                }
            }
            else
            {
                switch (eggsColor)
                {
                    case "Red":
                        profit = number * 9 * 1.0;
                        break;
                    case "Green":
                        profit = number * 8 * 1.0;
                        break;
                    case "Yellow":
                        profit = number * 5 * 1.0;
                        break;
                }
            }

            profit = profit - profit * 0.35;

            Console.WriteLine($"{profit:f2} leva.");
        }
    }
}
