using System;
using System.Collections.Generic;
using System.Linq;

namespace LegendaryFarming
{
    class Program
    {
        //Shadowmourne - requires 250 Shards;
        //Valanyr - requires 250 Fragments;
        //Dragonwrath - requires 250 Motes;

        static void Main()
        {
            Dictionary<string, int> quantityToMaterial = new Dictionary<string, int>();
            Dictionary<string, int> quantityToLegendaryMaterial = new Dictionary<string, int>();

            quantityToLegendaryMaterial.Add("shards", 0);
            quantityToLegendaryMaterial.Add("fragments", 0);
            quantityToLegendaryMaterial.Add("motes", 0);

            string craftedItem = string.Empty;


            while (craftedItem == string.Empty)
            {
                string[] input = Console.ReadLine().Split();

                for (int i = 0; i < input.Length; i+= 2)
                {
                    string material = input[i + 1].ToLower();
                    int quantity = int.Parse(input[i]);

                    if (quantityToLegendaryMaterial.ContainsKey(material))
                    {
                        quantityToLegendaryMaterial[material] += quantity;

                        if (quantityToLegendaryMaterial[material] >= 250)
                        {
                            quantityToLegendaryMaterial[material] -= 250;
                            craftedItem = material;
                            break;
                        }
                    }
                    else
                    {
                        if (quantityToMaterial.ContainsKey(material) == false)
                        {
                            quantityToMaterial.Add(material, 0);
                        }

                        quantityToMaterial[material] += quantity;
                    }
                }
            }

            if (craftedItem == "shards")
            {
                craftedItem = "Shadowmourne";
            }
            else if (craftedItem == "fragments")
            {
                craftedItem = "Valanyr";
            }
            else
            {
                craftedItem = "Dragonwrath";
            }

            Console.WriteLine($"{craftedItem} obtained!");

            quantityToLegendaryMaterial = quantityToLegendaryMaterial
                .OrderByDescending(x => x.Value)
                .ThenBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);

            quantityToMaterial = quantityToMaterial
                .OrderBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);

            foreach (var kvp in quantityToLegendaryMaterial)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }

            foreach (var kvp in quantityToMaterial)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }

        }
    }
}
