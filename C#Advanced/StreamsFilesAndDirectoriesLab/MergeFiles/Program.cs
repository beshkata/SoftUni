using System;
using System.IO;

namespace MergeFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader reader = new StreamReader("FileOne.txt");

            string fileOne = string.Empty;

            using(reader)
            {
                fileOne = reader.ReadToEnd();
            }

            string fileTwo = string.Empty;

            reader = new StreamReader("FileTwo.txt");
            using (reader)
            {
                fileTwo = reader.ReadToEnd();
            }

            using (StreamWriter writer = new StreamWriter("Output.txt"))
            {
                writer.WriteLine(fileOne);
                writer.WriteLine(fileTwo);
            }
        }
    }
}
