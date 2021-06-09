using System;
using System.Linq;
using System.Collections.Generic;

namespace Ranking
{
    class Contest
    {
        public Contest(string name, string password, int points)
        {
            Password = password;
            Name = name;
            Points = points;
        }

        public string Name { get; set; }
        public string Password { get; set; }

        public int Points { get; set; }
    }

    class Candidate
    {
        private int totalPoints;

        public Candidate(string username)
        {
            UserName = username;
            Contests = new Dictionary<string, Contest>();
        }

        public string UserName { get; set; }

        public Dictionary<string, Contest> Contests { get; set; }

        public int TotalPoints { get => GetTotalPoints(); set => totalPoints = value; }
        public int GetTotalPoints()
        {
            int sum = 0;
            foreach (var contest in Contests)
            {
                sum += contest.Value.Points;
            }

            return sum;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Contest> contestsDictionary = new Dictionary<string, Contest>();
            Dictionary<string, Candidate> candidates = new Dictionary<string, Candidate>();

            string input;
            while ((input = Console.ReadLine()) != "end of contests")
            {
                string[] contestInfo = input
                    .Split(':', StringSplitOptions.RemoveEmptyEntries);
                string contestName = contestInfo[0];
                string contestPassword = contestInfo[1];

                if (!contestsDictionary.ContainsKey(contestName))
                {
                    contestsDictionary.Add(contestName, new Contest(contestName, contestPassword, 0));
                }
            }

            while ((input = Console.ReadLine()) != "end of submissions")
            {
                string[] tokens = input
                    .Split("=>", StringSplitOptions.RemoveEmptyEntries);

                string contestName = tokens[0];
                string contestPassword = tokens[1];

                if (contestsDictionary.ContainsKey(contestName) 
                    && contestsDictionary[contestName].Password == contestPassword)
                {
                    string userName = tokens[2];
                    int points = int.Parse(tokens[3]);

                    if (!candidates.ContainsKey(userName))
                    {
                        candidates.Add(userName, new Candidate(userName));
                    }

                    if (candidates[userName].Contests.ContainsKey(contestName))
                    {
                        if (candidates[userName].Contests[contestName].Points < points)
                        {
                            candidates[userName].Contests[contestName].Points = points;
                        }
                    }
                    else
                    {
                        candidates[userName].Contests.Add(contestName, new Contest(contestName, contestPassword, points));
                    }
                }
            }

            string best = "";
            int bestPoints = 0;

            foreach (var candidate in candidates)
            {

                if (candidate.Value.TotalPoints > bestPoints)
                {
                    best = candidate.Value.UserName;
                    bestPoints = candidate.Value.TotalPoints;
                }
            }

            Console.WriteLine($"Best candidate is {best} with total {bestPoints} points.");
            Console.WriteLine("Ranking:");

            candidates = candidates
                .OrderBy(c => c.Key)
                .ThenBy(c => c.Value.Contests = c.Value.Contests.OrderByDescending(d => d.Value.Points).ToDictionary(k => k.Key, v => v.Value))
                .ToDictionary(k => k.Key, v => v.Value);

            foreach (var candidate in candidates)
            {
                Console.WriteLine(candidate.Key);
                foreach (var contest in candidate.Value.Contests)
                {
                    Console.WriteLine($"#  {contest.Key} -> {contest.Value.Points}");
                }
            }
        }
    }
}
