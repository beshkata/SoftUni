using System;
using System.Collections.Generic;
using System.Linq;

namespace TheVLogger
{
    class Vlogger
    {
        public Vlogger(string userName)
        {
            UserName = userName;
            Followers = new List<string>();
            Followings = new List<string>();
        }
        public string UserName { get; set; }

        public List<string> Followers { get; set; }
        
        public List<string> Followings { get; set; }

        public override string ToString()
        {
            return $"{UserName} : {Followers.Count} followers, {Followings.Count} following";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Vlogger> vloggers = new Dictionary<string, Vlogger>();

            string input;

            while ((input = Console.ReadLine()) != "Statistics")
            {
                string[] tokens = input
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string userName = tokens[0];
                string command = tokens[1];

                if (command == "joined")
                {
                    if (!vloggers.ContainsKey(userName))
                    {
                        vloggers.Add(userName, new Vlogger(userName));
                    }
                }
                else if (command == "followed")
                {
                    string personToFollow = tokens[2];

                    if (vloggers.ContainsKey(userName) &&
                        vloggers.ContainsKey(personToFollow) &&
                        userName != personToFollow &&
                        !vloggers[personToFollow].Followers.Contains(userName))
                    {
                        vloggers[personToFollow].Followers.Add(userName);
                        vloggers[userName].Followings.Add(personToFollow);
                    }
                }
            }

            vloggers = vloggers
                .OrderByDescending(v => v.Value.Followers.Count)
                .ThenBy(v => v.Value.Followings.Count)
                .ToDictionary(k => k.Key, v => v.Value);

            Console.WriteLine($"The V-Logger has a total of {vloggers.Count} vloggers in its logs.");


            int number = 1;
            foreach (var vlogger in vloggers)
            {
                if (number == 1)
                {
                    Console.WriteLine($"{number}. " + vlogger.Value.ToString());
                    vlogger.Value.Followers.Sort();
                    foreach (var name in vlogger.Value.Followers)
                    {
                        Console.WriteLine($"*  {name}");
                    }
                }
                else
                {
                    Console.WriteLine($"{number}. " + vlogger.Value.ToString());
                    
                }
                number++;
            }
        }
    }
}
