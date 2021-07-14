using System;
using System.Collections.Generic;
using System.Linq;

using Raiding.Factory;
using Raiding.Models;

namespace Raiding
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Hero> heroes = new List<Hero>();
            HeroFactory factory = null;

            int heroCount = int.Parse(Console.ReadLine());

            while (heroes.Count != heroCount)
            {
                string name = Console.ReadLine();
                string heroType = Console.ReadLine();

                switch (heroType)
                {
                    case "Druid":
                        factory = new DruidFactory(name);
                        heroes.Add(factory.GetHero());
                        break;
                    case "Paladin":
                        factory = new PaladinFactory(name);
                        heroes.Add(factory.GetHero());
                        break;
                    case "Rogue":
                        factory = new RogueFactory(name);
                        heroes.Add(factory.GetHero());
                        break;
                    case "Warrior":
                        factory = new WarriorFactory(name);
                        heroes.Add(factory.GetHero());
                        break;
                    default:
                        Console.WriteLine("Invalid hero!");
                        break;
                }
            }
            int bossLife = int.Parse(Console.ReadLine());

            foreach (var hero in heroes)
            {
                Console.WriteLine(hero.CastAbility());
            }

            int totalHeroPower = heroes.Sum(x => x.Power);

            if (totalHeroPower >= bossLife)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }
        
        }
    }
}
