using System;
using System.Collections.Generic;
using System.Linq;

namespace TeamworkProjects
{
    class Team
    {
        public Team(string creator, string teamName)
        {
            Creator = creator;
            TeamName = teamName;
            Members = new List<string>();

            Console.WriteLine($"Team {TeamName} has been created by {Creator}!");
        }
        public List<string> Members { get; set; }

        public string TeamName { get; set; }

        public string Creator { get; set; }

        public int MembersCount
        {
            get { return Members.Count; }
        }

        public void PrintTeam()
        {
            Console.WriteLine($"{TeamName}");
            Console.WriteLine($"- {Creator}");

            foreach (string member in Members)
            {
                Console.WriteLine($"-- {member}");
            }
        }
    }
    class Program
    {
        static void Main()
        {
            int teamsCount = int.Parse(Console.ReadLine());
            List<Team> teams = new List<Team>(teamsCount);

            for (int i = 0; i < teamsCount; i++)
            {
                string[] teamInfo = Console.ReadLine().Split('-');
                string creator = teamInfo[0];
                string teamName = teamInfo[1];

                if (isTeamExist(teamName, teams))
                {
                    Console.WriteLine($"Team {teamName} was already created!"); 
                   
                }
                else if (isUserCreatedTeam(creator, teams))
                {
                    Console.WriteLine($"{creator} cannot create another team!");
                }
                else
                {
                    Team team = new Team(creator, teamName);
                    teams.Add(team);
                }

            }

            string line = Console.ReadLine();

            while (line != "end of assignment")
            {
                string[] assignmentInfo = line.Split("->");
                string userName = assignmentInfo[0];
                string teamName = assignmentInfo[1];

                int indexOfTeam = GetIndexOfTeam(teams, teamName);

                if (indexOfTeam == -1)
                {
                    Console.WriteLine($"Team {teamName} does not exist!");
                }
                else if (isUserAlreadyMember(userName, teams))
                {
                    Console.WriteLine($"Member {userName} cannot join team {teamName}!");
                }
                else
                {
                    teams[indexOfTeam].Members.Add(userName);
                }
                line = Console.ReadLine();
            }

            List<Team> disbandedTeams = teams.Where(t => t.MembersCount == 0).ToList();
            disbandedTeams = disbandedTeams.OrderBy(n => n.TeamName).ToList();
            List<Team> validTeams = teams.Where(t => t.MembersCount > 0).ToList();

            for (int i = 0; i < validTeams.Count; i++)
            {
                validTeams[i].Members.Sort();
            }

            validTeams = validTeams
                .OrderByDescending(c => c.MembersCount)
                .ThenBy(n => n.TeamName).ToList();

            foreach (Team team1 in validTeams)
            {
                team1.PrintTeam();
            }
            Console.WriteLine("Teams to disband:");
            foreach (Team team2 in disbandedTeams)
            {
                Console.WriteLine(team2.TeamName);
            }

        }

        private static int GetIndexOfTeam(List<Team> teams, string teamName)
        {
            int index = -1;
            for (int i = 0; i < teams.Count; i++)
            {
                if (teams[i].TeamName == teamName)
                {
                    index = i;
                    return index;
                }
            }
            return index;
        }

        private static bool isUserAlreadyMember(string userName, List<Team>teams)
        {
            foreach (Team team in teams)
            {
                if (team.Creator == userName)
                {
                    return true;
                }

                foreach (string member in team.Members)
                {
                    if (member == userName)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private static bool isUserCreatedTeam(string creator, List<Team> teams)
        {
            foreach (Team team in teams)
            {
                if (team.Creator == creator)
                {
                    return true;
                }
            }
            return false;
        }

        private static bool isTeamExist(string teamName, List<Team> teams)
        {
            foreach (Team team in teams)
            {
                if (team.TeamName == teamName)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
