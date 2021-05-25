using System;
using System.Collections.Generic;
using System.Linq;

namespace SongsQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] songs = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries);

            Queue<string> queueOfSongs = new Queue<string>(songs);

            while (true)
            {
                string command = Console.ReadLine();

                if (command.Contains("Add"))
                {
                    string songName = command.Substring(4);
                    if (queueOfSongs.Contains(songName))
                    {
                        Console.WriteLine($"{songName} is already contained!");
                    }
                    else
                    {
                        queueOfSongs.Enqueue(songName);
                    }
                }
                else if (command == "Play")
                {
                    queueOfSongs.Dequeue();
                }
                else
                {
                    Console.WriteLine(string.Join(", ", queueOfSongs));
                }

                if (queueOfSongs.Count == 0)
                {
                    Console.WriteLine("No more songs!");
                    return;
                }

            }
        }
    }
}
