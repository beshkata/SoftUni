using System;
using System.Collections.Generic;
using System.Linq;

namespace Inventory
{
    class Inventory
    {
        public Inventory()
        {
            ListInventory = new List<string>();
        }
        public List<string> ListInventory { get; set; }

        public void Collect(string item)
        {
            if (ListInventory.Contains(item) == false)
            {
                ListInventory.Add(item);
            }
        }

        public void Drop(string item)
        {
            ListInventory.Remove(item);
        }

        public void CombineItems(string oldItem, string newItem)
        {
            int oldItemIndex = ListInventory.IndexOf(oldItem);

            if (oldItemIndex >= 0)
            {
                ListInventory.Insert(oldItemIndex + 1, newItem);
            }
        }

        public void Renew(string item)
        {
            if (ListInventory.Remove(item))
            {
                ListInventory.Add(item);
            }
        }

        public override string ToString()
        {
            return string.Join(", ", ListInventory);
        }

    }
    class Program
    {
        static void Main()
        {
            Inventory myInventory = new Inventory();

            myInventory.ListInventory = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string input = Console.ReadLine();

            while (input != "Craft!")
            {
                string[] commands = input.Split(" - ", StringSplitOptions.RemoveEmptyEntries);
                string command = commands[0];
                string item = commands[1];

                switch (command)
                {
                    case "Collect":
                        myInventory.Collect(item);
                        break;
                    case "Drop":
                        myInventory.Drop(item);
                        break;
                    case "Combine Items":
                        string[] items = item.Split(':');
                        myInventory.CombineItems(items[0], items[1]);
                        break;
                    case "Renew":
                        myInventory.Renew(item);
                        break;
                    default:
                        break;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(myInventory);
        }
    }
}
