using System;
using System.IO;

namespace LineNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader reader = new StreamReader("Input.txt");

            using (reader)
            {
                int counter = 1;
                StreamWriter writer = new StreamWriter("Output.txt");
                string line = reader.ReadLine();

                using(writer)
                {
                    while (line != null)
                    {
                        writer.WriteLine($"{counter}. {line}");
                        counter++;
                        line = reader.ReadLine();
                    }
                }
            }
        }
    }
}
