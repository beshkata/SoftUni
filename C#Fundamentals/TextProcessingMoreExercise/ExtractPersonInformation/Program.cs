using System;

namespace ExtractPersonInformation
{
    class Program
    {
        static void Main()
        {
            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                string line = Console.ReadLine();

                string name = line.Substring(line.IndexOf('@') + 1, line.IndexOf('|') - line.IndexOf('@') - 1);
                string age = line.Substring(line.IndexOf('#') + 1, line.IndexOf('*') - line.IndexOf('#') - 1);
                Console.WriteLine($"{name} is {age} years old.");
            }
        }
    }
}
