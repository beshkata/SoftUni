using System;

namespace SecondProblem
{
    class Program
    {
        static void Main()
        {
            string[] names = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);

            int lostNames = 0;
            int blacklistedNames = 0;

            string input = Console.ReadLine();

            while (input != "Report")
            {
                string[] commands = input.Split();
                string command = commands[0];
                int index = 0;

                switch (command)
                {
                    case "Blacklist":
                        string name = commands[1];
                        if(BlacklistUser(names, name))
                        {
                            blacklistedNames++;
                        }
                        break;
                    case "Error":
                        index = int.Parse(commands[1]);
                        if(ErrorUser(names, index))
                        {
                            lostNames++;
                        }
                        break;
                    case "Change":
                        index = int.Parse(commands[1]);
                        string newName = commands[2];
                        ChangeName(names, index, newName);
                        break;
                    default:
                        break;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"Blacklisted names: {blacklistedNames}");
            Console.WriteLine($"Lost names: {lostNames}");
            Console.WriteLine(string.Join(' ', names));
        }

        private static void ChangeName(string[] names, int index, string newName)
        {
            if (index >= 0 && index < names.Length)
            {
                string currentName = names[index];
                names[index] = newName;
                Console.WriteLine($"{currentName} changed his username to {newName}.");
            }
        }

        private static bool ErrorUser(string[] names, int index)
        {
            if (index >= 0 && index < names.Length)
            {
                if (names[index] != "Blacklisted" && names[index] != "Lost")
                {
                    string name = names[index];
                    names[index] = "Lost";
                    Console.WriteLine($"{name} was lost due to an error.");
                    return true;
                }
            }
            return false;
        }

        private static bool BlacklistUser(string[] names, string name)
        {
            for (int i = 0; i < names.Length; i++)
            {
                if (names[i] == name)
                {
                    names[i] = "Blacklisted";
                    Console.WriteLine($"{name} was blacklisted.");
                    return true;
                }
            }
            Console.WriteLine($"{name} was not found.");
            return false;
        }
    }
}
