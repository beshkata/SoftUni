using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingList
{
    class Program
    {
        static void Main()
        {
            List<string> shopingList = Console.ReadLine()
                .Split('!', StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string line = Console.ReadLine();

            while (line != "Go Shopping!")
            {
                string[] commands = line.Split();
                string command = commands[0];
                string item = commands[1];

                switch (command)
                {
                    case "Urgent":
                        Urgent(shopingList, item);
                        break;
                    case "Unnecessary":
                        Unnecessary(shopingList, item);
                        break;
                    case "Correct":
                        string newItem = commands[2];
                        Correct(shopingList, item, newItem);
                        break;
                    case "Rearrange":
                        Rearrange(shopingList, item);
                        break;
                    default:
                        break;
                }
                line = Console.ReadLine();
            }

            Console.WriteLine(string.Join(", ", shopingList));
        }

        private static void Rearrange(List<string> shopingList, string item)
        {
            if (shopingList.Remove(item))
            {
                shopingList.Add(item);
            }
        }

        private static void Correct(List<string> shopingList, string oldItem, string newItem)
        {
            int index = shopingList.IndexOf(oldItem);
            if (index >= 0)
            {
                shopingList[index] = newItem;
            }
        }

        private static void Unnecessary(List<string> shopingList, string item)
        {
            shopingList.Remove(item);
        }

        private static void Urgent(List<string> shopingList, string item)
        {
            if (shopingList.Contains(item) == false)
            {
                shopingList.Insert(0, item);
            }
        }
    }
}
