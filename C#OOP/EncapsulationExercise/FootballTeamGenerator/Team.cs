using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace FootballTeamGenerator
{
    public class Team
    {
        private string name;
        private Dictionary<string, Player> players;

        public Team(string name)
        {
            Name = name;
            players = new Dictionary<string, Player>();
        }
        public string Name { get; set; }

        public double Rating
        {
            get
            {
                if (players.Count == 0)
                {
                    return 0;
                }
                double rating = Math.Round(players.Values.Average(x => x.SkillLevel));
                return rating;
            }
        }

        public void AddPlayer(Player player)
        {
            players.Add(player.Name, player);
        }

        public void RemovePlayer(string playerName)
        {
            if (!players.ContainsKey(playerName))
            {
                throw new ArgumentException($"Player {playerName} is not in {Name} team.");
            }
            else
            {
                players.Remove(playerName);
            }
        }
    }
}
