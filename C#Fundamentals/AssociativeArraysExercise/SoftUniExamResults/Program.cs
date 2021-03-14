using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftUniExamResults
{
    class Program
    {
        static void Main(string[] args)
        {
            //{ username} | { points}
            Dictionary<string, int> pointsByUser = new Dictionary<string, int>();

            //{ language} – { submissionsCount}
            Dictionary<string, int> countsByLanguage = new Dictionary<string, int>();

            while (true)
            {
                string line = Console.ReadLine();
                
                if (line == "exam finished")
                {
                    break;
                }

                string[] parts = line.Split('-', StringSplitOptions.RemoveEmptyEntries);

                string userName = parts[0];

                if (parts[1] == "banned")
                {
                    pointsByUser.Remove(userName);
                }
                else
                {
                    string language = parts[1];
                    int points = int.Parse(parts[2]);

                    if (pointsByUser.ContainsKey(userName) == false)
                    {
                        pointsByUser.Add(userName, points);
                    }
                    else if(pointsByUser[userName] < points)
                    {
                        pointsByUser[userName] = points;
                    }

                    if (countsByLanguage.ContainsKey(language) == false)
                    {
                        countsByLanguage.Add(language, 0);
                    }
                    countsByLanguage[language]++;
                }
            }

            pointsByUser = pointsByUser
                .OrderByDescending(x => x.Value)
                .ThenBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);

            countsByLanguage = countsByLanguage
                .OrderByDescending(x => x.Value)
                .ThenBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);

            Console.WriteLine("Results:");
            foreach (var kvp in pointsByUser)
            {
                Console.WriteLine($"{kvp.Key} | {kvp.Value}");
            }

            Console.WriteLine("Submissions:");

            foreach (var kvp in countsByLanguage)
            {
                Console.WriteLine($"{kvp.Key} - {kvp.Value}");
            }
        }
    }
}
