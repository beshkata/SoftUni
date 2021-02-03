using System;
using System.Linq;

namespace LadyBugs
{
    class Program
    {
        static void Main()
        {
            int fieldSize = int.Parse(Console.ReadLine());
            int[] initialBugIndexes = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            bool[] field = new bool[fieldSize];

            foreach (var item in initialBugIndexes)
            {
                if (item >= 0 && item < field.Length)
                {
                    field[item] = true;
                }
            }

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "end")
                {
                    break;
                }

                string[] commands = command.Split();
                int bugIndex = int.Parse(commands[0]);
                string direction = commands[1];
                int bugSpeed = int.Parse(commands[2]);

                if (bugIndex < 0 || bugIndex > field.Length - 1 || field[bugIndex] == false)
                {
                    continue;
                }

                field[bugIndex] = false;

                while (true)
                {
                    if (direction == "right")
                    {
                        bugIndex += bugSpeed;
                    }
                    else
                    {
                        bugIndex -= bugSpeed;
                    }
                    if (bugIndex < 0 || bugIndex > field.Length - 1)
                    {
                        break;
                    }
                    if (field[bugIndex] == false)
                    {
                        field[bugIndex] = true;
                        break;
                    }
                }
            }
            foreach (var item in field)
            {
                if (item)
                {
                    Console.Write("1 ");
                }
                else
                {
                    Console.Write("0 ");
                }
            }
        }
    }
}
