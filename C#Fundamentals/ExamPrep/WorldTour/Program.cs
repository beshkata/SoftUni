using System;

namespace WorldTour
{
    class Program
    {
        static void Main(string[] args)
        {
            string stops = Console.ReadLine();

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "Travel")
                {
                    break;
                }

                string[] tokens = line.Split(':');

                string command = tokens[0];

                if (command == "Add Stop")
                {
                    int index = int.Parse(tokens[1]);
                    string substring = tokens[2];

                    if (IsValid(index, stops))
                    {
                        stops = stops.Insert(index, substring);
                    }

                    Console.WriteLine(stops);
                }
                else if (command == "Remove Stop")
                {
                    int startIndex = int.Parse(tokens[1]);
                    int endIndex = int.Parse(tokens[2]);

                    if (endIndex < startIndex)
                    {
                        int temp = endIndex;
                        endIndex = startIndex;
                        startIndex = temp;
                    }

                    if (IsValid(startIndex, stops) && IsValid(endIndex, stops))
                    {
                        int count = endIndex - startIndex + 1;
                        stops = stops.Remove(startIndex, count);
                    }
                    Console.WriteLine(stops);
                }
                else if (command == "Switch")
                {
                    string oldString = tokens[1];
                    string newString = tokens[2];

                    if (stops.Contains(oldString))
                    {
                        while (stops.Contains(oldString))
                        {
                            stops = stops.Replace(oldString, newString);
                        }
                    }

                    Console.WriteLine(stops);
                }
            }

            Console.WriteLine($"Ready for world tour! Planned stops: {stops}");
        }

        private static bool IsValid(int index, string word)
        {
            if (index >= 0 && index < word.Length)
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
