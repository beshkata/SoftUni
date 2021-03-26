using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace StarEnigma
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());

            List<string> attacked = new List<string>();
            List<string> destoryed = new List<string>();

            string decryptedPattern = @"@(?<name>[A-Za-z]+)([^@\-!:])*:(\d+)([^@\-!:])*!(?<attack>[D|A])!([^@\-!:])*->(\d+)";



            for (int i = 0; i < count; i++)
            {
                string line = Console.ReadLine();

                int key = GetKey(line);

                string decryptedMessage = Decrypt(line, key);

                var match = Regex.Match(decryptedMessage, decryptedPattern);

                if (!match.Success)
                {
                    continue;
                }

                string name = match.Groups["name"].Value;
                string typeAttack = match.Groups["attack"].Value;

                if (typeAttack == "A")
                {
                    attacked.Add(name);
                }
                else
                {
                    destoryed.Add(name);
                }
            }

            attacked.Sort();
            destoryed.Sort();

            Console.WriteLine($"Attacked planets: {attacked.Count}");

            foreach (string name in attacked)
            {
                Console.WriteLine($"-> {name}");
            }

            Console.WriteLine($"Destroyed planets: {destoryed.Count}");

            foreach (string name in destoryed)
            {
                Console.WriteLine($"-> {name}");
            }
        }

        private static string Decrypt(string line, int key)
        {
            StringBuilder sb = new StringBuilder();

            foreach (char symbol in line)
            {
                sb.Append((char)(symbol - key));
            }

            return sb.ToString();
        }

        private static int GetKey(string line)
        {
            string keyPattern = @"[STARstar]";
            MatchCollection matches = Regex.Matches(line, keyPattern);

            return matches.Count;
        }
    }
}
