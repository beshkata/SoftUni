using System;

namespace CounterStrike
{
    class Player
    {
        public Player(int energy)
        {
            Energy = energy;
            if (Energy > 0)
            {
                HasEnergy = true;
            }
            else
            {
                HasEnergy = false;
            }
        }

        public int Energy { get; set; }

        public int BattleWonCount { get; set; }

        public bool HasEnergy { get; set; }

        public void Battle (int distance)
        {
            if (Energy - distance < 0)
            {
                Console.WriteLine($"Not enough energy! Game ends with {BattleWonCount} won battles and {Energy} energy");
                HasEnergy = false;
            }
            else
            {
                Energy -= distance;
                BattleWonCount++;
                if (BattleWonCount % 3 == 0)
                {
                    Energy += BattleWonCount;
                }
            }
        }

        public string BattleEnd()
        {
            return $"Won battles: {BattleWonCount}. Energy left: {Energy}";
        }
    }
    class Program
    {
        static void Main()
        {
            int initialEnergy = int.Parse(Console.ReadLine());
            Player player = new Player(initialEnergy);

            string input = Console.ReadLine();

            while (input != "End of battle")
            {
                int distance = int.Parse(input);

                player.Battle(distance);

                if (player.HasEnergy == false)
                {
                    break;
                }

                input = Console.ReadLine();
            }

            if (player.HasEnergy)
            {
                Console.WriteLine(player.BattleEnd());
            }
        }
    }
}
