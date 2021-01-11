using System;

namespace _02._Cat_Walking
{
    class Program
    {
        static void Main()
        {
            int minutesPerWalking = int.Parse(Console.ReadLine());
            int numbersOfWalking = int.Parse(Console.ReadLine());
            int ccalPerDay = int.Parse(Console.ReadLine());

            int burnCcal = minutesPerWalking * numbersOfWalking * 5;

            if (burnCcal >= ccalPerDay / 2)
            {
                Console.WriteLine($"Yes, the walk for your cat is enough. Burned calories per day: {burnCcal}.");
            }
            else
            {
                Console.WriteLine($"No, the walk for your cat is not enough. Burned calories per day: {burnCcal}.");
            }
        }
    }
}
