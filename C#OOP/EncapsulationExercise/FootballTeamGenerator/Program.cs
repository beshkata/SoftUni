using System;
using System.Collections.Generic;

namespace FootballTeamGenerator
{
    public class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Team> teams = new Dictionary<string, Team>();
            while (true)
                {
                try
                {
                    string input = Console.ReadLine();
                    if (input == "END")
                    {
                        break;
                    }

                    string[] tokens = input.Split(';', StringSplitOptions.RemoveEmptyEntries);
                    string command = tokens[0];

                    if (command == "Team")
                    {
                        Team team = new Team(tokens[1]);
                        teams[team.Name] = team;
                    }
                    else if (command == "Add")
                    {
                        string teamName = tokens[1];
                        if (!teams.ContainsKey(teamName))
                        {
                            Console.WriteLine($"Team {teamName} does not exist.");
                            continue;
                        }
                        string playerName = tokens[2];
                        Player player = new Player(playerName,
                            int.Parse(tokens[3]),
                            int.Parse(tokens[4]),
                            int.Parse(tokens[5]),
                            int.Parse(tokens[6]),
                            int.Parse(tokens[7]));
                        teams[teamName].AddPlayer(player);
                    }
                    else if (command == "Remove")
                    {
                        string teamName = tokens[1];
                        if (!teams.ContainsKey(teamName))
                        {
                            Console.WriteLine($"Team {teamName} does not exist.");
                            continue;
                        }
                        string playerName = tokens[2];
                        teams[teamName].RemovePlayer(playerName);
                    }
                    else if (command == "Rating")
                    {
                        string teamName = tokens[1];
                        if (!teams.ContainsKey(teamName))
                        {
                            Console.WriteLine($"Team {teamName} does not exist.");
                            continue;
                        }
                        Console.WriteLine($"{teamName} - {teams[teamName].Rating}");
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            
        }
    }
}
