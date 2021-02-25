using System;

namespace MuOnline
{
    class Hero
    {
        public Hero()
        {
            Health = 100;
            Bitcoins = 0;
            IsAlive = true;
            BestRoom = 0;
        }
        public int Health { get; set; }

        public int Bitcoins { get; set; }

        public bool IsAlive { get; set; }

        public int BestRoom { get; set; }
        public void Healing(int healingPoints)
        {
            int pointHealed = 0;
            if (Health + healingPoints > 100)
            {
                pointHealed = 100 - Health;
                Health = 100;
            }
            else
            {
                pointHealed = healingPoints;
                Health += healingPoints;
            }

            Console.WriteLine($"You healed for {pointHealed} hp.");
            Console.WriteLine($"Current health: {Health} hp.");
        }

        public void ColectBitCoins(int amountBitCoins)
        {
            Bitcoins += amountBitCoins;

            Console.WriteLine($"You found {amountBitCoins} bitcoins.");
        }

        public void Fight(string monsterName, int monsterAttack)
        {
            if (Health - monsterAttack > 0)
            {
                Health -= monsterAttack;
                Console.WriteLine($"You slayed {monsterName}.");
                IsAlive = true;
            }
            else
            {
                Health -= monsterAttack;
                Console.WriteLine($"You died! Killed by {monsterName}.");
                IsAlive = false;
            }
            
        }
    }
    class Program
    {
        static void Main()
        {
            string[] rooms = Console.ReadLine()
                .Split('|');
            Hero myHero = new Hero();

            for (int i = 0; i < rooms.Length; i++)
            {
                string[] commands = rooms[i].Split();
                string command = commands[0];
                int number = int.Parse(commands[1]);
                myHero.BestRoom++;

                switch (command)
                {
                    case "potion":
                        myHero.Healing(number);
                        break;
                    case "chest":
                        myHero.ColectBitCoins(number);
                        break;
                    default:
                        myHero.Fight(command, number);
                        break;
                }

                if (myHero.IsAlive == false)
                {
                    Console.WriteLine($"Best room: {myHero.BestRoom}");
                    break;
                }
            }

            if (myHero.IsAlive)
            {
                Console.WriteLine("You've made it!");
                Console.WriteLine($"Bitcoins: {myHero.Bitcoins}");
                Console.WriteLine($"Health: {myHero.Health}");
            }
        }
    }

}
