using System;

namespace _9._Volleyball
{
    class Program
    {
        static void Main(string[] args)
        {
            string year = Console.ReadLine();
            int holidays = int.Parse(Console.ReadLine());
            int weekendsOutOfSofia = int.Parse(Console.ReadLine());

            double saturdayPlaysInSofia = (48 - weekendsOutOfSofia) * 0.75;
            double holidaylayInSofia = holidays * 0.666666666666667;

            double totalPlays = saturdayPlaysInSofia + holidaylayInSofia + weekendsOutOfSofia;
            if (year == "leap")
            {
                totalPlays = totalPlays + (totalPlays * 0.15);
            }

            Console.WriteLine((int)(totalPlays));
        }
    }
}
