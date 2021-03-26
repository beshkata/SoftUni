using System;
using System.Text.RegularExpressions;
using System.Text;
using System.Linq;
using System.Collections.Generic;

namespace NetherRealms
{
    class Demon
    {
        public Demon(string name)
        {
            Name = name;
            Health = GetHealth();
            Damage = GetDamage();
        }

        public string Name { get; set; }

        public int Health { get; set; }

        public double Damage { get; set; }
        private double GetDamage()
        {
            string basePattern = @"-*?\d+\.?\d*";
            double damage = 0;

            MatchCollection matches = Regex.Matches(Name, basePattern);

            foreach (Match match in matches)
            {
                damage += double.Parse(match.Value);
            }

            if (damage == 0)
            {
                return 0;
            }

            string symbolPattern = @"[\/\*]";

            MatchCollection symbolMatches = Regex.Matches(Name, symbolPattern);

            foreach (Match symbol in symbolMatches)
            {
                if (symbol.Value == "/")
                {
                    damage /= 2;
                }
                else
                {
                    damage *= 2;
                }
            }

            return damage;
        }
        private int GetHealth()
        {
            string pattern = @"[^\d+\-*\/\.]";
            int health = 0;

            MatchCollection matches = Regex.Matches(Name, pattern);

            foreach (Match match in matches)
            {
                health += char.Parse(match.Value);
            }

            return health;
        }

        public override string ToString()
        {
            return $"{Name} - {Health} health, {Damage:f2} damage";
        }

    }
    class Program
    {
        static void Main()
        {
            string[] demonNames = Console.ReadLine()
                .Split(",")
                .Select(x => x.Trim())
                .ToArray();

            List<Demon> demons = new List<Demon>();

            foreach (var name in demonNames)
            {
                Demon demon = new Demon(name);
                demons.Add(demon);
            }

            List<Demon> sorted = demons
                .OrderBy(x => x.Name)
                .ToList();

            foreach (var demon in sorted)
            {
                Console.WriteLine(demon.ToString());
            }
        }
    }
}
