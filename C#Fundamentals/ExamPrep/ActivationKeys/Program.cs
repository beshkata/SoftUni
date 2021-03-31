using System;

namespace ActivationKeys
{
    class Program
    {
        static void Main()
        {
            string input = Console.ReadLine();

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "Generate")
                {
                    break;
                }

                string[] tokens = line.Split(">>>");

                string command = tokens[0];

                if (command == "Contains")
                {
                    string substring = tokens[1];

                    if (input.Contains(substring))
                    {
                        Console.WriteLine($"{input} contains {substring}");
                    }
                    else
                    {
                        Console.WriteLine("Substring not found!");
                    }
                }
                else if (command == "Flip")
                {
                    string casing = tokens[1];
                    int startIndex = int.Parse(tokens[2]);
                    int endIndex = int.Parse(tokens[3]);

                    string substring = input.Substring(startIndex, endIndex - startIndex);
                    string replacement = substring;
                    
                    if (casing == "Lower")
                    {
                        replacement = replacement.ToLower();
                    }
                    else
                    {
                        replacement = replacement.ToUpper();
                    }

                    input = input.Replace(substring, replacement);

                    Console.WriteLine(input);
                }
                else if (command == "Slice")
                {
                    int startIndex = int.Parse(tokens[1]);
                    int endIndex = int.Parse(tokens[2]);

                    input = input.Remove(startIndex, endIndex - startIndex);
                    Console.WriteLine(input);
                }
            }

            Console.WriteLine($"Your activation key is: {input}");
        }
    }
}
