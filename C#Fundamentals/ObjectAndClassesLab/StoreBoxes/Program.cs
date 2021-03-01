using System;
using System.Collections.Generic;
using System.Linq;

namespace StoreBoxes
{
    class Item
    {
        public Item(string name, double price)
        {
            Name = name;
            Price = price;
        }

        public string Name { get; set; }

        public double Price { get; set; }

    }

    class Box
    {
        public Box(string serialNumber, Item item, int itemQuantity)
        {
            SerialNumber = serialNumber;
            Item = item;
            ItemQuantity = itemQuantity;
            BoxPrice = item.Price * itemQuantity;
        }
        public string SerialNumber { get; set; }

        public Item Item { get; set; }

        public int ItemQuantity { get; set; }

        public double BoxPrice { get; set; }


        public void PrintBox()
        {
            Console.WriteLine($"{SerialNumber}");
            Console.WriteLine($"-- {Item.Name} - ${Item.Price:f2}: {ItemQuantity}");
            Console.WriteLine($"-- ${ItemQuantity * Item.Price:f2}");
        }
    }
    class Program
    {
        static void Main()
        {
            string input = Console.ReadLine();
            List<Box> boxes = new List<Box>();

            while (input != "end")
            {
                string[] boxInfo = input.Split();
                string serialNumber = boxInfo[0];
                string itemName = boxInfo[1];
                int itemsQuantity = int.Parse(boxInfo[2]);
                double itemPrice = double.Parse(boxInfo[3]);

                Item item = new Item(itemName, itemPrice);
                Box box = new Box(serialNumber, item, itemsQuantity);
                boxes.Add(box);

                input = Console.ReadLine();
            }

            List<Box> orderedBoxes = boxes.OrderByDescending(x => x.BoxPrice).ToList();

            foreach (Box box in orderedBoxes)
            {
                box.PrintBox();
            }
        }
    }
}
