using System;
using System.Collections.Generic;

namespace _05._Easter_Eggs
{
    class Program
    {
        static void Main()
        {
            int paintedEggs = int.Parse(Console.ReadLine());

            int redEggsCounter = 0;
            int orangeEggsCounter = 0;
            int blueEggsCounter = 0;
            int greenEggsCounter = 0;

            string maxEggsColor = "";

            for (int i = 0; i < paintedEggs; i++)
            {
                string eggColor = Console.ReadLine();
                switch (eggColor)
                {
                    case "red":
                        redEggsCounter++;
                        break;
                    case "orange":
                        orangeEggsCounter++;
                        break;
                    case "blue":
                        blueEggsCounter++;
                        break;
                    case "green":
                        greenEggsCounter++;
                        break;
                }
            }
            if (redEggsCounter == FindBiggest(redEggsCounter, orangeEggsCounter, blueEggsCounter, greenEggsCounter))
            {
                maxEggsColor = "red";
            }
            else if (orangeEggsCounter == FindBiggest(redEggsCounter, orangeEggsCounter, blueEggsCounter, greenEggsCounter))
            {
                maxEggsColor = "orange";
            }
            else if (blueEggsCounter == FindBiggest(redEggsCounter, orangeEggsCounter, blueEggsCounter, greenEggsCounter))
            {
                maxEggsColor = "blue";
            }
            else
            {
                maxEggsColor = "green";
            }

            Console.WriteLine($"Red eggs: {redEggsCounter}");
            Console.WriteLine($"Orange eggs: {orangeEggsCounter}");
            Console.WriteLine($"Blue eggs: {blueEggsCounter}");
            Console.WriteLine($"Green eggs: {greenEggsCounter}");
            Console.WriteLine($"Max eggs: {FindBiggest(redEggsCounter, orangeEggsCounter, blueEggsCounter, greenEggsCounter)} -> {maxEggsColor}");
        }

        static int FindBiggest(int one, int two, int three, int four)
        {
            List<int> list = new List<int>();
            list.Add(one);
            list.Add(two);
            list.Add(three);
            list.Add(four);

            list.Sort();
            return list[list.Count - 1];
        }
    }
}
