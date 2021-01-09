using System;

namespace _06._Easter_Competition
{
    class Program
    {
        static void Main()
        {
            int kozunakNum = int.Parse(Console.ReadLine());

            string bestChef = "";
            int bestChefPoints = 0;

            for (int i = 0; i < kozunakNum; i++)
            {
                string chefName = Console.ReadLine();

                string input = Console.ReadLine();

                int currentChefPoints = 0;

                while (input != "Stop")
                {
                    currentChefPoints += int.Parse(input);

                    input = Console.ReadLine();
                }
                Console.WriteLine($"{chefName} has {currentChefPoints} points.");
                if (bestChefPoints < currentChefPoints)
                {
                    Console.WriteLine($"{chefName} is the new number 1!");
                    bestChefPoints = currentChefPoints;
                    bestChef = chefName;
                }
            }
            Console.WriteLine($"{bestChef} won competition with {bestChefPoints} points!");
        }
    }
}
