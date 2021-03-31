using System;
using System.Linq;
using System.Collections.Generic;

namespace HeroesOfCodeAndLogic
{
    class Hero
    {
        public Hero(string name, int hp, int mp)
        {
            Name = name;
            if (hp > 100)
            {
                hp = 100;
            }
            HP = hp;

            if (mp > 200)
            {
                mp = 200;
            }
            MP = mp;
        }
        public string Name { get; set; }

        public int HP { get; set; }

        public int MP { get; set; }

        public void CastSpell(int manaNeeded, string spellName)
        {
            if (MP >= manaNeeded)
            {
                MP -= manaNeeded;
                Console.WriteLine($"{Name} has successfully cast {spellName} and now has {MP} MP!");
            }
            else
            {
                Console.WriteLine($"{Name} does not have enough MP to cast {spellName}!");
            }
        }

        public void TakeDamage(int damage, string attacker)
        {
            HP -= damage;

            if (HP > 0)
            {
                Console.WriteLine($"{Name} was hit for {damage} HP by {attacker} and now has {HP} HP left!");
            }
            else
            {
                Console.WriteLine($"{Name} has been killed by {attacker}!");
            }
        }

        public void Recharge(int amount)
        {
            

            if (MP + amount > 200)
            {
                amount = 200 - MP;
            }

            MP += amount;

            Console.WriteLine($"{Name} recharged for {amount} MP!");
        }

        public void Heal(int amount)
        {
            

            if (HP + amount > 100)
            {
                amount = 100 - HP;
            }

            HP += amount;

            Console.WriteLine($"{Name} healed for {amount} HP!");
        }

        public void PrintHero()
        {
            Console.WriteLine(Name);
            Console.WriteLine($"  HP: {HP}");
            Console.WriteLine($"  MP: {MP}");
        }
    }
    class Program
    {
        static void Main()
        {
            Dictionary<string, Hero> heroes = new Dictionary<string, Hero>();

            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                string[] heroInfo = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string name = heroInfo[0];
                int hp = int.Parse(heroInfo[1]);
                int mp = int.Parse(heroInfo[2]);
                Hero hero = new Hero(name, hp, mp);

                heroes.Add(hero.Name, hero);
            }

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "End")
                {
                    break;
                }

                string[] tokens = line.Split(" - ", StringSplitOptions.RemoveEmptyEntries);

                string command = tokens[0];
                string name = tokens[1];

                if (command == "CastSpell")
                {
                    int manaNeeded = int.Parse(tokens[2]);
                    string spellName = tokens[3];

                    heroes[name].CastSpell(manaNeeded, spellName);
                }
                else if (command == "TakeDamage")
                {
                    int damage = int.Parse(tokens[2]);
                    string attacker = tokens[3];

                    heroes[name].TakeDamage(damage, attacker);

                    if (heroes[name].HP <= 0)
                    {
                        heroes.Remove(name);
                    }
                }
                else if (command == "Recharge")
                {
                    int amount = int.Parse(tokens[2]);

                    heroes[name].Recharge(amount);
                }
                else if (command == "Heal")
                {
                    int amount = int.Parse(tokens[2]);

                    heroes[name].Heal(amount);
                }
            }

            Dictionary<string, Hero> sorted = heroes
                .OrderByDescending(x => x.Value.HP)
                .ThenBy(x => x.Key)
                .ToDictionary(n => n.Key, h => h.Value);

            foreach (var hero in sorted)
            {
                hero.Value.PrintHero();
            }
        }
    }
}
