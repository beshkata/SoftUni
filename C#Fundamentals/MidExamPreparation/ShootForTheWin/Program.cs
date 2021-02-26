using System;
using System.Linq;

namespace ShootForTheWin
{
    class Program
    {
        static void Main()
        {
            int[] targets = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int shotTargets = 0;

            string input = Console.ReadLine();

            while (input != "End")
            {
                int index = int.Parse(input);

                if (index >= 0 && index < targets.Length && targets[index] != -1)
                {
                    int number = targets[index];
                    targets[index] = -1;
                    shotTargets++;

                    for (int i = 0; i < targets.Length; i++)
                    {
                        if (targets[i] != -1)
                        {
                            if (targets[i] <= number)
                            {
                                targets[i] += number;
                            }
                            else
                            {
                                targets[i] -= number;
                            }
                        }
                    }
                }
                input = Console.ReadLine();
            }

            Console.WriteLine($"Shot targets: {shotTargets} -> {string.Join(' ', targets)}");
        }
    }
}
