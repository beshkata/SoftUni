using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Guild
{
    public class Guild
    {
        Dictionary<string,Player> roster;

        public Guild(string name, int capacity)
        {
            roster = new Dictionary<string, Player>(capacity);
            Name = name;
            Capacity = capacity;
        }
        public string Name { get; set; }
        public int Capacity { get; set; }

        public int Count { get => roster.Count; }

        public void AddPlayer(Player player)
        {
            if (roster.Count < Capacity)
            {
                roster.Add(player.Name,player);
            }
        }
        public bool RemovePlayer(string name)
        {
            return roster.Remove(name);
        }

        public void PromotePlayer(string name)
        {
            if (roster.ContainsKey(name))
            {
                roster[name].Rank = "Member";
            }
            
        }

        public void DemotePlayer(string name)
        {
            if (roster.ContainsKey(name))
            {
                roster[name].Rank = "Trial";
            }
        }

        public Player[] KickPlayersByClass(string playerClass)
        {
            List<Player> players = new List<Player>();

            foreach (var player in roster)
            {
                if (player.Value.Class == playerClass)
                {
                    players.Add(player.Value);
                }
            }

            roster = roster
                .Where(p => p.Value.Class != playerClass)
                .ToDictionary(k => k.Key, v => v.Value);

            return players.ToArray();
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Players in the guild: {Name}\n");
            foreach (var player in roster)
            {
                sb.Append($"{player.Value.ToString()}\n");
            }
            return sb.ToString();
        }
    }
}
