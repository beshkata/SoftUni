using System;

namespace _05._Suitcases_Load
{
    //Solution for 90/100 points according to https://judge.softuni.bg/
    class Program
    {
        static void Main(string[] args)
        {
            double capacity = double.Parse(Console.ReadLine());
            string input = Console.ReadLine();

            int suitcasesCounter = 0;
            double loadedSpace = 0.0;

            while (input != "End")
            {
                if (loadedSpace + double.Parse(input) > capacity)
                {
                    loadedSpace += double.Parse(input);
                    break;
                }
                else
                {
                    loadedSpace += double.Parse(input);
                    suitcasesCounter++;
                    if (suitcasesCounter % 3 == 0)
                    {
                        loadedSpace += double.Parse(input) * 0.1;
                    }
                }
                input = Console.ReadLine();
            }

            if (loadedSpace <= capacity)
            {
                Console.WriteLine("Congratulations! All suitcases are loaded!");
            }
            else
            {
                Console.WriteLine("No more space!");
            }
            Console.WriteLine($"Statistic: {suitcasesCounter} suitcases loaded.");
        }
    }
}
