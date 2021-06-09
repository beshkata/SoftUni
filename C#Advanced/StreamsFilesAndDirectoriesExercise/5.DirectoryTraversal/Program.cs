using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;

namespace _5.DirectoryTraversal
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<FileInfo>> filesByExtensions = new Dictionary<string, List<FileInfo>>();
            string path = Console.ReadLine();
            string[] files = Directory.GetFiles(path);

            foreach (var file in files)
            {
                FileInfo info = new FileInfo(file);
                string extension = info.Extension;

                if (!filesByExtensions.ContainsKey(extension))
                {
                    filesByExtensions.Add(extension, new List<FileInfo>());
                }
                filesByExtensions[extension].Add(info);
            }

            filesByExtensions = filesByExtensions
                .OrderByDescending(v => v.Value.Count)
                .ThenBy(k => k.Key)
                .ToDictionary(k => k.Key, v => v.Value);

            StreamWriter writer = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/report.txt");

            using (writer)
            {
                foreach (var exten in filesByExtensions)
                {
                    writer.WriteLine(exten.Key);
                    foreach (var file in exten.Value.OrderBy(x =>x.Length))
                    {
                        writer.WriteLine($"--{file.Name} - {(double)file.Length / 1024}kb");
                    }
                }
            }

        }
    }
}
