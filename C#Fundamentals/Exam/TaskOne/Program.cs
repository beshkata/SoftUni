using System;
using System.Text;
using System.Linq;

namespace TaskOne
{
    class Program
    {
        static void Main(string[] args)
        {
            string username = Console.ReadLine();

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "Sign up")
                {
                    break;
                }

                string[] tokens = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string command = tokens[0];

                if (command == "Case")
                {
                    string caseType = tokens[1];

                    if (caseType == "lower")
                    {
                        username = username.ToLower();
                    }
                    else
                    {
                        username = username.ToUpper();
                    }

                    Console.WriteLine(username);
                }
                else if (command == "Reverse")
                {
                    int startIndex = int.Parse(tokens[1]);
                    int endIndex = int.Parse(tokens[2]);

                    if (IsValid(startIndex, username) && IsValid(endIndex, username))
                    {
                        int count = endIndex - startIndex + 1;
                        string substring = username.Substring(startIndex, count);
                        substring = ReverceString(substring);
                        Console.WriteLine(substring);
                    }
                    
                }
                else if (command == "Cut")
                {
                    string substring = tokens[1];
                    int index = username.IndexOf(substring);

                    if (index >= 0)
                    {
                        username = username.Remove(index, substring.Length);
                        Console.WriteLine(username);
                    }
                    else
                    {
                        Console.WriteLine($"The word {username} doesn't contain {substring}.");
                    }
                }
                else if (command == "Replace")
                {
                    char symbol = char.Parse(tokens[1]);

                    while (username.Contains(symbol))
                    {
                        username = username.Replace(symbol, '*');
                    }
                    Console.WriteLine(username);
                }
                else if (command == "Check")
                {
                    char symbol = char.Parse(tokens[1]);

                    if (username.Contains(symbol))
                    {
                        Console.WriteLine("Valid");
                    }
                    else
                    {
                        Console.WriteLine($"Your username must contain {symbol}.");
                    }
                }
            }
        }

        private static string ReverceString(string substring)
        {
            char[] reverced = substring.Reverse().ToArray();
            StringBuilder stringBuilder = new StringBuilder();

            foreach (char symbol in reverced)
            {
                stringBuilder.Append(symbol);
            }
            return stringBuilder.ToString();
        }

        private static bool IsValid(int index, string username)
        {
            if (index >= 0 && index < username.Length)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
