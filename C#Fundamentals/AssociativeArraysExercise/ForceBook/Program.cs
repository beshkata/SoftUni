using System;
using System.Collections.Generic;
using System.Linq;

namespace ForceBook
{
    class Program
    {
        static void Main()
        {
            Dictionary<string, List<string>> memberBySide = new Dictionary<string, List<string>>();
            Dictionary<string, string> members = new Dictionary<string, string>();

            while (true)
            {
                string line = Console.ReadLine();

                if(line == "Lumpawaroo")
                {
                    break;
                }

                if (line.Contains(" | "))
                {
                    string[] parts = line.Split(" | ");

                    string forceSide = parts[0];
                    string forceUser = parts[1];

                    if (members.ContainsKey(forceUser))
                    {
                        continue;
                    }

                    if (!memberBySide.ContainsKey(forceSide))
                    {
                        memberBySide.Add(forceSide, new List<string>());
                    }

                    memberBySide[forceSide].Add(forceUser);
                    members.Add(forceUser, forceSide);
                }
                else
                {
                    string[] parts = line.Split(" -> ");
                    string forceUser = parts[0];
                    string forceSide = parts[1];

                    if (!memberBySide.ContainsKey(forceSide))
                    {
                        memberBySide.Add(forceSide, new List<string>());
                    }

                    if (members.ContainsKey(forceUser))
                    {
                        string oldSide = members[forceUser];

                        memberBySide[oldSide].Remove(forceUser);
                        memberBySide[forceSide].Add(forceUser);
                        members[forceUser] = forceSide;
                    }
                    else
                    {
                        memberBySide[forceSide].Add(forceUser);
                        members.Add(forceUser, forceSide);
                    }

                    Console.WriteLine($"{forceUser} joins the {forceSide} side!");
                }

            }
            Dictionary<string, List<string>> result = memberBySide
                .Where(x => x.Value.Count > 0)
                .OrderByDescending(x => x.Value.Count)
                .ThenBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);

            foreach (var kvp in result)
            {
                Console.WriteLine($"Side: {kvp.Key}, Members: { kvp.Value.Count}");
                kvp.Value.Sort();

                foreach (var user in kvp.Value)
                {
                    Console.WriteLine($"! {user}");
                }
            }

        }
    }
}
