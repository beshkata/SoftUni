using System;

namespace _09._Moving
{
    class Program
    {
        static void Main()
        {
            int width = int.Parse(Console.ReadLine());
            int length = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();

            int volumeOfRoom = width * length * height;
            int volumeOfBoxes = 0;

            while (input != "Done")
            {
                volumeOfBoxes += int.Parse(input);
                if (volumeOfBoxes >= volumeOfRoom)
                {

                    break;
                }
                input = Console.ReadLine();
            }
            if (volumeOfBoxes >= volumeOfRoom)
            {
                Console.WriteLine($"No more free space! You need {volumeOfBoxes - volumeOfRoom} Cubic meters more.");
            }
            else
            {
                Console.WriteLine($"{volumeOfRoom - volumeOfBoxes} Cubic meters left.");
            }
        }
    }
}
