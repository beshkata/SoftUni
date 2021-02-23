using System;
using System.Collections.Generic;
using System.Linq;

namespace CardsGame
{
    class Program
    {
        static void Main()
        {
            List<int> firstPlayer = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            List<int> secondPlayer = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            while (firstPlayer.Count != 0 && secondPlayer.Count != 0)
            {
                if (firstPlayer[0] == secondPlayer[0])
                {
                    firstPlayer.RemoveAt(0);
                    secondPlayer.RemoveAt(0);
                }
                else if (firstPlayer[0] > secondPlayer[0])
                {
                    firstPlayer.Insert(firstPlayer.Count, firstPlayer[0]);
                    firstPlayer.Insert(firstPlayer.Count, secondPlayer[0]);
                    firstPlayer.RemoveAt(0);
                    secondPlayer.RemoveAt(0);
                }
                else
                {
                    secondPlayer.Insert(secondPlayer.Count, secondPlayer[0]);
                    secondPlayer.Insert(secondPlayer.Count, firstPlayer[0]);
                    firstPlayer.RemoveAt(0);
                    secondPlayer.RemoveAt(0);
                }
            }

            int sum = 0;
            if (firstPlayer.Count == 0)
            {
                sum = GetSum(secondPlayer);
                Console.WriteLine($"Second player wins! Sum: {sum}");
            }
            else
            {
                sum = GetSum(firstPlayer);
                Console.WriteLine($"First player wins! Sum: {sum}");
            }
        }

        private static int GetSum(List<int> cardDeck)
        {
            int sum = 0;
            foreach (int card in cardDeck)
            {
                sum += card;
            }
            return sum;
        }
    }
}
