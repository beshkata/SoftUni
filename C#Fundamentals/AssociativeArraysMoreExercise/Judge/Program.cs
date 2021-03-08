using System;
using System.Collections.Generic;
using System.Linq;

namespace Judge
{
    class Program
    {
        static void Main()
        {
            //contest - user - points
            Dictionary<string, Dictionary<string, int>> pointsByUserByContest = new Dictionary<string, Dictionary<string, int>>();
            //user - contest - points
            Dictionary<string, Dictionary<string, int>> pointsByContestByUser = new Dictionary<string, Dictionary<string, int>>();

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "no more time")
                {
                    break;
                }
                //{username} -> {contest} -> {points}
                string[] parts = line.Split(" -> ");
                string username = parts[0];
                string contest = parts[1];
                int points = int.Parse(parts[2]);

                if (!pointsByUserByContest.ContainsKey(contest))
                {
                    pointsByUserByContest.Add(contest, new Dictionary<string, int>());
                }

                if (!pointsByContestByUser.ContainsKey(username))
                {
                    pointsByContestByUser.Add(username, new Dictionary<string, int>());
                }

                if (!pointsByUserByContest[contest].ContainsKey(username))
                {
                    pointsByUserByContest[contest].Add(username, 0);
                }

                if (!pointsByContestByUser[username].ContainsKey(contest))
                {
                    pointsByContestByUser[username].Add(contest, 0);
                }

                if (pointsByUserByContest[contest][username] < points)
                {
                    pointsByUserByContest[contest][username] = points;
                }

                if (pointsByContestByUser[username][contest] < points)
                {
                    pointsByContestByUser[username][contest] = points;
                }
            }

            Dictionary<string, Dictionary<string, int>> orderedByContest = pointsByUserByContest
                .ToDictionary
                (
                    x => x.Key,
                    x => x.Value
                        .OrderByDescending(p => p.Value)
                        .ThenBy(n => n.Key)
                        .ToDictionary(y => y.Key, y => y.Value)
                );

            foreach (var content in orderedByContest)
            {
                Console.WriteLine($"{content.Key}: {content.Value.Count} participants");
                int count = 1;
                foreach (var user in content.Value)
                {
                    Console.WriteLine($"{count}. {user.Key} <::> {user.Value}");
                    count++;
                }
            }
            Console.WriteLine("Individual standings:");

            Dictionary<string, Dictionary<string, int>> orderedByUser = pointsByContestByUser
                .OrderByDescending(x => x.Value.Values.Sum())
                .ThenBy(n => n.Key)
                .ToDictionary(x => x.Key, x => x.Value);
            int counter = 1;
            foreach (var user in orderedByUser)
            {
                Console.WriteLine($"{counter}. {user.Key} -> {user.Value.Values.Sum()}");
                counter++;
            }
        }
    }
}
