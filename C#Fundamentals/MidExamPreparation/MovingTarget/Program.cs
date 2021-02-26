using System;
using System.Collections.Generic;
using System.Linq;

namespace MovingTarget
{
    class Program
    {
        static void Main()
        {
            List<int> targets = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            string line = Console.ReadLine();

            while (line != "End")
            {
                string[] commands = line.Split();
                string command = commands[0];
                int index = int.Parse(commands[1]);

                switch (command)
                {
                    case "Shoot":
                        int power = int.Parse(commands[2]);
                        Shoot(targets, index, power);
                        break;
                    case "Add":
                        int targetValue = int.Parse(commands[2]);
                        AddTarget(targets, index, targetValue);
                        break;
                    case "Strike":
                        int radius = int.Parse(commands[2]);
                        Strike(targets, index, radius);
                        break;
                    default:
                        break;
                }

                line = Console.ReadLine();
            }

            Console.WriteLine(string.Join('|', targets));
        }

        private static void Strike(List<int> targets, int index, int radius)
        {
            if (index - radius < 0 || index + radius >= targets.Count)
            {
                Console.WriteLine("Strike missed!");
            }
            else
            {
                int strikeRange = 2 * radius + 1;
                targets.RemoveRange(index - radius, strikeRange);
            }
        }

        private static void AddTarget(List<int> targets, int index, int targetValue)
        {
            if (index >= 0 && index < targets.Count)
            {
                targets.Insert(index, targetValue);
            }
            else
            {
                Console.WriteLine("Invalid placement!");
            }
        }

        private static void Shoot(List<int> targets, int index, int power)
        {
            if (index >= 0 && index < targets.Count)
            {
                if (targets[index] - power <= 0)
                {
                    targets.RemoveAt(index);
                }
                else
                {
                    targets[index] -= power;
                }
            }
        }
    }
}
