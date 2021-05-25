using System;
using System.Collections.Generic;
using System.Linq;

namespace FastFood
{
    class Program
    {
        static void Main(string[] args)
        {
            int foodQuantity = int.Parse(Console.ReadLine());

            int[] orders = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Queue<int> queueOfOrders = new Queue<int>(orders);

            Console.WriteLine(queueOfOrders.Max());

            while (true)
            {
                if (queueOfOrders.Count == 0)
                {
                    Console.WriteLine("Orders complete");
                    return;
                }

                int nextOrder = queueOfOrders.Peek();

                if (foodQuantity - nextOrder < 0)
                {
                    Console.WriteLine($"Orders left: {string.Join(' ', queueOfOrders)}");
                    return;
                }
                else
                {
                    queueOfOrders.Dequeue();
                    foodQuantity -= nextOrder;
                }
            }
        }
    }
}
