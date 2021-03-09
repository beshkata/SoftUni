using System;
using System.Collections.Generic;
using System.Linq;

namespace Snowwhite
{
    class Dwarf
    {
        public Dwarf(string name, string color, int physics)
        {
            Name = name;
            Color = color;
            Physics = physics;
        }

        public string Name { get; set; }

        public string Color { get; set; }

        public int Physics { get; set; }

        public int ColorCount { get; set; }

        public override string ToString()
        {
            //({hatColor}) {name} <-> {physics}
            return $"({Color}) {Name} <-> {Physics}";
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Dwarf> dwarves = new List<Dwarf>();
            Dictionary<string, int> countByColor = new Dictionary<string, int>();


            while (true)
            {
                string line = Console.ReadLine();

                if (line == "Once upon a time")
                {
                    break;
                }
                //{dwarfName} <:> {dwarfHatColor} <:> {dwarfPhysics}
                string[] dwarfInfo = line.Split(" <:> ");

                string name = dwarfInfo[0];
                string color = dwarfInfo[1];
                int physics = int.Parse(dwarfInfo[2]);


                int dwarfIndex = GetDwarfIndex(dwarves, name, color);


                if (dwarfIndex < 0)
                {
                    Dwarf dwarf = new Dwarf(name, color, physics);
                    dwarves.Add(dwarf);

                    if (!countByColor.ContainsKey(color))
                    {
                        countByColor.Add(color, 0);
                    }
                    countByColor[color]++;
                }
                else
                {
                    if (dwarves[dwarfIndex].Physics < physics)
                    {
                        dwarves[dwarfIndex].Physics = physics;
                    }
                }
            }

            for (int i = 0; i < dwarves.Count; i++)
            {
                dwarves[i].ColorCount = countByColor[dwarves[i].Color];
            }
            List<Dwarf> result = dwarves
                .OrderByDescending(d => d.Physics)
                .ThenByDescending(c => c.ColorCount)
                .ToList();

            foreach (Dwarf dwarf1 in result)
            {
                Console.WriteLine(dwarf1);
            }
        }

        private static int GetDwarfIndex(List<Dwarf> dwarves, string name, string color)
        {
            int index = -1;

            for (int i = 0; i < dwarves.Count; i++)
            {
                if (dwarves[i].Name == name && dwarves[i].Color == color)
                {
                    index = i;
                    return index;
                }
            }

            return index;
        }
    }
}
