using System;
using System.Collections.Generic;
using System.Linq;

namespace Lootbox
{
    class Program
    {
        static void Main(string[] args)
        {
            int result = 0;

            int[] firstNumbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int[] secondNumbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<int> firstBox = new Queue<int>(firstNumbers);
            Stack<int> secondBox = new Stack<int>(secondNumbers);

            while (true)
            {
                if (firstBox.Count == 0)
                {
                    Console.WriteLine("First lootbox is empty");
                    break;
                }
                if (secondBox.Count == 0)
                {
                    Console.WriteLine("Second lootbox is empty");
                    break;
                }

                int firstNum = firstBox.Peek();
                int secondNum = secondBox.Peek();

                if ((firstNum + secondNum) % 2 == 0)
                {
                    result += firstNum + secondNum;
                    firstBox.Dequeue();
                    secondBox.Pop();
                }
                else
                {
                    firstBox.Enqueue(secondBox.Pop());
                }
            }
            if (result >= 100)
            {
                Console.WriteLine($"Your loot was epic! Value: {result}");
            }
            else
            {
                Console.WriteLine($"Your loot was poor... Value: {result}");
            }
        }
    }
}
