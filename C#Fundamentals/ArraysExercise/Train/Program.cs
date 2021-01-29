using System;

namespace Train
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int[] peopleInWagons = new int[n];
            int totalPeople = 0;
            for (int i = 0; i < peopleInWagons.Length; i++)
            {
                peopleInWagons[i] = int.Parse(Console.ReadLine());
                totalPeople += peopleInWagons[i];
            }
            Console.WriteLine(string.Join(' ', peopleInWagons));
            Console.WriteLine(totalPeople);
        }
    }
}
