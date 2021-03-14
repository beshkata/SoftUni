using System;
using System.Collections.Generic;
using System.Linq;

namespace MOBAChallenger
{
    class Player
    {
        public Player(string name)
        {
            Name = name;
            SkillsByPositions = new Dictionary<string, int>();
            Positions = new List<string>();
        }
        public string Name { get; set; }

        public Dictionary<string, int> SkillsByPositions { get; set; }

        public int TotalSkill
        {
            get { return SkillsByPositions.Values.Sum(); }
        }

        public List<string> Positions { get; set; }

        public void AddSkill(string position, int skill)
        {
            if (!SkillsByPositions.ContainsKey(position))
            {
                //add his position and skill
                SkillsByPositions.Add(position, skill);
                Positions.Add(position);
            }
            else
            {
                //update his skill, only if the current position skill is lower than the new value.
                if (SkillsByPositions[position] < skill)
                {
                    SkillsByPositions[position] = skill;
                }
            }
        }

        public void PrintPlayer()
        {
            Dictionary<string, int> ordered = SkillsByPositions
                .OrderByDescending(s => s.Value)
                .ThenBy(p => p.Key)
                .ToDictionary(x => x.Key, x => x.Value);

            Console.WriteLine($"{Name}: {TotalSkill} skill");

            foreach (var kvp in ordered)
            {
                Console.WriteLine($"- {kvp.Key} <::> {kvp.Value}");
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Player> players = new List<Player>();
            while (true)
            {
                string line = Console.ReadLine();

                if (line == "Season end")
                {
                    break;
                }

                if (line.Contains(" -> "))
                {
                    //"{player} -> {position} -> {skill}"
                    string[] playerInfo = line.Split(" -> ");
                    string name = playerInfo[0];
                    string position = playerInfo[1];
                    int skill = int.Parse(playerInfo[2]);

                    int playerIndex = GetPlayerIndex(players, name);
                    if (playerIndex < 0)
                    {
                        Player player = new Player(name);
                        player.AddSkill(position, skill);
                        players.Add(player);
                    }
                    else
                    {
                        players[playerIndex].AddSkill(position, skill);
                    }
                }
                else
                {
                    //"{player} vs {player}"
                    string[] parts = line.Split(" vs ");
                    string firstPlayerName = parts[0];
                    string secondPlayerName = parts[1];

                    int firstIndex = GetPlayerIndex(players, firstPlayerName);
                    int secondIndex = GetPlayerIndex(players, secondPlayerName);

                    if (firstIndex < 0 || secondIndex < 0)
                    {
                        continue;
                    }

                    Duel(players, firstIndex, secondIndex);
                }
            }

            List<Player> ordered = players
                .OrderByDescending(x => x.TotalSkill)
                .ThenBy(x => x.Name)
                .ToList();

            foreach (Player player1 in ordered)
            {
                player1.PrintPlayer();
            }
        }

        private static void Duel(List<Player> players, int firstIndex, int secondIndex)
        {
            bool hasCommonPisition = false;

            foreach (string position in players[firstIndex].Positions)
            {
                hasCommonPisition = players[secondIndex].Positions.Contains(position);
                if (hasCommonPisition)
                {
                    break;
                }
            }

            int firstTotalSkill = players[firstIndex].TotalSkill;
            int secondTotalSkill = players[secondIndex].TotalSkill;
            if (hasCommonPisition == false || firstTotalSkill == secondTotalSkill)
            {
                return;
            }

            if (firstTotalSkill > secondTotalSkill)
            {
                players.RemoveAt(secondIndex);
            }
            else
            {
                players.RemoveAt(firstIndex);
            }
        }

        public static int GetPlayerIndex(List<Player> players, string name)
        {
            int index = -1;
            for (int i = 0; i < players.Count; i++)
            {
                if (players[i].Name == name)
                {
                    index = i;
                    return index;
                }
            }
            return index;
        }
    }
}
