using System;
using System.Linq;
using System.Collections.Generic;

namespace TaskThree
{
    class Follower
    {
        public Follower(string username)
        {
            Username = username;
            Likes = 0;
            Comments = 0;
        }
        public string Username { get; set; }

        public int Likes { get; set; }

        public int Comments { get; set; }

        public override string ToString()
        {
            return $"{Username}: {Likes + Comments}";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Follower> followers = new Dictionary<string, Follower>();

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "Log out")
                {
                    break;
                }

                string[] tokens = line.Split(": ");
                string command = tokens[0];
                string username = tokens[1];



                if (command == "New follower")
                {
                    if (!followers.ContainsKey(username))
                    {
                        Follower follower = new Follower(username);
                        followers.Add(username, follower);
                    }

                }
                else if (command == "Like")
                {
                    if (!followers.ContainsKey(username))
                    {
                        Follower follower = new Follower(username);
                        followers.Add(username, follower);
                    }

                    int likes = int.Parse(tokens[2]);
                    followers[username].Likes += likes;
                }
                else if (command == "Comment")
                {
                    if (!followers.ContainsKey(username))
                    {
                        Follower follower = new Follower(username);
                        followers.Add(username, follower);
                    }

                    followers[username].Comments++; ;
                }
                else if (command == "Blocked")
                {
                    if (!followers.ContainsKey(username))
                    {
                        Console.WriteLine($"{username} doesn't exist.");
                    }
                    else
                    {
                        followers.Remove(username);
                    }
                }
            }

            Dictionary<string, Follower> sorted = followers
                .OrderByDescending(x => x.Value.Comments + x.Value.Likes)
                .ThenBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);

            Console.WriteLine($"{sorted.Count} followers");
            foreach (var follower in sorted)
            {
                Console.WriteLine(follower.Value.ToString());
            }
        }
    }
}
