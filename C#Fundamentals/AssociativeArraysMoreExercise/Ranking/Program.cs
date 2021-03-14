using System;
using System.Collections.Generic;
using System.Linq;

namespace Ranking
{
    class Program
    {
        static void Main(string[] args)
        {
            //userName - contest - points
            Dictionary<string, Dictionary<string, int>> pointByContestByUser = 
                new Dictionary<string, Dictionary<string, int>>();

            //contest - password
            Dictionary<string, string> passwordByContest = new Dictionary<string, string>();

            while (true)
            {
                string line = Console.ReadLine();
                if (line == "end of contests")
                {
                    break;
                }
                //{contest}:{password for contest} 
                string[] parts = line.Split(':');
                string contest = parts[0];
                string password = parts[1];

                if (!passwordByContest.ContainsKey(contest))
                {
                    passwordByContest.Add(contest, "");
                }
                passwordByContest[contest] = password;
            }

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "end of submissions")
                {
                    break;
                }

                //{contest}=>{password}=>{username}=>{points}
                string[] parts = line.Split("=>");
                string contest = parts[0];
                string password = parts[1];
                string username = parts[2];
                int points = int.Parse(parts[3]);

                if (!passwordByContest.ContainsKey(contest))
                {
                    continue;
                }

                if (passwordByContest[contest] != password)
                {
                    continue;
                }

                if (!pointByContestByUser.ContainsKey(username))
                {
                    pointByContestByUser.Add(username, new Dictionary<string, int>());
                }

                if (!pointByContestByUser[username].ContainsKey(contest))
                {
                    pointByContestByUser[username].Add(contest, 0);
                }

                if (pointByContestByUser[username][contest] < points)
                {
                    pointByContestByUser[username][contest] = points;
                }
            }

            int bestPoints = 0;
            string bestUser = string.Empty;

            foreach (var user in pointByContestByUser)
            {
                int currentPoints = 0;
                foreach (var contest in user.Value)
                {
                    currentPoints += contest.Value;
                }

                if (currentPoints > bestPoints)
                {
                    bestPoints = currentPoints;
                    bestUser = user.Key;
                }
            }

            Console.WriteLine($"Best candidate is {bestUser} with total {bestPoints} points.");

            Console.WriteLine("Ranking: ");

            Dictionary<string, Dictionary<string, int>> result = pointByContestByUser
                .OrderBy(n => n.Key)
                .ToDictionary
                (
                x => x.Key, 
                x => x.Value.
                    OrderByDescending(p => p.Value)
                    .ToDictionary(y => y.Key, y => y.Value)
                );

            foreach (var user in result)
            {
                Console.WriteLine(user.Key);

                foreach (var contest in user.Value)
                {
                    Console.WriteLine($"#  {contest.Key} -> {contest.Value}");
                }
            }
        }
    }
}
