using System;

namespace ExtractFile
{
    class Program
    {
        static void Main()
        {
            string path = Console.ReadLine();

            string fileNameWithExten = path.Substring(path.LastIndexOf('\\') + 1);
            string fileName = fileNameWithExten.Substring(0, fileNameWithExten.LastIndexOf('.'));
            string extension = fileNameWithExten.Substring(fileNameWithExten.LastIndexOf('.') + 1);

            Console.WriteLine($"File name: {fileName}");
            Console.WriteLine($"File extension: {extension}");
        }
    }
}
