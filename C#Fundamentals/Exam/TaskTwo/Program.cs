using System;
using System.Text.RegularExpressions;

namespace TaskTwo
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"^([\w\W]+)>(\d{3})\|([a-z]{3})\|([A-Z]{3})\|([^<>]{3})<(\1)$";

            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                string password = Console.ReadLine();

                Match match = Regex.Match(password, pattern);

                if (!match.Success)
                {
                    Console.WriteLine("Try another password!");
                }
                else
                {
                    string encrypted = string.Concat(match.Groups[2].Value,
                        match.Groups[3].Value,
                        match.Groups[4].Value,
                        match.Groups[5].Value);

                    Console.WriteLine($"Password: {encrypted}");
                }
            }
        }
    }
}
