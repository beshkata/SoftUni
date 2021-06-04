using System;
using System.Collections.Generic;
using System.Linq;

namespace Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, Dictionary<string, int>> clothesByColor = 
                new Dictionary<string, Dictionary<string, int>>();

            for (int i = 0; i < n; i++)
            {
                string[] inputs = Console.ReadLine()
                    .Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
                string color = inputs[0];
                string[] clothes = inputs[1]
                    .Split(',', StringSplitOptions.RemoveEmptyEntries);

                if (!clothesByColor.ContainsKey(color))
                {
                    clothesByColor.Add(color, new Dictionary<string, int>());
                }
                foreach (var cloth in clothes)
                {
                    if (!clothesByColor[color].ContainsKey(cloth))
                    {
                        clothesByColor[color].Add(cloth, 0);
                    }
                    clothesByColor[color][cloth]++;
                }
            }

            string[] clothToFindInfo = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string colorToFind = clothToFindInfo[0];
            string clothTypeToFind = clothToFindInfo[1];

            foreach (var color in clothesByColor)
            {
                Console.WriteLine($"{color.Key} clothes:");

                foreach (var cloth in color.Value)
                {
                    if (color.Key == colorToFind && cloth.Key == clothTypeToFind)
                    {
                        Console.WriteLine($"* {cloth.Key} - {cloth.Value} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {cloth.Key} - {cloth.Value}");
                    }
                }
            }
        }
    }
}
