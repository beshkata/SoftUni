using System;
using System.Collections.Generic;
using System.Linq;

namespace Songs
{
    class Song
    {
        public Song(string typeList, string name, string time)
        {
            TypeList = typeList;
            Name = name;
            Time = time;
        }

        public string TypeList { get; set; }

        public string Name { get; set; }

        public string Time { get; set; }


    }
    class Program
    {
        static void Main()
        {
            int songsCount = int.Parse(Console.ReadLine());
            List<Song> songs = new List<Song>();

            for (int i = 0; i < songsCount; i++)
            {
                string[] inputs = Console.ReadLine().Split('_');

                Song newSong = new Song(inputs[0], inputs[1], inputs[2]);
                songs.Add(newSong);
            }

            string filterType = Console.ReadLine();

            if (filterType == "all")
            {
                PrintSongsName(songs);
            }
            else
            {
                List<Song> filteredSongs = songs
                    .Where(s => s.TypeList == filterType)
                    .ToList();
                PrintSongsName(filteredSongs);
            }
        }

        private static void PrintSongsName(List<Song> songs)
        {
            foreach (Song song in songs)
            {
                Console.WriteLine(song.Name);
            }
        }
    }
}
