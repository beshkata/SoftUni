using System;

namespace _04._Walking
{
    class Program
    {
        static void Main()
        {
            const int goal = 10000;
            int stepCounter = 0;
            string input = String.Empty;

            while (stepCounter < goal)
            {
                input = Console.ReadLine();
                if (input == "Going home")
                {
                    stepCounter += int.Parse(Console.ReadLine());
                    break;
                }
                else
                {
                    stepCounter += int.Parse(input);
                }

            }
            if (input == "Going home" && stepCounter < 10000)
            {
                Console.WriteLine($"{goal - stepCounter} more steps to reach goal.");
            }
            else
            {
                Console.WriteLine("Goal reached! Good job!");
                Console.WriteLine($"{stepCounter - goal} steps over the goal!");
            }
        }
    }
}
