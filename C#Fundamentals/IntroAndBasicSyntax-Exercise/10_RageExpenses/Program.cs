using System;

namespace _10_RageExpenses
{
    class Program
    {
        static void Main()
        {
            int gamesLost = int.Parse(Console.ReadLine());
            double headsetPrice = double.Parse(Console.ReadLine());
            double mousePrice = double.Parse(Console.ReadLine());
            double keyboardPrice = double.Parse(Console.ReadLine());
            double displayPrice = double.Parse(Console.ReadLine());

            int headsetTrashed = 0;
            int mouseTrashed = 0;
            int keyboardTrashed = 0;
            int displayTrashed = 0;

            for (int i = 1; i <= gamesLost; i++)
            {
                if (i % 2 == 0)
                {
                    headsetTrashed++;
                }
                if (i % 3 == 0)
                {
                    mouseTrashed++;
                }
                if (i % 6 == 0)
                {
                    keyboardTrashed++;
                    if (keyboardTrashed % 2 == 0)
                    {
                        displayTrashed++;
                    }
                }
            }
            double totalPrice = headsetTrashed * headsetPrice + mouseTrashed * mousePrice +
                keyboardTrashed * keyboardPrice + displayTrashed * displayPrice;
            Console.WriteLine($"Rage expenses: {totalPrice:f2} lv.");
        }
    }
}
