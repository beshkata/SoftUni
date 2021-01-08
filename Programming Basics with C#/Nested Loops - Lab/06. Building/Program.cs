using System;

namespace _06._Building
{
    class Program
    {
        static void Main()
        {
            int floorsNum = int.Parse(Console.ReadLine());
            int roomsNum = int.Parse(Console.ReadLine());

            for (int floor = floorsNum; floor > 0; floor--)
            {
                for (int room = 0; room < roomsNum; room++)
                {
                    if (floor == floorsNum)
                    {
                        Console.Write($"L{floor}{room} ");
                    }
                    else if (floor % 2 == 0)
                    {
                        Console.Write($"O{floor}{room} ");
                    }
                    else
                    {
                        Console.Write($"A{floor}{room} ");
                    }
                }
                Console.WriteLine();
            }
    }
}
