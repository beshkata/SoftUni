using System;
using System.Collections.Generic;

namespace MinerTask
{
    class Program
    {
        static void Main()
        {
            Dictionary<string, int> quantityToResources = new Dictionary<string, int>();

            while (true)
            {
                string resource = Console.ReadLine();
                if (resource == "stop")
                {
                    break;
                }
                int quantity = int.Parse(Console.ReadLine());

                if (quantityToResources.ContainsKey(resource) == false)
                {
                    quantityToResources.Add(resource, 0);
                }

                quantityToResources[resource] += quantity;
            }

            foreach (var kvp in quantityToResources)
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
            }
        }
    }
}
