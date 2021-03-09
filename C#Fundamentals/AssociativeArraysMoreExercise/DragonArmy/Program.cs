using System;
using System.Collections.Generic;
using System.Linq;

namespace DragonArmy
{
    class Dragon
    {
        public Dragon(string type, string name, string damage, string health, string armor)
        {
            Type = type;
            Name = name;
            if (int.TryParse(damage, out int d))
            {
                Damage = d;
            }
            else
            {
                Damage = 45;
            }

            if (int.TryParse(health, out int h))
            {
                Health = h;
            }
            else
            {
                Health = 250;
            }

            if (int.TryParse(armor, out int a))
            {
                Armor = a;
            }
            else
            {
                Armor = 10;
            }
        }
        public string Name { get; set; }

        public int Damage { get; set; }

        public int Health { get; set; }

        public int Armor { get; set; }

        public string Type { get; set; }

        public void UpdateDragon(string damage, string health, string armor)
        {
            if (int.TryParse(damage, out int d))
            {
                Damage = d;
            }
            else
            {
                Damage = 45;
            }

            if (int.TryParse(health, out int h))
            {
                Health = h;
            }
            else
            {
                Health = 250;
            }

            if (int.TryParse(armor, out int a))
            {
                Armor = a;
            }
            else
            {
                Armor = 10;
            }
        }

        public override string ToString()
        {
            //-{Name} -> damage: {damage}, health: {health}, armor: {armor}
            return $"-{Name} -> damage: {Damage}, health: {Health}, armor: {Armor}";
        }
    }
    class Program
    {
        static void Main()
        {
            Dictionary<string, List<Dragon>> dragonByType = new Dictionary<string, List<Dragon>>();
            List<Dragon> dragons = new List<Dragon>();

            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                //{type} {name} {damage} {health} {armor}
                string[] dragonInfo = Console.ReadLine().Split();

                string type = dragonInfo[0];
                string name = dragonInfo[1];
                string damage = dragonInfo[2];
                string health = dragonInfo[3];
                string armor = dragonInfo[4];

                int dragonIndex = GetDragonIndex(dragons, type, name);

                if (dragonIndex < 0)
                {
                    Dragon dragon = new Dragon(type, name, damage, health, armor);
                    dragons.Add(dragon);
                }
                else
                {
                    dragons[dragonIndex].UpdateDragon(damage, health, armor);
                }
            }

            for (int i = 0; i < dragons.Count; i++)
            {
                if (!dragonByType.ContainsKey(dragons[i].Type))
                {
                    dragonByType.Add(dragons[i].Type, new List<Dragon> { dragons[i] });
                }
                else
                {
                    dragonByType[dragons[i].Type].Add(dragons[i]);
                }
            }

            Dictionary<string, List<Dragon>> ordered = dragonByType
                .ToDictionary(x => x.Key, x => x.Value.OrderBy(y => y.Name).ToList());

            foreach (var kvp in ordered)
            {
                double avgDamage = 0.0;
                double avgHealth = 0.0;
                double avgArmor = 0.0;

                int counter = 0;

                foreach (var dragon in kvp.Value)
                {
                    avgDamage += dragon.Damage;
                    avgHealth += dragon.Health;
                    avgArmor += dragon.Armor;
                    counter++;
                }

                avgDamage /= counter;
                avgHealth /= counter;
                avgArmor /= counter;

                //{Type}::({damage}/{health}/{armor})
                Console.WriteLine($"{kvp.Key}::({avgDamage:f2}/{avgHealth:f2}/{avgArmor:f2})");

                foreach (var dragon in kvp.Value)
                {
                    Console.WriteLine(dragon);
                }
            }
        }

        private static int GetDragonIndex(List<Dragon> dragons, string type, string name)
        {
            int index = -1;

            for (int i = 0; i < dragons.Count; i++)
            {
                if (dragons[i].Type == type && dragons[i].Name == name)
                {
                    index = i;
                    return index;
                }
            }

            return index;
        }
    }
}
