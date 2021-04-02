using System;
using System.Linq;
using System.Text;

namespace SecretChat
{
    class Program
    {
        static void Main()
        {
            string message = Console.ReadLine();

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "Reveal")
                {
                    break;
                }

                string[] tokens = line.Split(":|:", StringSplitOptions.RemoveEmptyEntries);

                string command = tokens[0];

                if (command == "InsertSpace")
                {
                    int index = int.Parse(tokens[1]);
                    message = message.Insert(index, " ");
                    Console.WriteLine(message);

                }
                else if (command == "Reverse")
                {
                    string substring = tokens[1];

                    if (!message.Contains(substring))
                    {
                        Console.WriteLine("error");
                    }
                    else
                    {
                        message = Reverse(message, substring);
                        Console.WriteLine(message);
                    }
                }
                else if (command == "ChangeAll")
                {
                    string substring = tokens[1];
                    string replacement = tokens[2];

                    while (message.Contains(substring))
                    {
                        message = message.Replace(substring, replacement);
                    }

                    Console.WriteLine(message);
                }
            }
            Console.WriteLine($"You have a new text message: {message}");
        }

        private static string Reverse(string message, string substring)
        {
            int index = message.IndexOf(substring);
            message = message.Remove(index, substring.Length);
            char[]reversedSub = substring.Reverse().ToArray();
            StringBuilder stringBuilder = new StringBuilder();

            foreach (char item in reversedSub)
            {
                stringBuilder.Append(item);
            }            
            substring = stringBuilder.ToString();

            message = string.Concat(message, substring);

            return message;
        }
    }
}
