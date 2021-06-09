using System;
using System.IO;

namespace OddLines
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader reader = new StreamReader("Input.txt");

            using (reader)
            {
                string line = reader.ReadLine();
                int counter = 0;

                StreamWriter writer = new StreamWriter("Output.txt");

                using (writer)
                {
                    while (line != null)
                    {
                        if (counter % 2 == 1 )
                        {
                            writer.WriteLine(line);
                        }
                        counter++;
                        line = reader.ReadLine();
                    }

                }
            }
        }
    }
}
